using System.Text.Json;
using DomainModel;

namespace DataAccess.Repositories;

public class ProfilesRepository
{
    private readonly string _localDataPath;
    private readonly string _profilesFilePath;
    private readonly string _profilesDirectoryPath;
    private readonly object _lock = new();

    public ProfilesRepository(string baseDirectory)
    {
        _localDataPath = Path.Combine(baseDirectory, "LocalData");
        _profilesFilePath = Path.Combine(_localDataPath, "Profiles.json");
        _profilesDirectoryPath = Path.Combine(_localDataPath, "Profiles");
        EnsureDirectoriesExist();
    }

    private void EnsureDirectoriesExist()
    {
        Directory.CreateDirectory(_localDataPath);
        Directory.CreateDirectory(_profilesDirectoryPath);
        if (!File.Exists(_profilesFilePath))
        {
            File.WriteAllText(_profilesFilePath, "[]");
        }
    }

    private List<GymerProfile> ReadAll()
    {
        var json = File.ReadAllText(_profilesFilePath);
        return JsonSerializer.Deserialize<List<GymerProfile>>(json) ?? [];
    }

    private void WriteAll(List<GymerProfile> profiles)
    {
        var json = JsonSerializer.Serialize(profiles, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_profilesFilePath, json);
    }

    public void Add(GymerProfile profile)
    {
        lock (_lock)
        {
            var profiles = ReadAll();
            if (profiles.Any(p => p.Id == profile.Id))
                throw new InvalidOperationException($"Profile with Id '{profile.Id}' already exists.");
            profiles.Add(profile);
            WriteAll(profiles);
        }
    }

    public void Update(GymerProfile profile)
    {
        lock (_lock)
        {
            var profiles = ReadAll();
            var index = profiles.FindIndex(p => p.Id == profile.Id);
            if (index < 0)
                throw new KeyNotFoundException($"Profile with Id '{profile.Id}' not found.");
            profiles[index] = profile;
            WriteAll(profiles);
        }
    }

    public void Remove(Guid profileId)
    {
        lock (_lock)
        {
            var profiles = ReadAll();
            var removed = profiles.RemoveAll(p => p.Id == profileId);
            if (removed == 0)
                throw new KeyNotFoundException($"Profile with Id '{profileId}' not found.");
            WriteAll(profiles);
        }
    }
}
