using Extractor.Models;
using Extractor.Models.Enums;

namespace Extractor.ItemExtractors
{
	internal interface IItemExtractor<T>
	{
		string GetName();
		string GetUrl();
		ThumbnailInfo[] GetThumbnails();
		ItemType GetItemType();
	}
}
