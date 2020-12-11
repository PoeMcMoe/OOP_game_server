using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Memento
{
    public class Memento
    {
        private PlayerState playerState;

        public Memento(PlayerState newState)
        {
            playerState = newState;
        }

        public void GetState(Player org)
        {
            org.SetState(this.playerState);
        }

        public PlayerState GetState()
        {
            return playerState;
        }
    }
}
