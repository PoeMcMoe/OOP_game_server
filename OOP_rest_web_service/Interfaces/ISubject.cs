using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Interfaces
{
    interface ISubject
    {
        void register(IMyObserver o);
        void unregister(IMyObserver o);
        void notifyObservers();
    }
}
