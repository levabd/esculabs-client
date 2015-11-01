using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleFramework
{
    using System.Windows;
    using System.Windows.Controls;

    public interface IModuleProvider
    {
        string Name { get; }

       // FrameworkElement GetWidget(IPatient patient);
    }
}
