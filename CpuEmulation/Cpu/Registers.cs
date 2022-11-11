using System.Collections;
using CpuEmulation.Cpu.Memory;

namespace CpuEmulation.Cpu;

/// <summary>
///     Registers intended for use by the Cpu. NOT FOR APPS
/// </summary>
public static class Registers
{
    public const int RegisterLength = 32;

    // General purpose
    public static BitArray Eax = new(RegisterLength);
    public static BitArray Ebx = new(RegisterLength);

    // Indicating registers
    public static BitArray InputIp;
    public static BitArray CpuIp = new(RegisterLength);

    static Registers()
    {
        InputIp = MemoryEmulationConstants.InputRamOffset.ToBitArray();
    }
}