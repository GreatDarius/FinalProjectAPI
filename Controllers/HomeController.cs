using FinalProjectAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FinalProjectAPI.Data;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace FinalProjectAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinalProjectAPIContext _context;

        public HomeController(FinalProjectAPIContext context)
        {
            _context = context;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> rating (string titles)
        //{
        //    HttpClient httpClient;
        //    string BASE_URL = "https://imdb-api.com/en/API/Search/k_lmgl0uc8/";
        //    string API_KEY = "k_lmgl0uc8"; //Add your API key here inside ""

        //    httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Accept.Clear();
        //    httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
        //    httpClient.DefaultRequestHeaders.Accept.Add(
        //        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


        //    SearchData name = new SearchData();
        //    name.Expression = "batman";

        //    string movieserieData = "";
        //    string IMDB_SERIES_API_PATH = BASE_URL + "Batman";

        //    SearchData movieserie = null;

        //    httpClient.BaseAddress = new Uri(IMDB_SERIES_API_PATH);
        //    //httpClient.BaseAddress = new Uri(BASE_URL);

        //    try
        //    {
        //        HttpResponseMessage response = httpClient.GetAsync(IMDB_SERIES_API_PATH)
        //                                                .GetAwaiter().GetResult();
        //        //HttpResponseMessage response = httpClient.GetAsync(BASE_URL)
        //        //                                        .GetAwaiter().GetResult();



        //        if (response.IsSuccessStatusCode)
        //        {
        //            movieserieData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        //        }

        //        if (!movieserieData.Equals(""))
        //        {
        //            // JsonConvert is part of the NewtonSoft.Json Nuget package
        //            movieserie = JsonConvert.DeserializeObject<SearchData>(movieserieData);
        //        }
        //        //_context.Database.EnsureCreated();
        //        //await _context.SaveChangesAsync();

        //        //_context.Series.Add(movieserie);
        //        //await _context.SaveChangesAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        // This is a useful place to insert a breakpoint and observe the error message
        //        Console.WriteLine(e.Message);
        //    }
        //    //List<SearchData> moviesandshows = SearchMovies("");

        //    return View(movieserie);
        //}
        //[HttpPost]
        //public async Task<IActionResult> rating(SearchData movieserie)
        //{

        //    return View(movieserie);
        //}
        //private static List<SearchData> SearchMovie(string title)
        //{
        //    List<SearchData> moviesandshows = new List<SearchData>();
        //    string apiUrl = "https://imdb-api.com/en/API/Search/k_lmgl0uc8/";

        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = client.GetAsync(apiUrl + title).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string movieserieData = "";
        //        movieserieData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        //        moviesandshows = JsonConvert.DeserializeObject < SearchData>(movieserieData);
        //    }

        //    return moviesandshows;

        //}

        public async Task<IActionResult> topmovies()
        {
            List<Movie> top10movies = _context.Movie.OrderByDescending(M=>M.imDbRating).Take(10).ToList();
            ViewData["data"] = top10movies;
            ViewData["topmovies"] = top10movies;
            return View("topmovies");
        }
        public async Task<IActionResult> topshows()
        {
            List<Serie> top10series = _context.Serie.OrderByDescending(s => s.imDbRating).Take(10).ToList();
            ViewData["data"] = top10series;
            ViewData["topshows"] = top10series;
            return View("topshows");
        }
        public IActionResult aboutus()
        {
            return View();
        }
        //public IActionResult chart()
        //{
        //    return View();
        //}
        public IActionResult moviedetails(string? movieID)
        {
            
            List<Movie> moviedetails = _context.Movie.Where(mo=>mo.id == movieID).ToList();
            ViewData["data"] = moviedetails;
            ViewData["moviedetails"] = moviedetails;
            return View("moviedetails");
        }
        public IActionResult seriedetails(string? serieID)
        {

            List<Serie> seriedetails = _context.Serie.Where(se => se.id == serieID).ToList();
            ViewData["data"] = seriedetails;
            ViewData["seriedetails"] = seriedetails;
            return View("seriedetails");
        }

        public IActionResult moviegenreupdate(string? movie_ID)
        {
            if(movie_ID == null)
            {
                return NotFound();
            }
            //List<Movie> moviegenreupdate = _context.Movie.Where(moe => moe.id == movie_ID).ToList();
            //ViewData["data"] = moviegenreupdate;
            //ViewData["moviegenreupdate"] = moviegenreupdate;
            var moviegenreupdate = _context.Movie.Find(movie_ID);
            return View(moviegenreupdate);
        }
        [HttpPost]
        public IActionResult moviegenreupdate( Movie moviegenreupdate)
        {
            _context.Entry(moviegenreupdate).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("topmovies");
        }

        public IActionResult moviedelete(string? movie_ID_delete)
        {
            if (movie_ID_delete == null)
            {
                return NotFound();
            }
            //List<Movie> moviegenreupdate = _context.Movie.Where(moe => moe.id == movie_ID).ToList();
            //ViewData["data"] = moviegenreupdate;
            //ViewData["moviegenreupdate"] = moviegenreupdate;
            var moviedelete = _context.Movie.Find(movie_ID_delete);
            return View(moviedelete);
        }
        [HttpPost, ActionName("moviedelete")]
        public IActionResult moviedeletepost(string id )
        {
            var mov=_context.Movie.Find(id);
            _context.Movie.Remove(mov);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult seriedetailcreate(string? serieID)
        {
            if (serieID == null)
            {
                return NotFound();
            }
            //List<Movie> moviegenreupdate = _context.Movie.Where(moe => moe.id == movie_ID).ToList();
            //ViewData["data"] = moviegenreupdate;
            //ViewData["moviegenreupdate"] = moviegenreupdate;
            //List<Serie> seriesdetailscreate = _context.Serie.Include(s=>s.seriedetail).Where(s=>s.id == serieID).ToList();
            List<seriedetail> seriesdetailscreate = _context.Seriedetail.Include(s=>s.serie).Where(u=>u.serie.id == serieID).ToList();

            ViewData["data"] = seriesdetailscreate;
            ViewData["topmovies"] = seriesdetailscreate;
            return View("seriedetailcreate");
        }
        

        public IActionResult ratingss(string? movie_ID_rate)
        {
            if (movie_ID_rate == null)
            {
                return NotFound();
            }
            //List<Movie> moviegenreupdate = _context.Movie.Where(moe => moe.id == movie_ID).ToList();
            //ViewData["data"] = moviegenreupdate;
            //ViewData["moviegenreupdate"] = moviegenreupdate;
            List<UserRate> movierate = _context.userRates.Include(m=>m.movie).Where(u=>u.movie.id == movie_ID_rate).ToList();
            ViewData["data"] = movierate;
            ViewData["ratingss"] = movierate;
            return View(movierate);
        }

        public IActionResult rating(string movie_ID_rating)
        {
            //// List<Movie> movierate = _context.Movie.Include(r=>r.userrate).Where(m=>m.id == movie_ID_rating).ToList();
            ////ViewData["data"] = movierate;
            ////ViewData["rating"] = movie_ID_rating;
            //return View();
            ////var movierate = _context.userRates;
            ////return View(movietoupdate);
            var movietoupdate = _context.Movie.Find(movie_ID_rating);
            return View(movietoupdate);
        }

        [HttpPost]
        public IActionResult rating(Movie obj, string id, int userrate)
        {
            //var movietoupdate = _context.Movie.Find(movie_ID_rating);
            UserRate newrate = new UserRate { rate = userrate,movieid = id };
            _context.userRates.Add(newrate);
            _context.SaveChanges();
            return RedirectToAction("topmovies");
        }

        public async Task<IActionResult> chart()
        {
            //List<int> counts = new List<int>();
            //var genretypes = _context.Movie.Select(m => m.Genre).Distinct();
            //var AllDataGenere = _context.Movie.GroupBy(g => new { g.Genre }).Select(g => new { g.Key.Genre, Total_count = g.Count() }).OrderByDescending(d => d.Total_count).ToList();
            ////ViewData["Title"] = "Join Group with college name";
            ////ViewData["Data"] = AllDataGenere;
            ////ViewData["chart"] = AllDataGenere;
            ////return View("chart");
            //ViewBag.genrename = genretypes;
            //ViewBag.countofall = AllDataGenere;
            //return View();

            //var genre_all = (from m in _context.Movie
            //                       where m.Genre != null
            //                       orderby m.Genre ascending
            //                       group m by m.Genre into g
            //                       select new { genre_all = g.Key }).ToList();

            //decimal totalcount = _context.Movie.Count();

            //List<string> genreAll = new List<string>();
            //List<string> Total = new List<string>();
            //foreach (var item in genre_all)
            //{
            //    decimal sum = _context.Movie
            //                    .Where(x => x.Genre == item.genre_all)
            //                    .OrderBy(x => x.Genre)
            //                    .Count();
            //    decimal countofgenres = (sum);

            //    genreAll.Add(item.genre_all);
            //    Total.Add(countofgenres.ToString());
            //}

            //TempData["genreAll"] = string.Join(",", genreAll);
            //TempData["Total"] = string.Join(",", Total);
            //return View();

            List<DataPoint> dataPoints = new List<DataPoint>();
            dataPoints.Add(new DataPoint("Action", 10));
            dataPoints.Add(new DataPoint("Drama", 30));
            dataPoints.Add(new DataPoint("Comedy", 17));
            dataPoints.Add(new DataPoint("Fiction", 39));
            dataPoints.Add(new DataPoint("Romance", 30));
            dataPoints.Add(new DataPoint("Horror", 25));
            dataPoints.Add(new DataPoint("Thriller", 5));
            dataPoints.Add(new DataPoint("Mystery", 9));
            dataPoints.Add(new DataPoint("Animation", 13));

            dataPoints.Add(new DataPoint("Historic", 15));


            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}