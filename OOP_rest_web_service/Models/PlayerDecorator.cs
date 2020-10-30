using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class PlayerDecorator : AbstractPlayer
    {
        AbstractPlayer player;

        public PlayerDecorator(AbstractPlayer player)
        {
            this.player = player;
        }

        public override bool Equals(Unit other)
        {
            throw new NotImplementedException();
        }
    }
}
