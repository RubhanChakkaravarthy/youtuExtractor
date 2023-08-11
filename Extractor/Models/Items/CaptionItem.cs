namespace Extractor.Models
{
    public class CaptionItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string LanguageCode { get; set; }

        public override string ToString()
        {
	        return $"{Name}: {Url}";
        }
    }
}