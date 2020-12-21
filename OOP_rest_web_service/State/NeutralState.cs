using OOP_rest_web_service.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.State
{
    public class NeutralState : GeneratorState
    {
        public override void Handle(CenterGenerator context)
        {
            Console.WriteLine("context.color = gray");
            context.color = Color.Gray;
            Console.WriteLine("context.generatingObject = null");
            context.generatingObjectType = 1;
        }
    }
}
