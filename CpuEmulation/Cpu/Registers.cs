using System.Collections;
using CpuEmulation.Cpu.Memory;

namespace CpuEmulation.Cpu;

public static class Registers
{
    public const int REGISTER_LENGTH = 32;

    // General purpose
    public static BitArray Eax = new(REGISTER_LENGTH); // eax -> ax -> (ah, al)
    public static BitArray Ebx = new(REGISTER_LENGTH); // ebx -> bx -> (bh, bl)

    // Indicating registers
    public static BitArray InputIp = new(REGISTER_LENGTH); // console

    static Registers()
    {
        Eax.SetAll(false);
        Ebx.SetAll(false);
        InputIp.SetAll(false);
        InputIp = MemoryConstants.INPUT_RAM_OFFSET.ToBitArray();
    }
}