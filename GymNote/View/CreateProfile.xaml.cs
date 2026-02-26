using GymNote.ViewModel;

namespace GymNote.View;

public partial class CreateProfile : ContentPage
{
	public CreateProfile(CreateProfileViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}