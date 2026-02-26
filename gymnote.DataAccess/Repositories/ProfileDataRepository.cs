using System.Text.Json;
using gymnote.DataAccess.Models;

namespace gymnote.DataAccess.Repositories;

public class ProfileDataRepository
{
    private readonly string _profilesDirectoryPath;
    private readonly object _lock = new();

    public ProfileDataRepository(string baseDirectory)
    {
        _profilesDirectoryPath = Path.Combine(baseDirectory, "LocalData", "Profiles");
        Directory.CreateDirectory(_profilesDirectoryPath);
    }

    private string GetProfileFilePath(string profileId) =>
        Path.Combine(_profilesDirectoryPath, $"{profileId}.json");

    public void Add(Profile profile)
    {
        lock (_lock)
        {
            var filePath = GetProfileFilePath(profile.Id);
            using var stream = File.Open(filePath, FileMode.CreateNew, FileAccess.Write);
            JsonSerializer.Serialize(stream, profile, new JsonSerializerOptions { WriteIndented = true });
        }
    }

    public void Update(Profile profile)
    {
        lock (_lock)
        {
            var filePath = GetProfileFilePath(profile.Id);
            if (!File.Exists(filePath))
                throw new KeyNotFoundException($"Profile data for Id '{profile.Id}' not found.");
            var json = JsonSerializer.Serialize(profile, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }

    public void Remove(string profileId)
    {
        lock (_lock)
        {
            var filePath = GetProfileFilePath(profileId);
            if (!File.Exists(filePath))
                throw new KeyNotFoundException($"Profile data for Id '{profileId}' not found.");
            File.Delete(filePath);
        }
    }
}
