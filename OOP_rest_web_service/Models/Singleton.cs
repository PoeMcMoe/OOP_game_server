using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class Singleton
    {
        private static Singleton instance = new Singleton();
        private Singleton()
        {
            Console.WriteLine("Singleton initialized");
        }
        public static Singleton getInstance()
        {
            Console.WriteLine("Returning instance");
            return instance;
        }
    }
}
