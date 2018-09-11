using System.Collections.Generic;

namespace OMDbSharp.Objects
{
    public class SeasonDetails
    {
        public string Title { get; set; }
        public string SeriesID { get; set; }
        public string Season { get; set; }
        public string TotalSeasons { get; set; }
        public List<EpisodeDetails> Episodes { get; set; }
        public string Response { get; set; }
    }
}