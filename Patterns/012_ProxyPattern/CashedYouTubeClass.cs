using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_ProxyPattern
{
    public class CashedYouTubeClass : IThirdPartyYouTubeLib
    {
        private ThirdPartyYouTubeClass service;
        private List<VideoData> listCache;
        private VideoData videoCache;
        private Boolean needReset = false;
        private Boolean needDownload = true;

        public CashedYouTubeClass(ThirdPartyYouTubeClass service)
        {
            this.service = service;
        }

        public void DownloadVideo(int id)
        {
            if(needReset || !DownloadExists(id))
            {
                service.DownloadVideo(id);
                needDownload = !needDownload;
            }
        }

        public VideoData GetVideoInfo(int id)
        {
            if (videoCache == null || needReset)
            {
                videoCache = service.GetVideoInfo(4);
            }
            return videoCache;
        }

        public List<VideoData> ListVideos()
        {
            if(listCache == null || needReset)
            {
                listCache = service.ListVideos();
            }
            return listCache;
        }

        private Boolean DownloadExists(int id)
        {
            return !needDownload;
        }
    }
}
