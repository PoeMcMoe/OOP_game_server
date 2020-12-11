using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Memento
{
    public class PlayerState
    {
        public Point position { get; set; }
        public Size size { get; set; }
        public Color color { get; set; }
        public string name { get; set; }
    }
}
