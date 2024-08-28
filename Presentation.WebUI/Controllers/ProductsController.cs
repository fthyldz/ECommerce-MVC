using System.Security.Claims;
using Application.Commands.Products.CreateProduct;
using Application.Commands.Products.CreateProduct.DTOs;
using Application.Commands.Products.DeleteProduct;
using Application.Commands.Products.DeleteProducts;
using Application.Commands.Products.UpdateProduct;
using Application.Commands.Products.UpdateProduct.DTOs;
using Application.Queries.Categories.GetCategories;
using Application.Queries.Products.GetProductById;
using Application.Queries.Products.GetProducts;
using Application.Queries.Products.GetProductsByCategory;
using AutoMapper;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.WebUI.Controllers;

[Controller]
[Route("products")]
public class ProductsController(ISender sender, IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(Guid? categoryId, CancellationToken cancellationToken = default)
    {
        var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
        var roleName = role is null ? "User" : role.Value;
        var products =
            await sender.Send(
                new GetProductsByCategoryQuery(categoryId.HasValue ? CategoryId.Of(categoryId.Value) : null,
                    roleName),
                cancellationToken);
        var categories = await sender.Send(new GetCategoriesQuery(), cancellationToken);

        ViewBag.Categories = categories.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString()));

        return View(products.Products);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!;

        var response = await sender.Send(new GetProductByIdQuery(ProductId.Of(id), role.Value), cancellationToken);
        return View(response.Product);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("Delete/{id}"), ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new DeleteProductCommand(ProductId.Of(id)), cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("DeleteChecked")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteChecked(List<ProductCheckableDto> productsDto,
        CancellationToken cancellationToken = default)
    {
        if (productsDto == null || !productsDto.Any()) RedirectToAction(nameof(Index));
        var selectedProductIds = productsDto.Where(p => p.IsSelected).Select(x => ProductId.Of(x.Id));
        if (!selectedProductIds.Any()) RedirectToAction(nameof(Index));
        await sender.Send(new DeleteProductsCommand(selectedProductIds), cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("Create")]
    public async Task<IActionResult> Create(CancellationToken cancellationToken = default)
    {
        var response = await sender.Send(new GetCategoriesQuery(), cancellationToken);
        ViewBag.Currencies = new List<SelectListItem>
        {
            new SelectListItem("TRY", "0"),
            new SelectListItem("USD", "1"),
            new SelectListItem("EUR", "2")
        };
        ViewBag.Categories = response.Categories.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductRequestDto productDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            var response = await sender.Send(new GetCategoriesQuery(), cancellationToken);
            ViewBag.Currencies = new List<SelectListItem>
            {
                new SelectListItem("TRY", "0"),
                new SelectListItem("USD", "1"),
                new SelectListItem("EUR", "2")
            };
            ViewBag.Categories = response.Categories.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View(productDto);
        }

        await sender.Send(mapper.Map<CreateProductCommand>(productDto), cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!;

        var response = await sender.Send(new GetProductByIdQuery(ProductId.Of(id), role.Value), cancellationToken);
        var categories = await sender.Send(new GetCategoriesQuery(), cancellationToken);
        ViewBag.Currencies = new List<SelectListItem>
        {
            new SelectListItem("TRY", "0"),
            new SelectListItem("USD", "1"),
            new SelectListItem("EUR", "2")
        };
        ViewBag.Categories = categories.Categories.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        return View(response.Product);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("Edit/{id}"), ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditConfirmed(UpdateProductRequestDto productDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            var categories = await sender.Send(new GetCategoriesQuery(), cancellationToken);
            ViewBag.Currencies = new List<SelectListItem>
            {
                new SelectListItem("TRY", "0"),
                new SelectListItem("USD", "1"),
                new SelectListItem("EUR", "2")
            };
            ViewBag.Categories = categories.Categories.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View(mapper.Map<ProductDto>(productDto));
        }

        await sender.Send(mapper.Map<UpdateProductCommand>(productDto), cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Detail/{id}")]
    public async Task<IActionResult> Detail(Guid id, CancellationToken cancellationToken)
    {
        var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
        var roleName = role is null ? "User" : role.Value;
        var response = await sender.Send(new GetProductByIdQuery(ProductId.Of(id), roleName), cancellationToken);
        return View(response.Product);
    }
}