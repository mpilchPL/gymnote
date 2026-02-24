namespace NotatnikSilowy.ViewModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class MainPageViewModel() : ObservableObject
{
	[ObservableProperty]
	private string testText = "Hello, World!!!!";

	[RelayCommand]
	public void Test()
	{
		System.Diagnostics.Debug.WriteLine("Test button clicked");
	}
}