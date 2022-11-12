using System.Diagnostics;
using CpuEmulation.Cpu.Memory;
using SFML.Graphics;
using SFML.System;

namespace CpuEmulation.Graphics;

public class VideoController
{
    private readonly Color _foregroundFontColor = Color.Cyan;
    private readonly Shape _point;
    private readonly RenderWindow _window;

    public VideoController(RenderWindow window)
    {
        _window = window;

        _point = new RectangleShape(new Vector2f(1, 1));
        _point.FillColor = _foregroundFontColor;
    }

    /// <summary>
    ///     Displays vram
    /// </summary>
    public void WindowDisplay()
    {
        var stopwatch = Stopwatch.StartNew();

        ClearWindow();
        DrawVramInternal();
        _window.Display();

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }

    /// <summary>
    ///     Draws video memory on the window. To display, use WindowDisplay
    /// </summary>
    private void DrawVramInternal()
    {
        for (var i = 0; i < CpuConsole.Count; i++)
        {
            if (!MemoryEmulation.GetBit(MemoryEmulationConstants.VramOffset + i)) continue;

            // ReSharper disable once PossibleLossOfFraction
            var x = i / CpuConsole.Height;
            var y = i % CpuConsole.Height;

            _point.Position = new Vector2f(x, y);
            _window.Draw(_point);
        }
    }

    /// <summary>
    ///     Clears the screen of old pixels
    /// </summary>
    private void ClearWindow()
    {
        _window.Clear();
    }
}