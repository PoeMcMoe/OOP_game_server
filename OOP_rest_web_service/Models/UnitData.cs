using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class UnitData
    {
        public Point position { get; set; }
        // 0 - player, 1 - food
        public int type { get; set; }
        public Color playerColor { get; set; }
        public Size playerSize { get; set; }
    }
}
