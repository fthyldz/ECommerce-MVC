using Application.Commands.Categories.CreateCategory;
using Application.Commands.Categories.CreateCategory.DTOs;
using Application.Commands.Categories.DeleteCategory;
using Application.Commands.Categories.UpdateCategory;
using Application.Commands.Categories.UpdateCategory.DTOs;
using Application.Queries.Categories.GetCategories;
using Application.Queries.Categories.GetCategoryById;
using AutoMapper;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebUI.Controllers;

[Authorize(Roles = "Admin")]
[Controller]
[Route("categories")]
public class CategoriesController(ISender sender, IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
    {
        var response = await sender.Send(new GetCategoriesQuery(), cancellationToken);
        return View(response.Categories);
    }

    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetCategoryByIdQuery(CategoryId.Of(id)), cancellationToken);
        return View(response.Category);
    }

    [HttpPost("Delete/{id}"), ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
    {
        await sender.Send(new DeleteCategoryCommand(CategoryId.Of(id)), cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCategoryRequestDto categoryDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View(categoryDto);

        await sender.Send(mapper.Map<CreateCategoryCommand>(categoryDto), cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetCategoryByIdQuery(CategoryId.Of(id)), cancellationToken);
        return View(response.Category);
    }

    [HttpPost("Edit/{id}"), ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditConfirmed(UpdateCategoryRequestDto categoryDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View(mapper.Map<CategoryDto>(categoryDto));
        await sender.Send(mapper.Map<UpdateCategoryCommand>(categoryDto), cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}