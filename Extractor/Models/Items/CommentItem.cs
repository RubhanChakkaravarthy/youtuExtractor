namespace Extractor.Models
{
    public class CommentItem : Item
    {
        public static readonly int UNKNOWN_COUNT = -1;

        public string CommentId { get; set; }
        public string Content { get; set; }
        public string PublishedTime { get; set; }
        public int LikeCount { get; set; }
        public int UnlikeCount { get; set; } = UNKNOWN_COUNT;
        public int ReplyCount { get; set; }
        public string AuthorUrl { get; set; }
        public string RepliesContinuationToken { get; set; }
        public bool IsPinned { get; set; }
        public bool IsAuthorChannelOwner { get; set; }

        public override string ToString()
        {
	        return $"{Name}\n{Content}\nLikes: {LikeCount}\t{PublishedTime}";
        }
    }
}
