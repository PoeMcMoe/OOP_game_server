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
        //Player prevState;
        private Caretaker stateCaretaker;
        public RewindCommand(Player player)
        {
            this.player = new Player(player.getPosition(), player.getColor(), player.getSize(), new PlayerState());
            stateCaretaker = new Caretaker();
        }
        public void Execute()
        {
            //prevState = new Player(player.getPosition(), player.getColor(), player.getSize(), new PlayerState());
            stateCaretaker.Add(new Memento.Memento(new PlayerState() {color = player.getColor(), 
                name = player.getName(), position = player.getPosition(), size = player.getSize()}));
        }

        public void Undo()
        {
            int index = Startup.allColors.IndexOf(player.getColor());

            //Map.players[index] = prevState;
            Memento.Memento memento = stateCaretaker.Get(0);
            PlayerState previousState = memento.GetState();
            Map.getInstance().setPlayer(index, new Player(previousState.position, previousState.color, previousState.size, new PlayerState()));
            //Map.players[index] = new Player(previousState.position, previousState.color, previousState.size, new PlayerState());
        }
    }
}
