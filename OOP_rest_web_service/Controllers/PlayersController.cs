using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OOP_rest_web_service.Models;

namespace OOP_rest_web_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {
        static List<Player> playersList = new List<Player>();

        // GET api/players
        [HttpGet]
        public JsonResult Get()
        {
            return Json(playersList);
        }

        // GET api/players/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Player player = playersList.Single(x => x.Id.Equals(id));
            return Json(player);
        }

        // POST api/players
        [HttpPost]
        public void Post(Player player)
        {
            playersList.Add(player);
        }

        // PUT api/players/5
        [HttpPut("{id}")]
        public void Put(int id, Player player)
        {
            //Gauna playerio indeksa ir pakeicia nauju

           playersList[playersList.IndexOf(playersList.Single(x => x.Id.Equals(id)))] = player;

        }

        // DELETE api/players/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            playersList.Remove(playersList.Single(x => x.Id.Equals(id)));
        }
    }
}
