using NHibernate;
using NHibernate.Cfg;
using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Data.NHibernate
{
    public class DbSystemSaver : ITextSaver
    {
        private readonly ISession _session;

        public DbSystemSaver()
        {
            _session = NHibernateHelper.OpenSession();
        }

        public Result Save(bool isNew, Content content)
        {
            SaveToDb(content);
            return Result.Saved;
        }

        public Content Load()
        {
            return LoadFromDb();
        }
        
        private void SaveToDb(Content content)
        {
            using (_session.BeginTransaction())
            {
                var user = new User();
                user.Name = "UserName";
                user.Contents = new List<Content>();
                user.Contents.Add(new Content(){Text = "Text", User = user});
                _session.Save(user);
                _session.Transaction.Commit();
            }
        }

        private Content LoadFromDb()
        {
            var content = _session.Load<Content>(1);
            return content;
        }
    }
}
