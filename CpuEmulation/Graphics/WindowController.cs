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

    public void OnWindowClosed(object? sender, EventArgs e)
    {
        _window.Close();
    }

    public void OnWindowResized(object? sender, SizeEventArgs e)
    {
        _window.Size = new Vector2u(CpuConsole.Width, CpuConsole.Height);
    }
}