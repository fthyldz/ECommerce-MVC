using System.Security.Claims;
using Application.Commands.Discounts.CreateDiscount;
using Application.Commands.Discounts.CreateDiscount.DTOs;
using Application.Commands.Discounts.DeleteDiscount;
using Application.Queries.Categories.GetCategories;
using Application.Queries.Discounts.GetDiscounts;
using Application.Queries.Products.GetProducts;
using Application.Queries.Roles.GetRoles;
using AutoMapper;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.WebUI.Controllers;

[Authorize(Roles = "Admin")]
[Controller]
[Route("discounts")]
public class DiscountsController(ISender sender, IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
    {
        var response = await sender.Send(new GetDiscountsCommand(), cancellationToken);
        return View(response.Discounts);
    }

    [HttpPost("Delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await sender.Send(new DeleteDiscountCommand(DiscountId.Of(id)), cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Create")]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!;

        var responseProducts = await sender.Send(new GetProductsQuery(role.Value), cancellationToken);

        ViewBag.Products = responseProducts.Products.Select(c => new SelectListItem(c.Name, c.Id.ToString()));

        var responseRoles = await sender.Send(new GetRolesQuery(), cancellationToken);

        ViewBag.Roles = responseRoles.Roles.Select(c => new SelectListItem(c.Name, c.Id.ToString()));

        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateDiscountRequestDto discountDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!;

            var responseProducts = await sender.Send(new GetProductsQuery(role.Value), cancellationToken);

            ViewBag.Products = responseProducts.Products.Select(c => new SelectListItem(c.Name, c.Id.ToString()));

            var responseRoles = await sender.Send(new GetRolesQuery(), cancellationToken);

            ViewBag.Roles = responseRoles.Roles.Select(c => new SelectListItem(c.Name, c.Id.ToString()));

            return View(discountDto);
        }

        await sender.Send(mapper.Map<CreateDiscountCommand>(discountDto), cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}