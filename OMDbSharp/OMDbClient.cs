using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OMDbSharp
{
    public class OMDbClient
    {
        private const string omdbUrl = "http://www.omdbapi.com/?"; // Base OMDb API URL
        private bool rottenTomatoesRatings = false;

        public OMDbClient(bool rottenTomatoesRatings)
        {
            this.rottenTomatoesRatings = rottenTomatoesRatings;
        }

        private async Task<T> Request<T>(string query)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(omdbUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(omdbUrl + query + "&tomatoes=" + rottenTomatoesRatings).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return (T)JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
                    {
                        Error = HandleDeserializationError
                    });
                }
                else
                {
                    return default(T);
                }
            }
        }

        public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public async Task<Item> GetItemByTitle(string title)
        {
            Item item = await Request<Item>("t=" + title).ConfigureAwait(false);
            return item;
        }

        public async Task<Item> GetItemByID(string id)
        {
            Item item = await Request<Item>("i=" + id).ConfigureAwait(false);
            return item;
        }

        public async Task<ItemList> GetItemList(string query)
        {
            ItemList itemList = await Request<ItemList>("s=" + query).ConfigureAwait(false);
            return itemList;
        }

        public async Task<Season> GetSeriesSeason(string id, int season)
        {
            Season _season = await Request<Season>("i=" + id + "&Season=" + season).ConfigureAwait(false);
            return _season;
        }

        public async Task<SeasonDetails> GetSeriesSeasonDetails(string id, int season)
        {
            SeasonDetails _season = await Request<SeasonDetails>("i=" + id + "&Season=" + season + "&detail=full").ConfigureAwait(false);
            return _season;
        }

        public async Task<Episode> GetSeriesEpisode(string id, int season, int episode)
        {
            Episode _episode = await Request<Episode>("i=" + id + "&Season=" + season + "&Episode=" + episode).ConfigureAwait(false);
            return _episode;
        }

        public async Task<EpisodeDetails> GetSeriesEpisodeDetails(string id, int season, int episode)
        {
            EpisodeDetails _episode = await Request<EpisodeDetails>("i=" + id + "&Season=" + season + "&Episode=" + episode + "&detail=full").ConfigureAwait(false);
            return _episode;
        }
    }
}