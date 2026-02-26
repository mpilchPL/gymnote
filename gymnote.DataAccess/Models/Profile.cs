namespace gymnote.DataAccess.Models;

public class Profile
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Preferences Preferences { get; set; } = new Preferences();
}
