using System.Diagnostics;
using CpuEmulation.Cpu.Memory;
using SFML.Graphics;
using SFML.System;

namespace CpuEmulation.Graphics;

public class VideoController
{
    private readonly Color _backgroundFontColor = Color.Black;
    private readonly Shape _fillShape;
    private readonly Color _foregroundFontColor = Color.Cyan;
    private readonly Shape _point;
    private readonly RenderWindow _window;

    public VideoController(RenderWindow window)
    {
        _window = window;

        _point = new RectangleShape(new Vector2f(1, 1));
        _point.FillColor = _foregroundFontColor;

        _fillShape = new RectangleShape(new Vector2f(CpuConsole.Width, CpuConsole.Height));
        _fillShape.FillColor = _backgroundFontColor;
        _fillShape.Position = new Vector2f(0, 0);
    }

    public void WindowDisplay(KeyboardController keyboardController)
    {
        var stopwatch = Stopwatch.StartNew();

        ClearWindow(keyboardController);
        for (var i = 0; i < CpuConsole.Count; i++)
        {
            if (!MemoryEmulation.GetBit(MemoryEmulationConstants.VramOffset + i)) continue;

            // ReSharper disable once PossibleLossOfFraction
            var x = i / CpuConsole.Height;
            var y = i % CpuConsole.Height;

            _point.Position = new Vector2f(x, y);
            _window.Draw(_point);
        }

        _window.Display();

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }

    private void ClearWindow(KeyboardController keyboardController)
    {
        _window.Draw(_fillShape);
        MemoryEmulation.ClearVRam();
        keyboardController.SetVramOfLetters();
    }
}