using System.Collections.Generic;
using Extractor.Models.Enums;

namespace Extractor.Models.Stream
{
    public class ItagItem
    {
        public int Id { get; }
        public ItagType Type { get; }
        public MediaFormat MediaFormat { get; }
        public int Fps { get; } = BaseStream.FPS_NOT_APPLICABLE_OR_UNKNOWN;
        public int AvgBitRate { get; } = BaseStream.AVERAGE_BITRATE_UNKNOWN;
        public string Resolution { get; }

        private ItagItem(int id, ItagType type, MediaFormat mediaFormat, string resolution, int fps = 30)
        {
            Id = id;
            Type = type;
            MediaFormat = mediaFormat;
            Resolution = resolution;
            Fps = fps;
        }

        private ItagItem(int id, ItagType type, MediaFormat mediaFormat, int bitRate)
        {
            Id = id;
            Type = type;
            MediaFormat = mediaFormat;
            AvgBitRate = bitRate;
        }


        internal static readonly Dictionary<int, ItagItem> ITAGS = new Dictionary<int, ItagItem>{
            /////////////////////////////////////////////////////
            // VIDEO     ID  Type   Format  Resolution  FPS  ////
            /////////////////////////////////////////////////////
            { 17, new ItagItem(17, ItagType.VIDEO, MediaFormat.v3GPP, "144p") },
            { 36, new ItagItem(36, ItagType.VIDEO, MediaFormat.v3GPP, "240p") },

            { 18, new ItagItem(18, ItagType.VIDEO, MediaFormat.MPEG_4, "360p")},
            { 34, new ItagItem(34, ItagType.VIDEO, MediaFormat.MPEG_4, "360p") },
            { 35, new ItagItem(35, ItagType.VIDEO, MediaFormat.MPEG_4, "480p") },
            { 59, new ItagItem(59, ItagType.VIDEO, MediaFormat.MPEG_4, "480p") },
            { 78, new ItagItem(78, ItagType.VIDEO, MediaFormat.MPEG_4, "480p") },
            { 22, new ItagItem(22, ItagType.VIDEO, MediaFormat.MPEG_4, "720p") },
            { 37, new ItagItem(37, ItagType.VIDEO, MediaFormat.MPEG_4, "1080p") },
            { 38, new ItagItem(38, ItagType.VIDEO, MediaFormat.MPEG_4, "1080p") },

            { 43, new ItagItem(43, ItagType.VIDEO, MediaFormat.WEBM, "360p") },
            { 44, new ItagItem(44, ItagType.VIDEO, MediaFormat.WEBM, "480p") },
            { 45, new ItagItem(45, ItagType.VIDEO, MediaFormat.WEBM, "720p") },
            { 46, new ItagItem(46, ItagType.VIDEO, MediaFormat.WEBM, "1080p") },

            //////////////////////////////////////////////////////////////////
            // AUDIO     ID      ItagType          Format        Bitrate    //
            //////////////////////////////////////////////////////////////////
            { 171, new ItagItem(171, ItagType.AUDIO, MediaFormat.WEBMA, 128) },
            { 172, new ItagItem(172, ItagType.AUDIO, MediaFormat.WEBMA, 256) },
            { 139, new ItagItem(139, ItagType.AUDIO, MediaFormat.M4A, 48) },
            { 140, new ItagItem(140, ItagType.AUDIO, MediaFormat.M4A, 128) },
            { 141, new ItagItem(141, ItagType.AUDIO, MediaFormat.M4A, 256) },
            { 249, new ItagItem(249, ItagType.AUDIO, MediaFormat.WEBMA_OPUS, 50) },
            { 250, new ItagItem(250, ItagType.AUDIO, MediaFormat.WEBMA_OPUS, 70) },
            { 251, new ItagItem(251, ItagType.AUDIO, MediaFormat.WEBMA_OPUS, 160) },
			
            //////////////////////////////////////////////////////////////////
            // VIDEO ONLY
            // ID      Type     Format  Resolution  FPS  ////
            //////////////////////////////////////////////////////////////////
            { 160, new ItagItem(160, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "144p") },
            { 394, new ItagItem(394, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "144p") },
            { 133, new ItagItem(133, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "240p") },
            { 395, new ItagItem(395, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "240p") },
            { 134, new ItagItem(134, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "360p") },
            { 396, new ItagItem(396, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "360p") },
            { 135, new ItagItem(135, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "480p") },
            { 212, new ItagItem(212, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "480p") },
            { 397, new ItagItem(397, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "480p") },
            { 136, new ItagItem(136, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "720p") },
            { 398, new ItagItem(398, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "720p") },
            { 298, new ItagItem(298, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "720p60", 60) },
            { 137, new ItagItem(137, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "1080p") },
            { 399, new ItagItem(399, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "1080p") },
            { 299, new ItagItem(299, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "1080p60", 60) },
            { 400, new ItagItem(400, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "1440p") },
            { 266, new ItagItem(266, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "2160p") },
            { 401, new ItagItem(401, ItagType.VIDEO_ONLY, MediaFormat.MPEG_4, "2160p") },
            { 278, new ItagItem(278, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "144p") },
            { 242, new ItagItem(242, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "240p") },
            { 243, new ItagItem(243, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "360p") },
            { 244, new ItagItem(244, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "480p") },
            { 245, new ItagItem(245, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "480p") },
            { 246, new ItagItem(246, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "480p") },
            { 247, new ItagItem(247, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "720p") },
            { 248, new ItagItem(248, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "1080p") },
            { 271, new ItagItem(271, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "1440p") },
            // #272 is either 3840x2160 (e.g. RtoitU2A-3E) or 7680x4320 (sLprVF6d7Ug)
            { 272, new ItagItem(272, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "2160p") },
            { 302, new ItagItem(302, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "720p60", 60) },
            { 303, new ItagItem(303, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "1080p60", 60) },
            { 308, new ItagItem(308, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "1440p60", 60) },
            { 313, new ItagItem(313, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "2160p") },
            { 315, new ItagItem(315, ItagType.VIDEO_ONLY, MediaFormat.WEBM, "2160p60", 60) }
        };
    }
}