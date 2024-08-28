using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Categories.DeleteCategory.DTOs;

public record struct DeleteCategoryRequestDto(
    [Required(ErrorMessage = "Kategori Id boş olamaz")]
    Guid Id);