using CpuEmulation.Graphics;

namespace CpuEmulation.Cpu.Memory;

public static class MemoryConstants
{
    public const int BYTE_SIZE = 8;
    public const int KILOBYTE_SIZE = BYTE_SIZE * 1024;

    public const int RAM_SIZE = 0; // temporarily not needed
    public const int VRAM_SIZE = CpuConsole.COUNT;
    public const int INPUT_RAM_SIZE = KILOBYTE_SIZE * 128;
    public const int LETTERS_RAM_SIZE = KILOBYTE_SIZE * 397;

    public const int RAM_OFFSET = 0;
    public const int VRAM_OFFSET = RAM_OFFSET + RAM_SIZE;
    public const int INPUT_RAM_OFFSET = VRAM_OFFSET + VRAM_SIZE;
    public const int LETTERS_RAM_OFFSET = INPUT_RAM_OFFSET + INPUT_RAM_SIZE;
}