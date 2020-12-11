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
        // GET: api/Game
        //Gets everything
        [HttpGet]
        public List<UnitData> Get()
        {
            //Debug.WriteLine("DEBUGINAM: ");

            /*List<UnitData> list = new List<UnitData>();
            foreach (Unit f in Map.getInstance().getFood())
            {
                list.Add(new UnitData { position = f.getPosition(), type = f.getType() });
            }
            
            for (int i = 0; i < Map.getInstance().getPlayers().Count; i++)
            {
                AbstractPlayer p = (AbstractPlayer)Map.getInstance().getPlayers()[i];
                list.Add(new UnitData { position = p.getPosition(), type = 0, playerColor = p.getColor(), playerSize = p.getSize(), confused = p.isConfused() });
            }
            */
            List<UnitData> list = new List<UnitData>();
            foreach(Unit u in Map.getInstance().getUnits())
            {
                if(u.getType() == 0)
                {
                    AbstractPlayer p = (AbstractPlayer)u;
                    list.Add(new UnitData { position = p.getPosition(), type = 0, playerColor = p.getColor(), playerSize = p.getSize(), confused = p.isConfused() });
                }
                else
                {
                    list.Add(new UnitData { position = u.getPosition(), type = u.getType() });
                }
            }
            return list;
        }

        [Route("players")]
        [HttpGet]
        public List<UnitData> GetPlayers()
        {
            List<UnitData> list = new List<UnitData>();
            for (int i = 0; i < Map.getInstance().getPlayers().Count; i++)
            {
                AbstractPlayer p = (AbstractPlayer)Map.getInstance().getPlayers()[i];
                list.Add(new UnitData { position = p.getPosition(), type = 0, playerColor = p.getColor(), playerSize = p.getSize(), confused = p.isConfused(), foodListChanged = p.getFoodListChanged() });
            }

            return list;
        }

        [Route("food")]
        [HttpGet]
        public List<UnitData> GetFood()
        {
            List<UnitData> list = new List<UnitData>();
            foreach (Unit f in Map.getInstance().getFood())
            {
                list.Add(new UnitData { position = f.getPosition(), type = f.getType() });
            }
            return list;
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Game/rewind
        [Route("rewind/{colorname}/{command}")]
        [HttpGet]
        public void Rewind(string command, string colorname)
        {
            Color playerColor = Color.FromName(colorname);
            int index = Startup.allColors.IndexOf(playerColor);
            Player player = (Player)Map.getInstance().getPlayers()[index];
            if(command == "set")
            {
                RewindCommand rew = new RewindCommand(player);
                Startup.commandInvoker.SetCommand(rew);
                Startup.commandInvoker.ExecuteCommand();
            }
            if (command == "trigger" && Startup.commandInvoker.CommandExists())
            { 
                Startup.commandInvoker.UndoCommand();
            }
        }

        // POST: api/Game
        [HttpPost]
        public void Post([FromBody]string unit)
        {
            UnitData un = JsonConvert.DeserializeObject<UnitData>(unit);
            if(un.position.X == -9999 && un.position.Y == -9999)
            {
                un.playerColor = ChooseColor();
            }

            if (un.playerColor == Color.White) { return; }

            int index = Startup.allColors.IndexOf(un.playerColor);

            AbstractPlayer mapUnit = (AbstractPlayer)UnitCreator.createUnit(0);
            mapUnit.setPosition(un.position);
            mapUnit.setColor(un.playerColor);
            mapUnit.setConfused(false);

            AbstractPlayer playerFromMap = (AbstractPlayer)Map.getInstance().getPlayers()[index];
            mapUnit.setSize(playerFromMap.getSize());

            Startup.lastPosts[GetIndex(mapUnit.getColor())] = DateTime.Now;

            if (Map.getInstance().GetPlayer(index).getColor() != Color.White)
            {
                AbstractPlayer player = (AbstractPlayer)Map.getInstance().getPlayers()[index];
                player.setPosition(mapUnit.getPosition());
                player.setConfused(false);
                player.setFoodListChangedFalse();

                Map.getInstance().setPlayer(index, player);
            }
            else
            {
                mapUnit.setSize(new Size(20, 20));
                Map.getInstance().register(mapUnit);
                Map.getInstance().setPlayer(GetIndex(mapUnit.getColor()), mapUnit);
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
                if(Map.getInstance().getPlayers().Cast<Player>().Any(x =>  x.getColor() != checkingColor))
                {
                    playerColor = checkingColor;
                }

            }

            return playerColor;
        }
    }
}
