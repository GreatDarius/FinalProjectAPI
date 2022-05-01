#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectAPI.Data;
using FinalProjectAPI.Models;
using Newtonsoft.Json;

namespace FinalProjectAPI.Controllers
{
    public class MoviesController : Controller
    {

        HttpClient httpClient;

        static string BASE_URL = "https://imdb-api.com/en/API/Top250Movies/k_lmgl0uc8";
        static string API_KEY = "k_lmgl0uc8"; //Add your API key here inside ""

        private readonly FinalProjectAPIContext _context;

        public MoviesController(FinalProjectAPIContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> test()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string IMDB_MOVIES_API_PATH = BASE_URL;
            string movieData = "";

            Movies movies = null;

            httpClient.BaseAddress = new Uri(IMDB_MOVIES_API_PATH);
            //httpClient.BaseAddress = new Uri(BASE_URL);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(IMDB_MOVIES_API_PATH)
                                                        .GetAwaiter().GetResult();
                //HttpResponseMessage response = httpClient.GetAsync(BASE_URL)
                //                                        .GetAwaiter().GetResult();



                if (response.IsSuccessStatusCode)
                {
                    movieData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!movieData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    movies = JsonConvert.DeserializeObject<Movies>(movieData);
                }
                _context.Database.EnsureCreated();
                await _context.SaveChangesAsync();

                _context.Movies.Add(movies);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return View(movies);
        }




        public async Task<IActionResult> Series()
        {
            string BASE_URL = "https://imdb-api.com/en/API/Top250TVs/k_lmgl0uc8";
            string API_KEY = "k_lmgl0uc8"; //Add your API key here inside ""

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string IMDB_SERIES_API_PATH = BASE_URL;
            string seriesData = "";

            Series series = null;

            httpClient.BaseAddress = new Uri(IMDB_SERIES_API_PATH);
            //httpClient.BaseAddress = new Uri(BASE_URL);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(IMDB_SERIES_API_PATH)
                                                        .GetAwaiter().GetResult();
                //HttpResponseMessage response = httpClient.GetAsync(BASE_URL)
                //                                        .GetAwaiter().GetResult();



                if (response.IsSuccessStatusCode)
                {
                    seriesData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!seriesData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    series = JsonConvert.DeserializeObject<Series>(seriesData);
                }
                _context.Database.EnsureCreated();
                await _context.SaveChangesAsync();

               _context.Series.Add(series);
               await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return View(series);
        }


    }
}

