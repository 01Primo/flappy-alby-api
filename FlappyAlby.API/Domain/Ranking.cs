namespace FlappyAlby.API.Domain;

public record Ranking(int PlayerId, int Total, int? Id = default) : EntityBase(Id)
{
    public Player? Player { get; }
}