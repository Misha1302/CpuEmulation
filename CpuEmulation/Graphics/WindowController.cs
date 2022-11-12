using SFML.System;
using SFML.Window;

namespace CpuEmulation.Graphics;

public class WindowController
{
    private readonly Window _window;

    public WindowController(Window window)
    {
        _window = window;
    }

    /// <summary>
    ///     Method called when the window is closed
    /// </summary>
    public void OnWindowClosed(object? sender, EventArgs e)
    {
        _window.Close();
    }

    /// <summary>
    ///     method called when the window is resized
    /// </summary>
    public void OnWindowResized(object? sender, SizeEventArgs e)
    {
        _window.Size = new Vector2u(CpuConsole.Width, CpuConsole.Height);
    }
}