namespace Extractor.Models.Enums
{
    public readonly struct MediaFormat
    {
        public int Id { get; }
        public string Name { get; }
        public string Suffix { get; }
        public string MimeType { get; }
        internal MediaFormat(int id, string name, string suffix, string mimeType)
        {
            Id = id;
            Name = name;
            Suffix = suffix;
            MimeType = mimeType;
        }

        public static readonly MediaFormat MPEG_4 = new MediaFormat(0x0, "MPEG-4", "mp4", "video/mp4");
        public static readonly MediaFormat v3GPP = new MediaFormat(0x10, "3GPP", "3gp", "video/3gpp");
        public static readonly MediaFormat WEBM = new MediaFormat(0x20, "WebM", "webm", "video/webm");
        // audio formats
        public static readonly MediaFormat M4A = new MediaFormat(0x100, "m4a", "m4a", "audio/mp4");
        public static readonly MediaFormat WEBMA = new MediaFormat(0x200, "WebM", "webm", "audio/webm");
        public static readonly MediaFormat MP3 = new MediaFormat(0x300, "MP3", "mp3", "audio/mpeg");
        public static readonly MediaFormat MP2 = new MediaFormat(0x310, "MP2", "mp2", "audio/mpeg");
        public static readonly MediaFormat OPUS = new MediaFormat(0x400, "opus", "opus", "audio/opus");
        public static readonly MediaFormat OGG = new MediaFormat(0x500, "ogg", "ogg", "audio/ogg");
        public static readonly MediaFormat WEBMA_OPUS = new MediaFormat(0x200, "WebM Opus", "webm", "audio/webm");
        public static readonly MediaFormat AIFF = new MediaFormat(0x600, "AIFF", "aiff", "audio/aiff");
        /**
         * Same as {@link MediaFormat.AIFF}, just with the shorter suffix/file extension
         */
        public static readonly MediaFormat AIF = new MediaFormat(0x600, "AIFF", "aif", "audio/aiff");
        public static readonly MediaFormat WAV = new MediaFormat(0x700, "WAV", "wav", "audio/wav");
        public static readonly MediaFormat FLAC = new MediaFormat(0x800, "FLAC", "flac", "audio/flac");
        public static readonly MediaFormat ALAC = new MediaFormat(0x900, "ALAC", "alac", "audio/alac");
        // subtitles formats
        public static readonly MediaFormat VTT = new MediaFormat(0x1000, "WebVTT", "vtt", "text/vtt");
        public static readonly MediaFormat TTML = new MediaFormat(0x2000, "Timed Text Markup Language", "ttml", "application/ttml+xml");
        public static readonly MediaFormat TRANSCRIPT1 = new MediaFormat(0x3000, "TranScript v1", "srv1", "text/xml");
        public static readonly MediaFormat TRANSCRIPT2 = new MediaFormat(0x4000, "TranScript v2", "srv2", "text/xml");
        public static readonly MediaFormat TRANSCRIPT3 = new MediaFormat(0x5000, "TranScript v3", "srv3", "text/xml");
        public static readonly MediaFormat SRT = new MediaFormat(0x6000, "SubRip file format", "srt", "text/srt");
    }
}