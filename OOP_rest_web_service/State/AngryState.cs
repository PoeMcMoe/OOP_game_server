using OOP_rest_web_service.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.State
{
    public class AngryState : GeneratorState
    {
        public override void Handle(CenterGenerator context)
        {
            Console.WriteLine("context.color = red");
            context.color = Color.Red;
            Console.WriteLine("context.generatingObject = bad stuff");
            context.generatingObjectType = 3;
        }
    }
}
