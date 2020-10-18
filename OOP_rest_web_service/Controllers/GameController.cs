using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOP_rest_web_service.Models;

namespace OOP_rest_web_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        static Map map = new Map();

        static List<string> listas = new List<string>();

        // GET: api/Game
        [HttpGet]
        public List<UnitData> Get()
        {
            List<UnitData> list = new List<UnitData>();
            foreach (Unit f in map.getFood()){
                list.Add(new UnitData { position = f.position, type = f.type });
            }

            foreach (Unit p in map.getPlayers())
            {
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
        public void Post(Unit unit)
        {
            if (map.getPlayers().Contains(unit))
            {
                int index = map.getPlayers().IndexOf(unit);
                map.setPlayer(index, unit);
            }
            else
            {
                map.addPlayer(unit);
            }
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
    }
}
