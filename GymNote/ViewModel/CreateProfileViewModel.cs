using CommunityToolkit.Mvvm.ComponentModel;
using DomainModel;

namespace GymNote.ViewModel;

//[QueryProperty(nameof(Surname), QueryAttribute.Id )]
public partial class CreateProfileViewModel : ObservableObject
{
    [ObservableProperty]
    private string name = "";

    [ObservableProperty]
    private string surname = "";
}
