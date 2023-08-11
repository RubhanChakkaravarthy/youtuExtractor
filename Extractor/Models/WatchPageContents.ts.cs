using System;
using System.Collections.Generic;

namespace Extractor.Models
{
    public class WatchPageContents
    {
        public StreamInfo StreamInfo { get; set; }
        public string TotalCommentsCount { get; set; }
        public List<CommentItem> Comments { get; set; }
        public string CommentsContinuationToken { get; set; }
        public List<StreamItem> NextWatchItems { get; set; }
        public string WatchNextContinuationToken { get; set; }
        public List<Exception> Exceptions { get; set; }
    }
}

