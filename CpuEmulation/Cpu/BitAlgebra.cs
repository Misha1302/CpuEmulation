namespace CpuEmulation.Cpu;

public static class BitAlgebra
{
    public static void Add()
    {
        var add = false;
        for (var i = Registers.REGISTER_LENGTH - 1; i > 0; i--)
        {
            switch (Registers.Eax[i])
            {
                case true when Registers.Ebx[i]:
                    Registers.Eax[i] = add;
                    add = true;
                    break;
                case false when !Registers.Ebx[i]:
                    Registers.Eax[i] = add;
                    add = false;
                    break;
                default:
                    Registers.Eax[i] = !add;
                    break;
            }
        }
    }

    public static void Reduce()
    {
        var reduce = false;
        for (var i = Registers.REGISTER_LENGTH - 1; i >= 0; i--)
        {
            var b = Registers.Ebx[i];
            switch (Registers.Eax[i])
            {
                case false when !b:
                    Registers.Eax[i] = reduce;
                    break;
                case false when b:
                    Registers.Eax[i] = !reduce;
                    reduce = true;
                    break;
                case true when !b:
                    Registers.Eax[i] = !reduce;
                    reduce = false;
                    break;
                case true when b:
                    Registers.Eax[i] = reduce;
                    break;
            }
        }
    }
}