namespace Social_Sport_Hub;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; set; } = default!;

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
