using CpuEmulation.Cpu.Commands;
using CpuEmulation.Cpu.Memory;

namespace CpuEmulation.Cpu;

public static class Cpu
{
    private static readonly IReadOnlyDictionary<int, ICpuCommand> _commands = new Dictionary<int, ICpuCommand>();

    private static readonly List<int> _offsets = new();

    // ReSharper disable once FunctionNeverReturns
    static Cpu()
    {
        Task.Run(() =>
        {
            while (true)
                Run();
        });
    }

    /// <summary>
    ///     Starts executing instructions in RAM at the specified address.
    ///     Terminates the execution of the program, provided that the address bit is 1
    ///     (that is, the byte has become negative) <br />
    ///     The RAM at the specified address should contain the instruction number,
    ///     which will be executed on the next cycle
    /// </summary>
    /// <param name="offset">specifies the offset of commands from the start of ram</param>
    public static void Execute(int offset)
    {
        _offsets.Add(offset);
    }

    /// <summary>
    ///     Iterates over the offset list and calls the command at the index that their address is
    /// </summary>
    private static void Run()
    {
        foreach (var offset in _offsets)
        {
            if (!MemoryEmulation.GetBit(offset))
                _commands[offset].Execute(offset);
            RemoveApplication();
        }

        RemoveApplications();
    }

    /// <summary>
    ///     Removes all application addresses added to RAM
    /// </summary>
    private static void RemoveApplications()
    {
        const int start = MemoryEmulationConstants.LettersRamOffset;
        const int end = MemoryEmulationConstants.LettersRamSize + MemoryEmulationConstants.LettersRamOffset;

        for (var address = start; address < end; address += 32)
            if (!MemoryEmulation.Get32Bits(address).Identical(BitAlgebra.Null))
                _offsets.RemoveAt(MemoryEmulation.Get32Bits(address).ToInt32());

        Registers.CpuIp = BitAlgebra.Zero;
    }

    /// <summary>
    ///     Adds addresses of dead applications to RAM
    /// </summary>
    private static void RemoveApplication()
    {
        MemoryEmulation.Set32Bits(BitAlgebra.Null, Registers.CpuIp.ToInt32());

        Registers.Eax = Registers.CpuIp;
        Registers.Ebx = BitAlgebra.One;
        BitAlgebra.Add();
        Registers.CpuIp = Registers.Eax;
    }
}