using System;
using System.Collections.Generic;

namespace Extractor.Models
{
    public class TrendingPageContents
    {
        public string Name { get; set; }
        public List<string> Titles { get; set; }
        public List<StreamItem> Items { get; set; }
        public List<Exception> Exceptions { get; set; }
        public List<ItemsSection<StreamItem>> Sections { get; set; }
    }
}