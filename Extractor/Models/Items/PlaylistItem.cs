namespace Extractor.Models
{
    public class PlaylistItem : Item
    {
        public string PlaylistId { get; set; }
        public int VideosCount { get; set; }
        public ChannelItem Uploader { get; set; }

        public override string ToString()
		{
			return $"{Name}\n{Uploader.Name}\t{VideosCount}\n{Url}";
		}
    }
}