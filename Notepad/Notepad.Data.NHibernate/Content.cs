using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace Notepad.Data.NHibernate
{
    public class Content
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual string Text { get; set; }

        public Content()
        {

        }
    }
}
