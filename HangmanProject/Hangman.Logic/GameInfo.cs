using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HangmanProject.Hangman.Logic
{
    class GameInfo : IGameInfo
    {
        private static HttpClient _service;

        public GameInfo()
        {
            _service = new HttpClient();

            _service.BaseAddress = new Uri(ConfigurationManager.ConnectionStrings["igdbAPI"].ConnectionString);

            _service.DefaultRequestHeaders.Add("user-key", ConfigurationManager.AppSettings["IGDB_key"]);
            _service.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public void GetGame()
        {
            Game game = getRandomGameInfo().GetAwaiter().GetResult();

            Console.WriteLine(game.Id);
        }

        static async Task<Game> getRandomGameInfo()
        {
            Game game = null;

            HttpResponseMessage response = await _service.GetAsync(_service.BaseAddress.AbsoluteUri + @"/games/1942");
            if (response.IsSuccessStatusCode)
            {
                game = await response.Content.ReadAsAsync<Game>();
            }

            return game;
        }

    }

    class Game
    {
        public string Id { get; set; }
    }
}
