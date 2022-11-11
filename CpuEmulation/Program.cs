using System.Collections;
using System.Runtime;
using CpuEmulation.Cpu;
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
        const string mainProfileName = "MainProfile";

        Thread.CurrentThread.Priority = ThreadPriority.Highest;
        ProfileOptimization.SetProfileRoot(Directory.GetCurrentDirectory());
        ProfileOptimization.StartProfile(mainProfileName);
    }

    private static void MainInternal()
    {
        CpuConsole.Run();
    }
}