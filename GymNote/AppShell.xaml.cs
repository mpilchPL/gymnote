using GymNote.View;

namespace GymNote;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CreateProfile), typeof(CreateProfile));
	}
}
