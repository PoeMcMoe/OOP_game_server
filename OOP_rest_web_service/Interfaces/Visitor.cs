using OOP_rest_web_service.Models;
using OOP_rest_web_service.Models.TemplateStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Interfaces
{
    interface Visitor
    {
        void Visit(Food item);
        void Visit(ConfuseFood item);
        void Visit(ShieldFood item);
        void Visit(SizeDownFood item);
        void Visit(SizeUpFood item);

    }
}
