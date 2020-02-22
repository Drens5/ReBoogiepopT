using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation
{
    /// <summary>
    /// Class that defines a tag with additional information.
    /// </summary>
    public class TagStatInfo
    {
        public string Name { get; }
        public string Category { get; }
        public int Count { get; set; }
        public int MinutesWatched { get; set; }

        public TagStatInfo(string name, string category, int count, int minutesWatched)
        {
            Name = name;
            Category = category;
            Count = count;
            MinutesWatched = minutesWatched;
        }

        public TagStatInfo(string name, string category) : this(name, category, 0, 0)
        {

        }
    }
}
