using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo07
{
    class MySettings
    {
        static MySettings()
        {
            FontSize = 40;
        }

        public static int FontSize { get; set; }
    }
}
