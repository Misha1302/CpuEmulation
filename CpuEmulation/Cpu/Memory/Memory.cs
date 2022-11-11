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


        for (var i = InputRamOffset; i < InputRamOffset + InputRamSize; i += 32) _ramArray[i] = true;

        for (var i = LettersRamOffset; i < LettersRamOffset + LettersRamSize; i += 32) _ramArray[i] = true;
    }

    public static void ClearVRam()
    {
        var a = new BitArray(VramSize);
        for (var i = VramOffset; i < VramOffset + VramSize; i += 32) Set32Bits(a, i);
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////


    #region SetBits

    public static void Set32Bits(BitArray range, int startAddress)
    {
        _ramArray.SetRange(range, startAddress, startAddress + 32);
    }

    private static void SetRange(BitArray range, int startAddress, int count)
    {
        _ramArray.SetRange(range, startAddress, startAddress + count);
    }

    public static void SetBit(bool value, int address)
    {
        _ramArray[address] = value;
    }

    #endregion


    ///////////////////////////////////////////////////////////////////////////////////////////////////////


    #region GetBits

    public static BitArray Get32Bits(int startAddress)
    {
        return GetRange(startAddress, 32);
    }

    public static bool GetBit(int address)
    {
        return _ramArray[address];
    }

    private static BitArray GetRange(int startAddress, int count)
    {
        return _ramArray.GetRange(startAddress, startAddress + count);
    }

    #endregion
}