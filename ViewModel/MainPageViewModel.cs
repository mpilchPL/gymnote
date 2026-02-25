namespace NotatnikSilowy.ViewModel;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotatnikSilowy.DomainModel;
using Microsoft.Extensions.Logging;

public partial class MainPageViewModel : ObservableObject
{
	private readonly ILogger<MainPageViewModel> _logger;

	[ObservableProperty]
	private ObservableCollection<ProfilePO> _profiles = new ObservableCollection<ProfilePO>();

	[ObservableProperty]
	private ProfilePO? _selectedProfile;

	public MainPageViewModel(ILogger<MainPageViewModel> logger)
	{
		Profiles.Add(new ProfilePO { Id = Guid.NewGuid(), Name = "John", Surname = "Doe" });
		Profiles.Add(new ProfilePO { Id = Guid.NewGuid(), Name = "Jane", Surname = "Smith" });
		_logger = logger;
	}

	public bool IsBeginEnabled => SelectedProfile != null;

	[RelayCommand(CanExecute = nameof(IsBeginEnabled))]
	public void Begin(string text)
	{
		_logger.LogDebug("Begin command executed with parameter: {Text}", text);
	}

    [RelayCommand]
    public async Task NewProfile() => await Shell.Current.GoToAsync(nameof(CreateProfileViewModel));
}