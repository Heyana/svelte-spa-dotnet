namespace csharp_src.ui;
public class WebView : Microsoft.Web.WebView2.WinForms.WebView2
{
    public WebView() : base()
    {
        this.DefaultBackgroundColor = AppConfig.BackgroundColor;
        this.BackColor = AppConfig.BackgroundColor;
        this.Dock = DockStyle.Fill;
        this.DoubleBuffered = true;
    }
}