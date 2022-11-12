namespace CpuEmulation.Cpu.Commands;

internal interface ICpuCommand
{
    /// <summary>
    ///     Causes the given command to be executed
    /// </summary>
    /// <param name="offset">program offset relative to the beginning of RAM</param>
    public void Execute(int offset);
}