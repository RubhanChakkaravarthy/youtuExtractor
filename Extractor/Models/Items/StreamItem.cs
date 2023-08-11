using System;
using Extractor.Models.Enums;

namespace Extractor.Models
{
	public class StreamItem : Item
	{
		public string VideoId { get; set; }
		public string Description { get; set; }
		public TimeSpan Duration { get; set; }
		public string PublishedTime { get; set; }
		public string ViewCount { get; set; }
		public ChannelItem Uploader { get; set; }
		public StreamType StreamType { get; set; }
		public bool IsReel { get; set; }

		public override string ToString()
		{
			return $"{Name}\n{Uploader?.Name}\t{Duration}\t{ViewCount}\n{Url}";
		}
	}
}

