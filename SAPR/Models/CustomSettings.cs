using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SAPR.Models
{
    internal static class CustomSettings
    {

        public class Cols : ProfessionalColorTable
        {
            public override Color MenuItemPressedGradientBegin
            {
                get { return Properties.Settings.Default.BackgroundColor; }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Properties.Settings.Default.BackgroundColor; }
            }

        };
        public static Binding TextColorBinding => new Binding("ForeColor", Properties.Settings.Default, "TextColor");
        public static Binding BackColorBinding => new Binding("BackColor", Properties.Settings.Default, "BackgroundColor");
    }
}
