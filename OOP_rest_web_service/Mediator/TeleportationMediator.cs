using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Mediator
{
    public class TeleportationMediator : IMediator
    {
        Colleague cross;
        Colleague circle;
        Colleague generator;

        public void broadcastMessage(Colleague sender, string msg)
        {
            if (sender.getType().Equals(ColleagueType.circle))
            {
                generator.receiveSignal(msg);
            }
            else
            if (sender.getType().Equals(ColleagueType.cross))
            {
                generator.receiveSignal(msg);
            }
            else
            if (sender.getType().Equals(ColleagueType.generator))
            {
                cross.receiveSignal(msg);
                circle.receiveSignal(msg);
            }
        }

        public void registerColleague(Colleague colleague)
        {
            if (colleague.getType().Equals(ColleagueType.circle))
            {
                circle = colleague;
            }
            else
            if (colleague.getType().Equals(ColleagueType.cross))
            {
                cross = colleague;
            }
            else
            if (colleague.getType().Equals(ColleagueType.generator))
            {
                generator = colleague;
            }
        }
    }
}
