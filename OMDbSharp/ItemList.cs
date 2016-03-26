using System;

namespace OMDbSharp
{
    public class ItemList
    {
        public Search[] Search { get; set; }
    }

    public class Search
    {
        public string Title { get; set; }

        public string Year { get; set; }

        public string imdbID { get; set; }

        public string Type { get; set; }
    }
}