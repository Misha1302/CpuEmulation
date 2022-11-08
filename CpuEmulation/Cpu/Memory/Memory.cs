using System.Collections;
using static CpuEmulation.Cpu.Memory.MemoryConstants;

namespace CpuEmulation.Cpu.Memory;

public static class Memory
{
    private static readonly BitArray _ramArray;

    static Memory()
    {
        _ramArray = new BitArray(VRAM_SIZE + RAM_SIZE + INPUT_RAM_SIZE + LETTERS_RAM_SIZE);
        _ramArray.SetAll(false);


        for (var i = INPUT_RAM_OFFSET; i < INPUT_RAM_OFFSET + INPUT_RAM_SIZE; i += 32)
        {
            _ramArray[i] = true;
        }

        for (var i = LETTERS_RAM_OFFSET; i < LETTERS_RAM_OFFSET + LETTERS_RAM_SIZE; i += 32)
        {
            _ramArray[i] = true;
        }
    }

    public static void ClearVRam()
    {
        var a = new BitArray(VRAM_SIZE);
        for (var i = VRAM_OFFSET; i < VRAM_OFFSET + VRAM_SIZE; i += 32)
        {
            Set32Bits(a, i);
        }
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////


    #region SetBits

    public static void Set32Bits(BitArray range, int startAddress)
    {
        _ramArray.SetRange(range, startAddress, startAddress + 32);
    }

    public static void SetByte(BitArray range, int startAddress)
    {
        _ramArray.SetRange(range, startAddress, startAddress + 8);
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

    public static BitArray GetByte(int startAddress)
    {
        return GetRange(startAddress, 8);
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