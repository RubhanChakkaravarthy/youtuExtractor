using System;
using Extractor.ItemExtractors;
using Extractor.Models;

namespace Extractor.ItemCollectors
{
	internal class CommentItemCollector : ItemCollector<CommentItem, CommentItemExtractor>
	{
		protected override CommentItem Extract(CommentItemExtractor extractor)
		{
			var item = new CommentItem {
				Name = extractor.GetName(),
				Url = extractor.GetUrl(),
				Thumbnails = extractor.GetThumbnails(),
				ItemType = extractor.GetItemType()
			};

			try
			{
				item.CommentId = extractor.GetCommentId();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

            try
			{
				item.Content = extractor.GetContent();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

            try
			{
				item.AuthorUrl = extractor.GetAuthorUrl();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

            try
			{
				item.LikeCount = extractor.GetLikeCount();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

            try
			{
				item.IsAuthorChannelOwner = extractor.IsAuthorChannelOwner;
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
				item.ReplyCount = extractor.GetReplyCount();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

            try
			{
				item.RepliesContinuationToken = extractor.GetRepliesContinuationToken();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

            try
			{
				item.IsPinned = extractor.IsPinned;
			}
			catch (Exception ex)
			{
				AddException(ex);
			}

            return item;
		}
	}
}
