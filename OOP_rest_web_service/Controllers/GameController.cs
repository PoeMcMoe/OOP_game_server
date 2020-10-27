using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OOP_rest_web_service.Models;

namespace OOP_rest_web_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public static Map map = new Map();

        static List<string> listas = new List<string>();

        // GET: api/Game
        [HttpGet]
        public List<UnitData> Get()
        {
            //Debug.WriteLine("DEBUGINAM: ");

            List <UnitData> list = new List<UnitData>();
            foreach (Unit f in map.getFood()){
                list.Add(new UnitData { position = f.position, type = f.type });
            }


            for (int i = 0; i < map.getPlayers().Count; i++)
            {
                Unit p = map.getPlayers()[i];
                list.Add(new UnitData { position = p.position, type = p.type, playerColor = p.playerColor, playerSize = p.playerSize });
            }
            return list;
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Game
        [HttpPost]
        public void Post([FromBody]string unit)
        {
            UnitData un = JsonConvert.DeserializeObject<UnitData>(unit);
            if(un.position.X == -9999 && un.position.Y == -9999)
            {
                un.playerColor = ChooseColor();
                Debug.WriteLine("If color: " + un.playerColor);

            }

            if (un.playerColor == Color.White) { return; }

            int index = Startup.allColors.IndexOf(un.playerColor);

            Debug.WriteLine("Index post: " + index + "   Color recieved: " + un.playerColor);

            Unit mapUnit = new Unit(un.position, un.playerColor, map.getPlayers()[index].getSize());

            Startup.lastPosts[GetIndex(mapUnit.playerColor)] = DateTime.Now;

            if (map.getPlayers()[index].getColor() != Color.White)
            {
                map.setPlayer(index, mapUnit);
            }
            else
            {
                if(mapUnit.getType() != 1)
                {
                    mapUnit.setSize(new Size(20, 20));
                    map.setPlayer(GetIndex(mapUnit.playerColor), mapUnit);
                }
            }
        }


        int GetIndex(Color color)
        {
            return Startup.allColors.IndexOf(color);
        }
        

        // PUT: api/Game/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        Color ChooseColor()
        {
            Color playerColor;

            Random rnd = new Random();

            while(playerColor == Color.Empty)
            {
                Color checkingColor = Startup.allColors[rnd.Next(0, Startup.allColors.Count - 1)];
                if(map.getPlayers().Any(x => x.getColor() != checkingColor))
                {
                    playerColor = checkingColor;
                }

            }

            return playerColor;
        }
    }
}
