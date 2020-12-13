using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using OOP_rest_web_service.Interfaces;
using OOP_rest_web_service.Models.Memento;

namespace OOP_rest_web_service.Models
{
    public class RewindCommand : ICommand
    {
        Player player;
        Player prevState;
        public RewindCommand(Player player)
        {
            this.player = new Player(player.getPosition(), player.getColor(), player.getSize(), new PlayerState());
        }
        public void Execute()
        {
            prevState = new Player(player.getPosition(), player.getColor(), player.getSize(), new PlayerState());
        }

        public void Undo()
        {
            int index = Startup.allColors.IndexOf(prevState.getColor());
            Map.players[index] = prevState;
        }
    }
}
