using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class Settings
    {
        private const float DefaultFontSize = 11.0f;
        public float FontSize { get; set; }

        public Settings()
        {
            FontSize = DefaultFontSize;
        }

        public Settings(float fontSize)
        {
            FontSize = fontSize;
        }
    }
}
