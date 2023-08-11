using System;

using Extractor.ItemExtractors;
using Extractor.Models;

namespace Extractor.ItemCollectors
{
	internal class StreamItemCollector : ItemCollector<StreamItem, StreamItemExtractor>
	{
		protected override StreamItem Extract(StreamItemExtractor extractor)
		{
			var item = new StreamItem {
				Name = extractor.GetName(),
				Url = extractor.GetUrl(),
				Thumbnails = extractor.GetThumbnails(),
				StreamType = extractor.GetStreamType(),
				ItemType = extractor.GetItemType()
			};

			try
			{
				item.VideoId = extractor.GetVideoId();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			try
			{
				item.Description = extractor.GetDescription();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			try
			{
				item.ViewCount = extractor.GetViewCount();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			try
			{
				item.PublishedTime = extractor.GetPublishedTime();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			try
			{
				item.Duration = extractor.GetDuration();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			try
			{
				item.Uploader = extractor.GetUploader();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			try
			{
				item.IsReel = extractor.IsReel();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			return item;
		}
	}
}