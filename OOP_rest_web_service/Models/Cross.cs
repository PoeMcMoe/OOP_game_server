using OOP_rest_web_service.Mediator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class Cross : Colleague
    {
        public Color color;
        public Point position;

        public Cross(IMediator mediator) : base(mediator)
        {
            this.position = new Point(200, 500);
            this.color = Color.DarkGoldenrod;
            m = mediator;
        }

        public override ColleagueType getType()
        {
            return ColleagueType.cross;
        }

        public override void receiveSignal(string msg)
        {
            Console.WriteLine("CROSS : received" + msg);
        }

        public override void sendSignal(string msg)
        {
            m.broadcastMessage(this, msg);
        }
    }
}
