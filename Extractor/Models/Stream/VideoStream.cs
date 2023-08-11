using Extractor.Models.Enums;

namespace Extractor.Models.Stream
{
    public class VideoStream : BaseStream
    {
        public VideoStream(ItagItem itagItem): base(itagItem) {}

        public int Width { get; set; }
        public int Height { get; set; }
        public DeliveryMethod DeliveryType { get; set; }
        public int TargetDurationSec { get; set; } = TARGET_DURATION_SEC_UNKNOWN;
        public string ManifestUrl { get; set; }
    }
}