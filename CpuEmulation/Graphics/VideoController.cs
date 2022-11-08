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

        _fillShape = new RectangleShape(new Vector2f(CpuConsole.WIDTH, CpuConsole.HEIGHT));
        _fillShape.FillColor = _backgroundFontColor;
        _fillShape.Position = new Vector2f(0, 0);
    }

    public void WindowDisplay(KeyboardController keyboardController)
    {
        var stopwatch = Stopwatch.StartNew();

        ClearWindow(keyboardController);
        for (var i = 0; i < CpuConsole.COUNT; i++)
        {
            if (!Memory.GetBit(MemoryConstants.VRAM_OFFSET + i)) continue;

            // ReSharper disable once PossibleLossOfFraction
            _point.Position = new Vector2f(i / CpuConsole.HEIGHT, i % CpuConsole.HEIGHT);
            _window.Draw(_point);
        }

        _window.Display();

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }

    private void ClearWindow(KeyboardController keyboardController)
    {
        _window.Draw(_fillShape);
        Memory.ClearVRam();
        keyboardController.SetVramOfLetters();
    }
}