using Microsoft.AspNetCore.Mvc;
using OOP_rest_web_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamController : Controller
    {

        static Map map;
        //Todo generate map and food +-
        //Player spawning +
        //Timer for food spawning -
        //Get req for map +
        //Post for player location +

        static public void GenerateMap()
        {
            map = new Map();
        }

        [HttpGet]
        public Map GetMap()
        {
            return map;
        }


        //Adds player and moves player
        [HttpPost]
        public void ManagePlayers(Unit unit)
        {
            if(map.getPlayers().Contains(unit))
            {
                int index = map.getPlayers().IndexOf(unit);
                map.setPlayer(index, unit);
            }
            else
            {
                map.addPlayer(unit);
            }
        }


    }
}
