using System;
using System.Collections.Generic;
using System.Linq;

namespace Proxy
{
    public class Program // tworzy zastępczy obiekt w miejscu innego, pośredniczy w wykonywaniu czynności/zapytań kontrolując dostęp do pierwotnego obiektu
    {   // może sprawiać, że ilość danych zmienianych jest mniejsza
        public static void Main(string[] args)
        {
            YoutubeService youtubeService = new YoutubeService();

            youtubeService.GetVideo(10);
            youtubeService.GetVideo(10); // dwa razy się pobiera z internetu

            ProxyYoutubeService proxy = new ProxyYoutubeService(youtubeService);
            proxy.GetVideo(10);
            proxy.GetVideo(10);
            proxy.GetVideo(10);
            proxy.GetVideo(10);
            proxy.GetVideo(10); // raz się pobiera z internetu, a potem z cache 
        }
    }
}