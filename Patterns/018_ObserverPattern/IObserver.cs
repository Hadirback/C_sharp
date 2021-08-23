using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018_ObserverPattern
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
