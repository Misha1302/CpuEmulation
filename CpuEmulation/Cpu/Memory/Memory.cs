using System.Collections;
using static CpuEmulation.Cpu.Memory.MemoryEmulationConstants;

namespace CpuEmulation.Cpu.Memory;

public static class MemoryEmulation
{
    private static readonly BitArray _ramArray;

    static MemoryEmulation()
    {
        _ramArray = new BitArray(VramSize + RamSize + InputRamSize + LettersRamSize);
        _ramArray.SetAll(false);


        for (var i = InputRamOffset; i < InputRamOffset + InputRamSize; i += 32)
            _ramArray[i] = true;

        for (var i = LettersRamOffset; i < LettersRamOffset + LettersRamSize; i += 32)
            _ramArray[i] = true;
    }


    #region SetBits

    /// <summary>
    ///     Sets 32 bits (int) to memory
    /// </summary>
    /// <param name="range">32 bits (int)</param>
    /// <param name="startAddress">address to start writing to RAM</param>
    public static void Set32Bits(BitArray range, int startAddress)
    {
        _ramArray.SetRange(range, startAddress, startAddress + 32);
    }

    /// <summary>
    ///     Sets a bit in memory at a given address
    /// </summary>
    /// <param name="value">bit</param>
    /// <param name="address">address to set</param>
    public static void SetBit(bool value, int address)
    {
        _ramArray[address] = value;
    }

    #endregion


    #region GetBits

    /// <summary>
    ///     Gets 32 bits (int) from memory
    /// </summary>
    /// <param name="startAddress">Address to receive 32 bits (int)</param>
    /// <returns>32 bit (bit)</returns>
    public static BitArray Get32Bits(int startAddress)
    {
        return _ramArray.GetRange(startAddress, startAddress + 32);
    }

    /// <summary>
    ///     Gets one bit (bool) from memory
    /// </summary>
    /// <param name="address">Address to receive bit</param>
    /// <returns>bit (bool)</returns>
    public static bool GetBit(int address)
    {
        return _ramArray[address];
    }

    #endregion
}