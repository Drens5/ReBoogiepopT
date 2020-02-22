using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation
{
    /// <summary>
    /// Class defines a genre with additional information.
    /// </summary>
    public class GenreStatInfo
    {
        public string Name { get; }
        public int Count { get; }
        public int MinutesWatched { get; }

        public GenreStatInfo(string name, int count, int minutesWatched)
        {
            Name = name;
            Count = count;
            MinutesWatched = minutesWatched;
        }

        public GenreStatInfo(string name) : this(name, 0, 0)
        {

        }
    }
}
