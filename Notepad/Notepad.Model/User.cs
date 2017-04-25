using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Models
{
    public class User
    {
        public virtual int UserID { get; set; }
        public virtual string Name { get; set; }
        private IList<Content> _contents;
        public virtual IList<Content> Contents
        {
            get { return _contents ?? (_contents = new List<Content>()); }
            set { _contents = value; }
        }
    }
}
