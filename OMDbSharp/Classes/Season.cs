using System.Collections.Generic;

namespace OMDbSharp.Classes
{
    public class SeasonEpisode
    {
        public string Title { get; set; }
        public string Released { get; set; }
        public string EpisodeNumber { get; set; }
        public string IMDbRating { get; set; }
        public string IMDbID { get; set; }
    }

    public class Season
    {
        public string Title { get; set; }
        public string SeasonNumber { get; set; }
        public List<SeasonEpisode> Episodes { get; set; }
        public string Response { get; set; }
    }
}