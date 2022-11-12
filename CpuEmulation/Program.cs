using System.Runtime;
using CpuEmulation.Graphics;

namespace CpuEmulation;

public static class Program
{
    private static void Main()
    {
        OptimizeApplication();
        MainInternal();
    }

    /// <summary>
    ///     Sets the current thread to the highest priority, starts the Jit compiler profile
    /// </summary>
    private static void OptimizeApplication()
    {
        const string mainProfileName = "MainProfile";

        Thread.CurrentThread.Priority = ThreadPriority.Highest;
        ProfileOptimization.SetProfileRoot(Directory.GetCurrentDirectory());
        ProfileOptimization.StartProfile(mainProfileName);
    }

    private static void MainInternal()
    {
        Letters.SetLettersToLettersMemory();
        CpuConsole.Start();
    }
}