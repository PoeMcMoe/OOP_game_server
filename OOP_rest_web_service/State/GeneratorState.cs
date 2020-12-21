using OOP_rest_web_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.State
{
    public abstract class GeneratorState
    {
		private GeneratorState nextState;
		private GeneratorState alt1;
		private GeneratorState alt2;

		public void setNextState(GeneratorState nextState)
		{
			this.nextState = nextState;
		}

		public void setNextStateRandom(GeneratorState s1, GeneratorState s2, GeneratorState s3)
		{
			nextState = s1;
			alt1 = s2;
			alt2 = s3;
		}

		public void getNextState(CenterGenerator context)
		{
			if (alt1 == null)
			{
				context.setState(nextState);
			}
			else
			{
				var r = new Random();
				switch (r.Next(1, 4))
				{
					case 1:
						context.setState(alt1);
						break;
					case 2:
						context.setState(alt2);
						break;
					case 3:
						context.setState(nextState);
						break;
					default:
						break;
				}
			}
		}

		public abstract void Handle(CenterGenerator context);
		// konkreti realizacija bus konkrecioje busenoje
	}
}
