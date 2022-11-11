using System.Collections;
using CpuEmulation.Cpu;
using CpuEmulation.Cpu.Memory;
using SFML.System;
using SFML.Window;

namespace CpuEmulation.Graphics;

public class KeyboardController
{
    private const int LETTER_X_OFFSET = 12;
    private const int LETTER_Y_OFFSET = 16;

    private const int DEFAULT_Y_POSITION = 2;
    private const int DEFAULT_X_POSITION = 2;

    private const int QUESTION_INT_KEY = 52;

    private Vector2i _position;

    public KeyboardController()
    {
        ClearPosition();
    }

    public void OnWindowKeyPressed(object? sender, KeyEventArgs e)
    {
        Registers.Eax = Registers.InputIp;
        Registers.Ebx = BitAlgebra.ThirtyTwo;
        BitAlgebra.Add();
        Registers.InputIp = (BitArray)Registers.Eax.Clone();

        var address = Registers.InputIp.ToInt32();
        MemoryEmulation.Set32Bits(((int)e.Code).ToBitArray(), address);
    }

    public void SetVramOfLetters()
    {
        ClearPosition();
        for (var i = MemoryEmulationConstants.InputRamOffset;
             i < MemoryEmulationConstants.InputRamOffset + MemoryEmulationConstants.InputRamSize - 32;
             i += 32)
        {
            if (MemoryEmulation.GetBit(i)) continue;
            var get32Bit = MemoryEmulation.Get32Bits(i);

            var currentKey = get32Bit.ToInt32();
            switch (currentKey)
            {
                case (int)Keyboard.Key.Backspace:
                    FreeInputMemory(new[] { i, i - 32 });
                    ReduceInputIp(i, 2);
                    return;
                case (int)Keyboard.Key.Enter:
                    GotoNewLine();
                    continue;
            }

            if (!FindLetter(currentKey, out var letterArray))
                FindLetter(QUESTION_INT_KEY, out letterArray);

            foreach (var vector2I in letterArray)
            {
                // the logical condition would be "letterArray[j].X == int.MaxValue || letterArray[j].Y == int.MinValue",
                // but the second part doesn't matter because both X and Y are int.MinValue.
                // For a slight increase in speed, you can not use "==", but replace it with "<".
                // In this case, the condition will run 16 times faster

                if (vector2I.X < 0) break;

                var positionX = vector2I.X + _position.X;
                var positionY = vector2I.Y + _position.Y;
                var vramOffset = CpuConsole.Height * positionX + positionY + MemoryEmulationConstants.VramOffset;
                MemoryEmulation.SetBit(true, vramOffset);
            }

            _position.X += LETTER_X_OFFSET;
            if (_position.X >= CpuConsole.Width - 8) GotoNewLine();
        }
    }

    private static void FreeInputMemory(IEnumerable<int> addresses)
    {
        foreach (var address in addresses) MemoryEmulation.SetBit(true, address);
    }

    private static bool FindLetter(int currentKey, out Vector2i[] letterArray)
    {
        var numberBitArray = currentKey.ToBitArray();

        letterArray = new Vector2i[Letters.SizeOneLetter];
        letterArray = letterArray.Select(_ => new Vector2i(int.MinValue, int.MinValue)).ToArray();

        for (var i = MemoryEmulationConstants.LettersRamOffset;
             i < MemoryEmulationConstants.LettersRamOffset + MemoryEmulationConstants.LettersRamSize;)
        {
            var get32Bits = MemoryEmulation.Get32Bits(i);
            if (!get32Bits.Identical(numberBitArray))
            {
                i += 64 * Letters.SizeOneLetter + 32;
                continue;
            }


            i += 32;
            var arrayIndex = 0;

            for (var j = 0; j < Letters.SizeOneLetter; j++)
            {
                if (MemoryEmulation.GetBit(i)) break;

                var x = MemoryEmulation.Get32Bits(i).ToInt32();
                var y = MemoryEmulation.Get32Bits(i + 32).ToInt32();
                letterArray[arrayIndex] = new Vector2i(x, y);
                arrayIndex++;
                i += 64;
            }

            return true;
        }

        return false;
    }

    private void ReduceInputIp(int i, int quantity32)
    {
        Registers.Eax = i.ToBitArray();
        Registers.Ebx = BitAlgebra.ThirtyTwo;
        for (var j = 0; j < quantity32; j++) BitAlgebra.Reduce();

        Registers.InputIp = (BitArray)Registers.Eax.Clone();
    }

    private void ClearPosition()
    {
        _position.Y = DEFAULT_Y_POSITION;
        _position.X = DEFAULT_X_POSITION;
    }

    private void GotoNewLine()
    {
        _position.Y += LETTER_Y_OFFSET;
        _position.X = DEFAULT_X_POSITION;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Global
    public void OnWindowKeyReleased(object? sender, KeyEventArgs e)
    {
    }
}