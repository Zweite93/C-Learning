using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Models
{
    public class Content
    {
        public virtual int ID { get; set; }
        public virtual string Text { get; set; }
        public virtual User User { get; set; }

        public Content()
        {

        }
    }
}
