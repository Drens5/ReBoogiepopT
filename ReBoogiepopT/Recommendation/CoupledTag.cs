using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation
{
    public class CoupledTag
    {
        /// <summary>
        /// List of coupled tags. The coupled tag is satisfied if one of the tags in this list is present.
        /// </summary>
        private List<string> coupled;

        public CoupledTag(List<string> coupledTag)
        {
            coupled = coupledTag;
        }

        public CoupledTag(string tag) : this(new List<string>() { tag })
        {

        }

        /// <summary>
        /// Checks whether the specified tag lies within this instance of coupled tags.
        /// </summary>
        /// <param name="tag">The tag to verify.</param>
        /// <returns>True if the tag is present in this coupled tag.</returns>
        public bool Satisfies(string tag)
        {
            return coupled.Contains(tag);
        }

        /// <summary>
        /// Checks whether the specified tag lies within this instance of coupled tags.
        /// </summary>
        /// <param name="tag">The tag to verify.</param>
        /// <returns>True if the tag is present in this coupled tag.</returns>
        public bool Satisfies(MediaTag tag)
        {
            return Satisfies(tag.Name);
        }


        /// <summary>
        /// Checks whether one of the specified tags lie within this instance of coupled tags.
        /// </summary>
        /// <param name="tags">List of tags of which wants to be checked against this coupled tag.</param>
        /// <returns>True if one of the tags specified is present in this coupled tag.</returns>
        public bool Satisfies(List<MediaTag> tags)
        {
            if (tags == null)
                return false;

            foreach (MediaTag tag in tags)
            {
                if (Satisfies(tag))
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Checks whether the media satisfies this coupled tag.
        /// </summary>
        /// <param name="media">Media to be checked against this coupled tag.</param>
        /// <returns>True if the media contains a tag which is in this coupled tag.</returns>
        public bool Satisfies(Media media)
        {
            return Satisfies(media.Tags);
        }

        public int Count => coupled.Count;
    }
}
