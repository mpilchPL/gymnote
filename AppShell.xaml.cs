using NotatnikSilowy.View;

namespace NotatnikSilowy;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CreateProfile), typeof(CreateProfile));
	}
}
