using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Data.NHibernate
{
    public class DBSystemSaver : ITextSaver
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;
        private ISession _session;

        public DBSystemSaver()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _sessionFactory = _configuration.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();
        }

        public Result Save(bool isNew, string text)
        {
            using (_session.BeginTransaction())
            {
                Content content = new Content()
                {
                    Text = text
                };
                _session.Save(content);
                _session.Transaction.Commit();
                return Result.Saved;
            }

        }

        public string Load()
        {
            throw new NotImplementedException();
        }
    }
}
