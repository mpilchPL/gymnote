using NotatnikSilowy.ViewModel;

namespace NotatnikSilowy.View;

public partial class CreateProfile : ContentPage
{
	public CreateProfile(CreateProfileViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}