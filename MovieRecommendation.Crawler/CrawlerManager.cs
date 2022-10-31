using MovieRecommendation.Business.Repository;
using MovieRecommendation.Entities;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieRecommendation.Crawler
{
    public class CrawlerManager
    {
        private readonly IRepository<Movies> _repository;
        private readonly IConfigurationRoot _configuration;
        private HttpClient client;
        private int latestId = 0;

        public CrawlerManager(IRepository<Movies> repository, IConfigurationRoot configuration)
        {
            _repository = repository;
            _configuration = configuration;
            SetupClient();
        }

        private void SetupClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["baseUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task GetLatestMovieId()
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTH:mm:ss.fffK"
            };
            string requestUri = _configuration["latestUrl"] + _configuration["apiKey"];
            HttpResponseMessage response = await client.GetAsync(requestUri);
            var result = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<Movies>(result, settings);
            latestId = movie.MovieId;
        }

        private async Task<Movies> GetMovieById(int id)
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTH:mm:ss.fffK"
            };
            string requestUri = "3/movie/" + id + "?api_key=" + _configuration["apiKey"];
            HttpResponseMessage response = await client.GetAsync(requestUri);
            var result = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<Movies>(result, settings);
            return movie;
        }

        public async Task<int> GetAllMoviesFromId(int id)
        {
            if (id > latestId) return -1;
            var movie = await GetMovieById(id);
            if (movie.MovieId != 0)
            {
                _repository.Add(movie);
            }
            return await GetAllMoviesFromId(id += 1);
        }

        public async Task Proccess(int lastMovieIdFromDB)
        {
            await GetLatestMovieId();
            await GetAllMoviesFromId(lastMovieIdFromDB);
        }
    }
}