namespace Extractor.Models.Stream
{
    public class AudioStream : BaseStream
    {
        public int Channels { get; set; }
        public int SampleRate { get; set; } = SAMPLE_RATE_UNKNOWN;
        public AudioStream(ItagItem itagItem): base(itagItem) {}
    }
}