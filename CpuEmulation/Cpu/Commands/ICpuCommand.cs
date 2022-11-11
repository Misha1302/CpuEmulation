namespace CpuEmulation.Cpu.Commands;

internal interface ICpuCommand
{
    public void Execute(int offset);
}