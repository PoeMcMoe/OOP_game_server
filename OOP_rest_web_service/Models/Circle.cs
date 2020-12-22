using OOP_rest_web_service.Mediator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class Circle : Colleague
    {
        public Color color;
        public Point position;

		public Circle(IMediator mediator) : base(mediator)
		{
			this.position = new Point(1400, 500);
			this.color = Color.DarkGoldenrod;
			m = mediator;
		}

        public override ColleagueType getType()
        {
            return ColleagueType.circle;
        }

        public override void receiveSignal(string msg)
        {
            Console.WriteLine("CIRCLE : received" + msg);
        }

        public override void sendSignal(string msg)
        {
            m.broadcastMessage(this, msg);
        }
    }
}
