using System.Collections.Generic;
using System.Text;
using Extractor.Models.Stream;

namespace Extractor.Models
{
    public class StreamInfo : StreamItem
    {
        public List<VideoStream> VideoStreams { get; set; }
        public List<AudioStream> AudioStreams { get; set; }
        public CaptionItem[] Captions { get; set; }

        public override string ToString()
        {
	        var sb = new StringBuilder();
	        sb.AppendLine(base.ToString());
	        sb.AppendLine("Video Links: ");
	        VideoStreams?.ForEach(v => sb.AppendLine(v.ToString()));
	        sb.AppendLine("Audio Links: ");
	        AudioStreams?.ForEach(a => sb.AppendLine(a.ToString()));
	        if (Captions != null) {
		        sb.AppendLine("Captions: ");
		        foreach (var caption in Captions)
		        {
			        sb.AppendLine(caption.ToString());
		        }
	        }
	        return sb.ToString();
        }
    }
}
