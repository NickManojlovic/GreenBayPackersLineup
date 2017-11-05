
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft;
using Newtonsoft.Json;
using PackersLineup.Models;

namespace PackersLineup.Controllers 
{
    [Route("api/teams/{teamId}/players")]
    public class PlayersController : Controller
    {
        private IConfiguration _config;
        public PlayersController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string teamId) 
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_config.GetValue("sureBitsApi", ""));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("v0/team/"+teamId+"/roster");
            if (response.IsSuccessStatusCode)
            {
                var contenJson = await response.Content.ReadAsStringAsync();
                var players = JsonConvert.DeserializeObject<List<Player>>(contenJson);
                if(players != null && players.Any())
                {
                    return Ok(players.OrderBy(m=> m.FullName));
                }

                return NoContent();
            }
            
            return StatusCode((int)response.StatusCode);
        }
    }
}