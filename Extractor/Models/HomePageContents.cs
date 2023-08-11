using System;
using System.Collections.Generic;

namespace Extractor.Models
{
    public class HomePageContents
    {
        public List<StreamItem> Items { get; set; }
        public List<Exception> Exceptions { get; set; }
        public string ContinuationToken { get; set; }
        public List<ItemsSection<StreamItem>> Sections { get; set; }
    }
}