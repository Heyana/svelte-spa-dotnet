namespace csharp_src;

static class Program
{
    public static bool IsDebug
    {
        get
        {
            #if DEBUG
            return true;
            #else
            return false;
            #endif
        }
    }

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}