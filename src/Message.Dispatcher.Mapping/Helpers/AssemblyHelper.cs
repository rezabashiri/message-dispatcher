using System.Reflection;

namespace Message.Dispatcher.Mapping.Helpers;

public static class AssemblyHelper
{
    public static Assembly GetApplicationLayerAssembly() => Assembly.GetAssembly(typeof(AssemblyHelper));
}