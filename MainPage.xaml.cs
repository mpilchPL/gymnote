using NotatnikSilowy.ViewModel;

namespace NotatnikSilowy;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
