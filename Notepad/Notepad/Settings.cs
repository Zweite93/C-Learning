using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class Settings
    {
        public float FontSize { get; set; }

        public Settings(float fontSize)
        {
            FontSize = fontSize;
        }
    }
}
