using System.Runtime.InteropServices;

namespace csharp_src.utils;

[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]
public class NativeMethods
{
    public string Name { get; set; } = "Unknown";

    public void Greet(string name)
    {
        this.Name = name;
        MessageBox.Show($"Greeting {Name} from CSharp");
    }
}