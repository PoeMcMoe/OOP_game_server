using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Mediator
{
	public interface IMediator
	{
		void registerColleague(Colleague colleague);

		void broadcastMessage(Colleague sender, string msg);

	}
}
