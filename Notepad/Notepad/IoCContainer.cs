using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class IoCContainer
    {
        private Dictionary<Type, Type> _dict = new Dictionary<Type, Type>();

        public void Register<TInterface, TImplementation>()
        {
            _dict[typeof(TInterface)] = typeof(TImplementation);
        }

        public TInterface Create<TInterface>()
        {
            var imp = _dict[typeof(TInterface)];
            return (TInterface)Activator.CreateInstance(imp);
        }
    }
}
