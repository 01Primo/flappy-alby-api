namespace FlappyAlby.API.Domain;

public record Player(int? Id = default, string Name = "", TimeSpan Total = default ) : EntityBase(Id);