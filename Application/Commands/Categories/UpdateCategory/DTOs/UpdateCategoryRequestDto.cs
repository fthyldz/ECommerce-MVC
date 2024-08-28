using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Categories.UpdateCategory.DTOs;

public record UpdateCategoryRequestDto(
    [Required(ErrorMessage = "Kategori Id boş olamaz")]
    Guid Id,
    [Required(ErrorMessage = "Kategori Adı boş olamaz")]
    [MaxLength(100, ErrorMessage = "Kategori Adı 100 karakterden uzun olamaz")]
    string Name);