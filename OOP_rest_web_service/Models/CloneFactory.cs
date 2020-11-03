using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class CloneFactory
    {
        public Unit getClone(Unit unitToClone)
        {
            return (Unit)unitToClone.Clone();
        }
    }
}
