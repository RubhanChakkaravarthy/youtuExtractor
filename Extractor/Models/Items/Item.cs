using Extractor.Models.Enums;

namespace Extractor.Models
{
	public abstract class Item
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public ThumbnailInfo[] Thumbnails { get; set; }
		public ItemType ItemType { get; set; }
	}
}