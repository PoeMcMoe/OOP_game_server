using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Mediator
{
    public enum ColleagueType
    {
        generator,
        cross,
        circle
    }

    public abstract class Colleague
    {
        protected IMediator m;

        public Colleague(IMediator mediator)
        {
            m = mediator;
        }

        public abstract ColleagueType getType();
        public abstract void sendSignal(string msg);
        public abstract void receiveSignal(string msg);
    }
}
