using System.ComponentModel.DataAnnotations;

namespace FlappyAlby.API.DTOs;

public class PlayerDto
{
    [Required, StringLength(10)]
    public string Name { get; init; } = string.Empty;

    [Required]
    public TimeSpan Total { get; init; } = default;

    public int? Id { get; init; }
}