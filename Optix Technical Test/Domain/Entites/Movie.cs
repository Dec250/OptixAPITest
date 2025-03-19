namespace Optix_Technical_Test.Domain.Entites
{
    public class Movie
    {
        public int MovieId { get; set; }
        public DateTime Release_Date { get; set; }
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public double Popularity { get; set; }
        public short Vote_Count { get; set; }
        public double Vote_Average { get; set; }
        public string? Original_Language { get; set; }
        public string? Genre { get; set; }
        public string? Poster_Url { get; set; }

    }
}
