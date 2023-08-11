using System;
using System.Collections.Generic;

namespace Extractor.Models
{
    public class SearchPageContents
    {
        public string SearchText { get; set; }
        public List<Item> Items { get; set; }
        public List<Exception> Exceptions { get; set; }
        public List<ItemsSection<StreamItem>> Sections { get; set; }
        public string ContinuationToken { get; set; }
    }
}