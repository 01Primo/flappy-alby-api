namespace FlappyAlby.API.Domain;

using System.ComponentModel.DataAnnotations;

public record Player(string Name, int? Id = default) : EntityBase(Id)
{
    public IReadOnlyCollection<Ranking> Rankings { get; } = new HashSet<Ranking>();
}