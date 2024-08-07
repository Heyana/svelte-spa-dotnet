using csharp_src.utils;

namespace csharp_src.ui;
public class WebForm : Form
{
    private WebView webView = new();

    public WebForm()
    {
        InitializeComponent();
        InitializeWebView();
    }

    private void InitializeComponent()
    {
        ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
        SuspendLayout();

        ClientSize = new Size(800, 450);

        Controls.Add(webView);

        this.DoubleBuffered = true;
        this.BackColor = AppConfig.BackgroundColor;
        this.Name = "MainForm";

        this.Text = AppConfig.AppWindowTitle;
        this.Icon = AppConfig.AppIcon;

        ((System.ComponentModel.ISupportInitialize)webView).EndInit();
        this.ResumeLayout(false);
    }

    private async void InitializeWebView()
    {
        var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(null, AppConfig.UserDataFolder);
        await webView.EnsureCoreWebView2Async(env);

        webView.CoreWebView2.AddHostObjectToScript("nativeMethods", new NativeMethods());
        //webView.CoreWebView2.Settings.AreDevToolsEnabled = Program.IsDebug;
        //webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = Program.IsDebug;

        string svelteKitPath = Program.IsDebug ? AppConfig.DevServerURL : AppConfig.ProdServerURL;
        webView.Source = new Uri(svelteKitPath);
    }
}