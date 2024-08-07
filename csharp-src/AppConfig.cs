namespace csharp_src;
public class AppConfig
{
    public static readonly string AppWindowTitle = "Svelte SPA .NET";
    public static readonly Icon AppIcon = GetIcon();
    public static readonly string DevServerURL = "http://localhost:3005";
    public static readonly string ProdServerURL = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "index.html");
    public static readonly string UserDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), GetAssemblyName(), "WebView2UserData");
    public static readonly Color BackgroundColor = ColorTranslator.FromHtml("#111827");

    private static Icon GetIcon()
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        using Stream stream = assembly.GetManifestResourceStream("csharp_src.appIcon.ico");

        if (stream != null)
        {
            return new Icon(stream);
        }

        return null;
    }

    private static string GetAssemblyName()
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        return assembly.GetName().Name;
    }
}