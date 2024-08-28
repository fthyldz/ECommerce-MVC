using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Discounts.DeleteDiscount.DTOs;

public record DeleteDiscountRequestDto(
    [Required(ErrorMessage = "Discount Id boş olamaz")]
    Guid Id);