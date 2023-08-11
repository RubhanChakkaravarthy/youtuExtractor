using System;
using Extractor.ItemExtractors;
using Extractor.Models;

namespace Extractor.ItemCollectors
{
	internal class StreamInfoCollector : ItemCollector<StreamInfo, StreamInfoExtractor>
	{
		protected override StreamInfo Extract(StreamInfoExtractor extractor)
		{
			var item = new StreamInfo {
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
				item.VideoStreams = extractor.GetVideoStreams();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			try
			{
				item.AudioStreams = extractor.GetAudioStreams();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			try
			{
				item.Captions = extractor.GetCaptions();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			return item;
		}
	}
}
