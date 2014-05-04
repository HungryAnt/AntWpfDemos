using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Gods.Foundation
{
    public class CustomResources
    {
        public static ComponentResourceKey CustomWindowChromeKey
        {
            get { return new ComponentResourceKey(typeof (CustomResources), "CustomWindowChrome"); }
        }
    }
}
