using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Gaming.GameService.DataType;
using System.Linq;

namespace Gaming.GameService
{
    public class GameService : IGameService
    {
        private static readonly HttpClient _client;

        static GameService()
        {
            _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("user-key", "5cc15a0dae92c96dac73170039803bf9");
        }

        public Game GetRandomGame()
        {
            int maxCount = GetGamesTotal().GetAwaiter().GetResult();
            int randomID = new Random().Next(1, maxCount);

            return GetGameInfo(randomID).GetAwaiter().GetResult();
        }

        private static async Task<int> GetGamesTotal()
        {
            var serializer = new DataContractJsonSerializer(typeof(Response));

            var streamTask = _client.GetStreamAsync("https://api-endpoint.igdb.com/games/count");
            Response response = serializer.ReadObject(await streamTask) as Response;

            return response.Count;
        }

        private static async Task<Game> GetGameInfo(int gameId)
        {

            var serializer = new DataContractJsonSerializer(typeof(List<object>));

            var streamTask = _client.GetStreamAsync($"https://api-endpoint.igdb.com/games/{gameId}");
            List<Game> games = serializer.ReadObject(await streamTask) as List<Game>;

            return games.First();


        }
    }
}
