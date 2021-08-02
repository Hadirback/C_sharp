using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_ProxyPattern
{
    public class YouTubeManager
    {
        protected IThirdPartyYouTubeLib service;

        public YouTubeManager(IThirdPartyYouTubeLib service)
        {
            this.service = service;
        }

        public void RenderVidoePage(int id)
        {
            Console.WriteLine(service.GetVideoInfo(id).ToString());
        }

        public void RenderListPanel()
        {
            List<VideoData> data = service.ListVideos();
            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ReactOnUserInput()
        {
            RenderVidoePage(3);
            RenderListPanel();
        }
    }
}
