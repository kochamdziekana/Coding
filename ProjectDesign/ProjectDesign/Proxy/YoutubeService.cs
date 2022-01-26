using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class YoutubeService : IYoutubeService // uznajemy dla zrozumienia, że jest to klasa zewnętrzna
    {
        public byte[] GetVideo(int videoId)
        {
            Console.WriteLine($"Youtube service downloading video: {videoId}.");

            return new byte[videoId];
        }
    }
}
