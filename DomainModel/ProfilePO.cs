using System;

namespace NotatnikSilowy.DomainModel;

public class ProfilePO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
}
