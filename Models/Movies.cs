
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FinalProjectAPI.Models
{
    public class Movies
    {
        public int id { get; set; }
        public List<Movie>? items { get; set; }
        public string? errorMessage { get; set; }
    }

    public class Movie
    {
        public string? id { get; set; }
        public string? rank { get; set; }
        public string? title { get; set; }
        public string? fullTitle { get; set; }
        public string? year { get; set; }
        public string? image { get; set; }
        public string? crew { get; set; }
        public string? imDbRating { get; set; }
        public string? imDbRatingCount { get; set; }
        public string? Genre { get; set; }
        public Movies? Movies { get; set; }
        public List<UserRate> userrate { get; set; }
    }

    public class UserRate
    {
        public int id { get; set; }
        public int rate { get; set; }
        public string movieid { get; set; }
        public Movie movie { get; set; }

    }

    public class Series
    {
        public int id { get; set; }
        public List<Serie> items { get; set; }
        public string errorMessage { get; set; }
    }

    public class Serie
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string title { get; set; }
        public string fullTitle { get; set; }
        public string year { get; set; }
        public string image { get; set; }
        public string crew { get; set; }
        public string imDbRating { get; set; }
        public string imDbRatingCount { get; set; }
        public Series Series { get; set; }
        public List<seriedetail>? seriedetail { get; set; }
    }
    public class seriedetail
    {
        public int id { get; set; }
        public string episodename { get; set; }
        public int episodelength { get; set; }
        public Serie serie { get; set; }

    }

    public class GroupSeriesEpisode
    {
        public string serieshow { get; set; }
        public int episodenems { get; set; }
    }

    public class SearchData
    {
        public string SearchType { get; set; }
        public string Expression { get; set; }

        public List<SearchResult> Results { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class SearchResult
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SearchData searchdata { get; set; }
    }

    public enum SearchType
    {
        Title = 1,
        Movie = 2,
        Series = 4,
        Name = 8,
        Episode = 16,
        Company = 32,
        Keyword = 64,
        All = 128
    }
    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
}
