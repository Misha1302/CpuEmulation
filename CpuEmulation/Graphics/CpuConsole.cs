using SFML.Graphics;
using SFML.Window;

namespace CpuEmulation.Graphics;

public static class CpuConsole
{
    public const int Width = 1024;
    public const int Height = 512;
    public const int Count = Width * Height;


    public static void Run()
    {
        var videoMode = new VideoMode(Width, Height);
        var window = new RenderWindow(videoMode, "Base console");

        var windowController = new WindowController(window);
        var keyboardController = new KeyboardController();
        var videoController = new VideoController(window);

        window.KeyPressed += keyboardController.OnWindowKeyPressed;
        window.KeyReleased += keyboardController.OnWindowKeyReleased;
        window.Closed += windowController.OnWindowClosed;
        window.Resized += windowController.OnWindowResized;

        while (window.IsOpen)
        {
            window.DispatchEvents();
            videoController.WindowDisplay(keyboardController);
        }
    }
}