using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using OOP_rest_web_service.Interfaces;
using System.Diagnostics;
using OOP_rest_web_service.Models.Memento;

namespace OOP_rest_web_service.Models
{
    public class Player : AbstractPlayer, IMyObserver
    {
        private PlayerState playerState;
        public Player(Point position, Color color, Size size, PlayerState newState) : base(position, color, size)
        {
            playerState = newState;
        }

        public void RestoreState(Memento.Memento memento)
        {
            memento.GetState(this);
        }

        public PlayerState GetState()
        {
            return playerState;
        }

        public void SetState(PlayerState newState)
        {
            playerState = newState;
        }

        public Memento.Memento SaveState()
        {
            return new Memento.Memento(playerState);
        }

        public override Color getColor()
        {
            return base.color;
        }
        public override Size getSize()
        {
            return base.size;
        }

        public override void setColor(Color color)
        {
            base.color = color;
        }
        public override void setSize(Size size)
        {
            base.size = size;
        }

        public override bool Equals(Unit other)
        {
            if(other is Player)
            {
                Player b = (Player)other;
                if(this.position == b.getPosition() && this.color == b.getColor() && this.size == b.getSize())
                {
                    return true;
                }
            }
            return false;
        }

        public override void update()
        {
            base.update();
        }

        public override void setFoodListChangedFalse()
        {
            base.setFoodListChangedFalse();
        }

        public override bool getFoodListChanged()
        {
            return base.getFoodListChanged();
        }

        public override void setConfused(bool confused)
        {
            base.confused = confused;
        }

        public override Point getPosition()
        {
            return base.getPosition();
        }

        public override void setPosition(Point position)
        {
            base.setPosition(position);
        }

        public override void setName(string name)
        {
            base.setName(name);
        }

        public override string getName()
        {
            return base.getName();
        }
    }
}
