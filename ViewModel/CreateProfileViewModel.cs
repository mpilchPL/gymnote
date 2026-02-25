using System;
using CommunityToolkit.Mvvm.ComponentModel;
using NotatnikSilowy.DomainModel;

namespace NotatnikSilowy.ViewModel;

//[QueryProperty(nameof(Surname), QueryAttribute.Id )]
public partial class CreateProfileViewModel : ObservableObject
{
    [ObservableProperty]
    private string name = "";

    [ObservableProperty]
    private string surname = "";
}
