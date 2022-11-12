using CpuEmulation.Cpu.Memory;
using SFML.System;

namespace CpuEmulation.Graphics;

public static class Letters
{
    public const int SizeOneLetter = 120;

    private static readonly Vector2i[] _aPositions =
    {
        new(1, 1),
        new(1, 0),
        new(2, 0),
        new(3, 0),
        new(4, 0),
        new(5, 0),
        new(6, 0),

        new(7, 1),
        new(8, 2),
        new(8, 3),
        new(8, 4),
        new(8, 5),
        new(8, 6),
        new(8, 7),
        new(8, 8),
        new(8, 9),
        new(8, 10),
        new(8, 11),
        new(8, 12),

        new(7, 11),
        new(6, 12),
        new(5, 12),
        new(4, 12),
        new(3, 12),
        new(2, 12),
        new(1, 12),

        new(0, 11),
        new(0, 10),
        new(0, 9),
        new(0, 8),
        new(0, 7),
        new(0, 6),

        new(1, 5),
        new(2, 5),
        new(3, 5),
        new(4, 5),
        new(5, 5),
        new(6, 6),
        new(7, 6)
    };

    private static readonly Vector2i[] _bPositions =
    {
        new(0, 0),
        new(0, 1),
        new(0, 2),
        new(0, 3),
        new(0, 4),
        new(0, 5),
        new(0, 6),
        new(0, 7),
        new(0, 8),
        new(0, 9),
        new(0, 10),
        new(0, 11),
        new(0, 12),

        new(1, 5),
        new(2, 4),
        new(3, 4),
        new(4, 4),
        new(5, 4),
        new(6, 4),
        new(7, 5),

        new(8, 6),
        new(8, 7),
        new(8, 8),
        new(8, 9),
        new(8, 10),

        new(7, 11),
        new(6, 12),
        new(5, 12),
        new(4, 12),
        new(3, 12),
        new(2, 12),
        new(1, 12)
    };

    private static readonly Vector2i[] _cPositions =
    {
        new(0, 3),
        new(1, 2),
        new(2, 1),
        new(3, 0),
        new(4, 0),
        new(5, 0),
        new(6, 0),
        new(7, 1),
        new(8, 2),

        new(0, 4),
        new(0, 5),
        new(0, 6),
        new(0, 7),
        new(0, 8),
        new(0, 9),

        new(0, 10),
        new(1, 11),
        new(2, 12),
        new(3, 12),
        new(4, 12),
        new(5, 12),
        new(6, 12),
        new(7, 11),
        new(8, 10)
    };

    private static readonly Vector2i[] _dPositions =
    {
        new(0, 0),
        new(0, 1),
        new(0, 2),
        new(0, 3),
        new(0, 4),
        new(0, 5),
        new(0, 6),
        new(0, 7),
        new(0, 8),
        new(0, 9),
        new(0, 10),
        new(0, 11),
        new(0, 12),


        new(1, 0),
        new(2, 0),
        new(3, 0),

        new(4, 1),
        new(5, 1),

        new(6, 2),
        new(7, 2),


        new(8, 3),
        new(8, 4),
        new(8, 5),
        new(8, 6),
        new(8, 7),
        new(8, 8),


        new(7, 9),
        new(6, 10),

        new(5, 11),
        new(4, 11),

        new(3, 12),
        new(2, 12),
        new(1, 12)
    };

    private static readonly Vector2i[] _ePositions =
    {
        new(0, 0),
        new(0, 1),
        new(0, 2),
        new(0, 3),
        new(0, 4),
        new(0, 5),
        new(0, 6),
        new(0, 7),
        new(0, 8),
        new(0, 9),
        new(0, 10),
        new(0, 11),
        new(0, 12),

        new(0, 0),
        new(1, 0),
        new(2, 0),
        new(3, 0),
        new(4, 0),
        new(5, 0),
        new(6, 0),
        new(7, 0),

        new(0, 6),
        new(1, 6),
        new(2, 6),
        new(3, 6),
        new(4, 6),
        new(5, 6),
        new(6, 6),
        new(7, 6),

        new(0, 12),
        new(1, 12),
        new(2, 12),
        new(3, 12),
        new(4, 12),
        new(5, 12),
        new(6, 12),
        new(7, 12)
    };

    private static readonly Vector2i[] _fPositions =
    {
        new(0, 0),
        new(0, 1),
        new(0, 2),
        new(0, 3),
        new(0, 4),
        new(0, 5),
        new(0, 6),
        new(0, 7),
        new(0, 8),
        new(0, 9),
        new(0, 10),
        new(0, 11),
        new(0, 12),

        new(0, 0),
        new(1, 0),
        new(2, 0),
        new(3, 0),
        new(4, 0),
        new(5, 0),
        new(6, 0),
        new(7, 0),

        new(0, 6),
        new(1, 6),
        new(2, 6),
        new(3, 6),
        new(4, 6),
        new(5, 6),
        new(6, 6),
        new(7, 6)
    };

    private static readonly Vector2i[] _gPositions =
    {
        new(8, 3),
        new(8, 3),
        new(7, 3),
        new(7, 2),
        new(6, 1),
        new(6, 1),
        new(5, 1),
        new(4, 1),
        new(3, 1),
        new(2, 2),
        new(1, 2),

        new(0, 3),
        new(0, 4),
        new(0, 5),
        new(0, 6),
        new(0, 7),
        new(0, 8),
        new(0, 9),
        new(0, 10),

        new(1, 11),
        new(2, 11),
        new(3, 12),
        new(4, 12),
        new(5, 12),
        new(6, 11),
        new(7, 11),
        new(8, 10),
        new(8, 9),
        new(8, 8),

        new(7, 8),
        new(6, 8),
        new(5, 8),
        new(4, 8)
    };

    private static readonly Vector2i[] _questionPositions =
    {
        new(0, 2),
        new(1, 1),
        new(2, 1),
        new(3, 1),
        new(4, 1),
        new(5, 1),
        new(6, 1),
        new(7, 1),
        new(8, 2),
        new(8, 3),
        new(8, 4),

        new(7, 5),
        new(5, 6),
        new(4, 7),
        new(3, 8),
        new(4, 9),
        new(4, 10),

        new(4, 12)
    };

    private static readonly Vector2i[] _spacePositions = { };
    private static readonly Vector2i[] _filledSpacePositions = new Vector2i[SizeOneLetter];

    private static readonly IReadOnlyDictionary<int, Vector2i[]> _defaultLetters =
        new Dictionary<int, Vector2i[]>
        {
            { 0, _aPositions },
            { 1, _bPositions },
            { 2, _cPositions },
            { 3, _dPositions },
            { 4, _ePositions },
            { 5, _fPositions },
            { 6, _gPositions },
            { 52, _questionPositions },
            { 57, _spacePositions },
            { 1000, _filledSpacePositions }
        };

    private static int _point = MemoryEmulationConstants.LettersRamOffset;

    /// <summary>
    ///     Sets arrays of letters in letters Memory
    /// </summary>
    public static void SetLettersToLettersMemory()
    {
        SetLettersArray();

        // size one vector - 64 bit
        // size one letter - 49 vectors + 1 index (32 bits) 
        // size of all 128 letters = 396 kilobytes! that's terrible
        foreach (var letter in _defaultLetters)
            SetLetterToRam(letter.Value, letter.Key);
    }

    /// <summary>
    ///     Sets values for some letters
    /// </summary>
    private static void SetLettersArray()
    {
        var y = 0;
        for (var i = 0; i < SizeOneLetter; i++)
        {
            // ReSharper disable once PossibleLossOfFraction
            var x = i % 9;
            if (i != 0 && i % 9 == 0) y++;

            _filledSpacePositions[i] = new Vector2i(x, y);
        }
    }

    private static void SetLetterToRam(IReadOnlyList<Vector2i> letter, int index)
    {
        MemoryEmulation.Set32Bits(index.ToBitArray(), _point);
        _point += 32;
        for (var i = 0; i < SizeOneLetter; i++)
            if (i >= letter.Count)
            {
                _point += 64;
            }
            else
            {
                var position = letter[i];
                MemoryEmulation.Set32Bits(position.X.ToBitArray(), _point);
                _point += 32;
                MemoryEmulation.Set32Bits(position.Y.ToBitArray(), _point);
                _point += 32;
            }
    }
}