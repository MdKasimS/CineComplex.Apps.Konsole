using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Classes.Base
{
    public abstract class ABaseSingleton<T> where T : class, new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        // Protected constructor to prevent direct instantiation.
        protected ABaseSingleton()
        {
            // Initialization code if necessary
        }

        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}
