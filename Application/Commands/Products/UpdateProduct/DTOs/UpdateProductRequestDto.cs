using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.Commands.Products.UpdateProduct.DTOs;

public record UpdateProductRequestDto(
    [Required(ErrorMessage = "Ürün Id boş olamaz")]
    Guid Id,
    [Required(ErrorMessage = "Ürün Adı boş olamaz")]
    string Name,
    [Required(ErrorMessage = "Ürün Açıklaması boş olamaz")]
    string Description,
    [Required(ErrorMessage = "Ürün Fiyatı boş olamaz")]
    decimal Price,
    [Required(ErrorMessage = "Ürün Para Birimi boş olamaz")]
    CurrencyType Currency,
    [Required(ErrorMessage = "Ürün Stok Miktarı boş olamaz")]
    int StockQuantity,
    [Required(ErrorMessage = "Kategori Id boş olamaz")]
    Guid CategoryId);