namespace GymNote.ViewModel;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using DomainModel;

public partial class MainPageViewModel : ObservableObject
{
	private readonly ILogger<MainPageViewModel> _logger;

	[ObservableProperty]
	private ObservableCollection<GymerProfilePO> _profiles = new ObservableCollection<GymerProfilePO>();

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(IsBeginEnabled))]
	private GymerProfilePO? _selectedProfile;

	public MainPageViewModel(ILogger<MainPageViewModel> logger)
	{
		Profiles.Add(new GymerProfilePO { Id = Guid.NewGuid(), Name = "John", Surname = "Doe" });
		Profiles.Add(new GymerProfilePO { Id = Guid.NewGuid(), Name = "Jane", Surname = "Smith" });
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