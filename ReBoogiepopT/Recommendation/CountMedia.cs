using ReBoogiepopT.ApiCommunication.AnilistDatatypes;

namespace ReBoogiepopT.Recommendation
{
    /// <summary>
    /// A datatype which holds a media and the amount of its occurences within a context.
    /// </summary>
    public class CountMedia
    {
        public int Count { get; set; }
        public Media Media { get; }

        /// <summary>
        /// Initialize the first occurence of a media.
        /// </summary>
        /// <param name="media">Media to hold</param>
        public CountMedia(Media media)
        {
            Count = 1;
            Media = media;
        }

        /// <summary>
        /// Initialize a media with an amount of occurences given by count.
        /// </summary>
        /// <param name="media">Media to hold.</param>
        /// <param name="count">Amount of occurences appeared.</param>
        public CountMedia(Media media, int count)
        {
            Count = count;
            Media = media;
        }
    }
}
