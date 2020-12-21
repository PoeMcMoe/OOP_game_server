using OOP_rest_web_service.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class CenterGenerator
    {
		private GeneratorState currentState;
		public Color color;
		public Point position;
		public int generatingObjectType;

		public CenterGenerator()
		{
			this.position = new Point(800,500);
			this.color = Color.Yellow;

			GeneratorState charging = new ChargingState();
			GeneratorState friendly = new FriendlyState();
			GeneratorState angry = new AngryState();
			GeneratorState neutral = new NeutralState();

			charging.setNextStateRandom(friendly, angry, neutral);
			friendly.setNextState(charging);
			angry.setNextState(charging);
			neutral.setNextState(charging);

			currentState = charging;
		}

		public void operate()
		{
			currentState.getNextState(this);
			currentState.Handle(this);
		}

		//nustatome sekancia busena
		public void setState(GeneratorState nextState)
		{
			this.currentState = nextState;
		}

	}
}
