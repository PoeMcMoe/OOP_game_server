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
    public class SimpleVisitor : Visitor
    {
        public void Visit(Food item)
        {
            item.setType(1);
            item.SetColor(Color.Black);
        }

        public void Visit(ConfuseFood item)
        {
            item.setType(1);
            item.SetColor(Color.Black);
        }

        public void Visit(ShieldFood item)
        {
            item.setType(1);
            item.SetColor(Color.Black);
        }

        public void Visit(SizeDownFood item)
        {
            item.setType(1);
            item.SetColor(Color.Black);
        }

        public void Visit(SizeUpFood item)
        {
            item.setType(1);
            item.SetColor(Color.Black);
        }
    }
}
