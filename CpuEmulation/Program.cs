using System.Runtime;
using CpuEmulation.Graphics;

namespace CpuEmulation;

public static class Program
{
    private static void Main()
    {
        OptimizeApplication();
        PrepareStaticClasses();
        MainInternal();
    }

    private static void PrepareStaticClasses()
    {
        Letters.Init();
    }

    private static void OptimizeApplication()
    {
        Thread.CurrentThread.Priority = ThreadPriority.Highest;
        ProfileOptimization.SetProfileRoot(Directory.GetCurrentDirectory());
        ProfileOptimization.StartProfile("MainProfile");
    }

    private static void MainInternal()
    {
        CpuConsole.Run();
    }
}