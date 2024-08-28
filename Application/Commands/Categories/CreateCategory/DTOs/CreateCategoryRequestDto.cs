using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Categories.CreateCategory.DTOs;

public record CreateCategoryRequestDto(
    [Required(ErrorMessage = "Kategori Adı boş olamaz")]
    [MaxLength(100, ErrorMessage = "Kategori Adı 100 karakterden uzun olamaz")]
    string Name);