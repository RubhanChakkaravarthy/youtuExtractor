using Extractor.Models.Enums;

namespace Extractor.Models.Stream
{
    public abstract class BaseStream
    {
	    #region CONSTANTS
        public static readonly int AVERAGE_BITRATE_UNKNOWN = -1;
        public static readonly int SAMPLE_RATE_UNKNOWN = -1;
        public static readonly int FPS_NOT_APPLICABLE_OR_UNKNOWN = -1;
        public static readonly int AUDIO_CHANNELS_NOT_APPLICABLE_OR_UNKNOWN = -1;
        public static readonly long CONTENT_LENGTH_UNKNOWN = -1;
        public static readonly long APPROX_DURATION_MS_UNKNOWN = -1;
        public static readonly int TARGET_DURATION_SEC_UNKNOWN = -1;
	    #endregion

	    #region PROPERTIES
        public int Id { get; set; }
        public ItagType TagType { get; set; }
        public MediaFormat MediaFormat { get; set; }
        public int Fps { get; set; }
        public int AvgBitRate { get; set; }
        public string Resolution { get; set; }
        public string Url { get; set; }
        public int InitStart { get; set; }
        public int InitEnd { get; set; }
        public int IndexStart { get; set; }
        public int IndexEnd { get; set; }
        public string Quality { get; set; }
        public string Codec { get; set; }
        public long ApproxDurationMs { get; set; } = APPROX_DURATION_MS_UNKNOWN;
        public long ContentLength { get; set; } = CONTENT_LENGTH_UNKNOWN;
	    #endregion
        
	    #region CONSTRUCTORS
        protected BaseStream(ItagItem itagItem)
        {
            Id = itagItem.Id;
            TagType = itagItem.Type;
            MediaFormat = itagItem.MediaFormat;
            Fps = itagItem.Fps;
            AvgBitRate = itagItem.AvgBitRate;
            Resolution = itagItem.Resolution;
        }
        #endregion
		
        #region METHODS
        public override string ToString()
        {
	        return $"{Url}\n{Quality}\t{ApproxDurationMs / 1000}s\t{Codec}";
        }
        #endregion
    }
}