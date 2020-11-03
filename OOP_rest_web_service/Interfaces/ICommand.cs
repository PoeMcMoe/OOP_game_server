using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Interfaces
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
