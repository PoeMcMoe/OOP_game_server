using OOP_rest_web_service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class CommandInvoker
    {
        ICommand slot;
        public CommandInvoker() { }
        public void SetCommand(ICommand command)
        {
            slot = command;
        }
        public void ExecuteCommand()
        {
            slot.Execute();
        }

        public void UndoCommand()
        {
            slot.Undo();
        }

        public bool CommandExists()
        {
            return slot != null;
        }

    }
}
