using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{

    [JsonObject, Serializable]
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int score { get; set; }
    }
}
