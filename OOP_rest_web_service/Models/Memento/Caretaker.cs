using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Memento
{
    public class Caretaker
    {
        private List<Memento> stateList;

        public Caretaker()
        {
            stateList = new List<Memento>();
        }

        public void Add(Memento state)
        {
            stateList.Add(state);
        }

        public Memento Get(int index)
        {
            Memento restoreState = stateList.ElementAt(index);
            stateList.RemoveAt(index);
            return restoreState;
        }
	
        public int Size()
        {
            return stateList.Count();
        }
    }
}
