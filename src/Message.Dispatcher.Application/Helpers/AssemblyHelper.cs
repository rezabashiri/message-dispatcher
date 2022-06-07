using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Message.Dispatcher.Application.Helpers;

public static class AssemblyHelper
{
    public static Assembly GetApplicationLayerAssembly() => Assembly.GetAssembly(typeof(AssemblyHelper));
}