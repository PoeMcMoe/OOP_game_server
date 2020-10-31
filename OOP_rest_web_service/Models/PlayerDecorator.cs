using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public abstract class PlayerDecorator : AbstractPlayer
    {
        protected AbstractPlayer wrappee;

        public PlayerDecorator(AbstractPlayer player) : base(player.getPosition(), player.getColor(), player.getSize())
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
