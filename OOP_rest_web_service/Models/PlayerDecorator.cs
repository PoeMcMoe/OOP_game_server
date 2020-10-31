using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class PlayerDecorator : AbstractPlayer
    {
        protected AbstractPlayer wrappee;

        public PlayerDecorator(AbstractPlayer player)
        {
            this.wrappee = player;
        }

        public override bool Equals(Unit other)
        {
            throw new NotImplementedException();
        }

        public AbstractPlayer getWrappee()
        {
            return wrappee;
        }

        public void setWrappee(AbstractPlayer wrappee)
        {
            this.wrappee = wrappee;
        }
    }
}
