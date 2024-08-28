using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Discounts.CreateDiscount.DTOs;

public record CreateDiscountRequestDto([Required] Guid ProductId, Guid? RoleId, [Required] decimal Rate);