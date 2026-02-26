namespace DomainModel;

public class GymerProfile
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Preferences Preferences { get; set; }

    public GymerProfile(string name, string surname = "")
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Preferences = new Preferences();
    }
}