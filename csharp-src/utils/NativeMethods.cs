namespace csharp_src.utils;
[System.Runtime.InteropServices.ComVisible(true)]
public class NativeMethods
{
    public void Greet(string name)
    {
        MessageBox.Show($"Greeting {name} from CSharp");
    }
}