namespace Extractor.Models.Enums
{

    /// <summary>
    /// An enum to represent the different delivery methods of <c>VideoStream</c> which are returned
    /// by the extractor.
    /// </summary>
    public enum DeliveryMethod
    {

        /// <summary> 
        /// Used for <c>VideoStream</c>s served using the progressive HTTP streaming method.
        /// </summary>
        PROGRESSIVE_HTTP,

        /// <summary>
        /// Used for <c>VideoStream</c>s served using the DASH (Dynamic Adaptive Streaming over HTTP)
        /// adaptive streaming method.
        /// <see href="https://en.wikipedia.org/wiki/Dynamic_Adaptive_Streaming_over_HTTP">Dynamic Adaptive Streaming over HTTP Wikipedia page</see>
        /// <seealso href="https://dashif.org/">DASH Industry Forum's website</seealso>
        /// for more information about the DASH delivery method
        /// </summary>
        DASH,

        /// <summary>
        /// Used for <c>VideoStream</c>s served using the HLS (HTTP Live Streaming) adaptive streaming
        /// method.
        /// <see href="https://en.wikipedia.org/wiki/HTTP_Live_Streaming">HTTP Live Streaming
        /// page</see> and <seealso href="https://developer.apple.com/streaming">Apple's developers website page
        /// about HTTP Live Streaming</seealso> for more information about the HLS delivery method
        /// </summary>
        HLS,

        /// <summary>
        /// Used for <c>VideoStream</c>s served using the SmoothStreaming adaptive streaming method.
        /// <see href="https://en.wikipedia.org/wiki/Adaptive_bitrate_streaming#Microsoft_Smooth_Streaming_(MSS)">
        /// Wikipedia's page about adaptive bitrate streaming, section <i>Microsoft Smooth Streaming (MSS)</i></see>
        /// for more information about the SmoothStreaming delivery method
        /// </summary>
        SS,

        /// <summary>
        /// Used for <c>VideoStream</c>s served via a torrent file.
        /// <see href="https://en.wikipedia.org/wiki/BitTorrent">Wikipedia's BitTorrent's page</see>,
        /// <see href="https://en.wikipedia.org/wiki/Torrent_file">Wikipedia's page about torrent files
        /// </see> and <see href="https://www.bittorrent.org">Bitorrent's website</see> for more information
        /// about the BitTorrent protocol
        /// </summary>
        TORRENT
    }
}