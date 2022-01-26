using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ProxyYoutubeService : IYoutubeService
    {
        private YoutubeService _youtubeService;
        private Dictionary<int, byte[]> _cache = new Dictionary<int, byte[]>();


        public ProxyYoutubeService(YoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        public byte[] GetVideo(int videoId)
        {
            byte[] cachedVideo;
            Console.WriteLine($"ProxyYoutubeService getting {videoId}.");

            if (_cache.TryGetValue(videoId, out cachedVideo))
            {
                return cachedVideo;
            }

            var video = _youtubeService.GetVideo(videoId);
            _cache.Add(videoId, video);

            return video;
        }
    }
}
