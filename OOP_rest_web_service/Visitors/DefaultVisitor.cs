using OOP_rest_web_service.Interfaces;
using OOP_rest_web_service.Models;
using OOP_rest_web_service.Models.TemplateStuff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Visitors
{
    public class DefaultVisitor : Visitor
    {
        public void Visit(Food item)
        {
            item.color = Color.Aquamarine;
        }

        public void Visit(ConfuseFood item)
        {
            item.color = Color.Aquamarine;
        }

        public void Visit(ShieldFood item)
        {
            item.color = Color.Aquamarine;
        }

        public void Visit(SizeDownFood item)
        {
            item.color = Color.Aquamarine;
        }

        public void Visit(SizeUpFood item)
        {
            item.color = Color.Aquamarine;
        }
    }
}
