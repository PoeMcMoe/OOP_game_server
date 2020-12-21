using OOP_rest_web_service.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.State
{
    public class FriendlyState : GeneratorState
    {
        public override void Handle(CenterGenerator context)
        {
            Console.WriteLine("context.color = green");
            context.color = Color.Green;
            Console.WriteLine("context.generatingObject = good stuff");
            context.generatingObjectType = 2;
        }
    }
}
