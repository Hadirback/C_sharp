using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_ProxyPattern
{
    // Интерфейс удалённого сервиса.
    public interface IThirdPartyYouTubeLib
    {
        List<VideoData> ListVideos();
        VideoData GetVideoInfo(int id);
        void DownloadVideo(int id);
    }
}
