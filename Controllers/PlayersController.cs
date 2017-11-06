using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PackersLineup.Models;

namespace PackersLineup.Controllers
{
    [Route("api/teams/{teamId}/players")]
    public class PlayersController : Controller
    {
        private readonly IOptions<AppSetting> _config;
        public PlayersController(IOptions<AppSetting> config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string teamId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_config.Value.SureBitsApi);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("v0/team/" + teamId + "/roster");
            if (response.IsSuccessStatusCode)
            {
                var contenJson = await response.Content.ReadAsStringAsync();
                var players = JsonConvert.DeserializeObject<List<Player>>(contenJson);
                if (players != null && players.Any())
                {
                    return Ok(players);
                }

                //No players found
                return NoContent();
            }

            //Log error and return status returned from endpoint
            return StatusCode((int)response.StatusCode);
        }
    }
}