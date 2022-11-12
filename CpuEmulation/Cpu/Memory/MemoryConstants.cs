using CpuEmulation.Graphics;

namespace CpuEmulation.Cpu.Memory;

public static class MemoryEmulationConstants
{
    public const int ByteSize = 8;
    public const int KilobyteSize = ByteSize * 1024;

    public const int RamSize = KilobyteSize * 64;
    public const int VramSize = CpuConsole.Count;
    public const int InputRamSize = KilobyteSize * 128;
    public const int LettersRamSize = KilobyteSize * 512;

    public const int RamOffset = 0;
    public const int VramOffset = RamOffset + RamSize;
    public const int InputRamOffset = VramOffset + VramSize;
    public const int LettersRamOffset = InputRamOffset + InputRamSize;
}