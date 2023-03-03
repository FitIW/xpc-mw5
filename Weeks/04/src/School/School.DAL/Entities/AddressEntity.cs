namespace School.DAL.Entities;

public record AddressEntity : EntityBase
{
    public required string City { get; set; }
    public required string State { get; set; }
}