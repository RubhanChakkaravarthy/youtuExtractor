using System;
using Extractor.ItemExtractors;
using Extractor.Models;

namespace Extractor.ItemCollectors
{
	internal class PlaylistItemCollector : ItemCollector<PlaylistItem, PlaylistItemExtractor>
	{
		protected override PlaylistItem Extract(PlaylistItemExtractor extractor)
		{
			var item = new PlaylistItem
			{
				Name = extractor.GetName(),
				Url = extractor.GetUrl(),
                Thumbnails = extractor.GetThumbnails(),
				ItemType = extractor.GetItemType()
			};

			try
			{
				item.PlaylistId = extractor.GetPlaylistId();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

			try
			{
				item.VideosCount = extractor.GetVideosCount();
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

			return item;
		}
	}
}