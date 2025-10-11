namespace Social_Sport_Hub;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var win = new Window(new AppShell());
#if WINDOWS
        const int w = 390, h = 844; // iPhone 13-ish size
        win.Width = w;
        win.Height = h;
#endif
        return win;

    }
}
