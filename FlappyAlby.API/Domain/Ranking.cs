namespace FlappyAlby.API.Domain;

public record Ranking(int PlayerId, TimeSpan Total, int? Id = default) : EntityBase(Id)
{
    public Player? Player { get; }
}