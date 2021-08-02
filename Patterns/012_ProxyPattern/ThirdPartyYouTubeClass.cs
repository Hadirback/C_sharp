using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_ProxyPattern
{
    public class ThirdPartyYouTubeClass : IThirdPartyYouTubeLib
    {
        public void DownloadVideo(int id)
        {
            Console.WriteLine($"Видео {id} скачалось");
        }

        public VideoData GetVideoInfo(int id)
        {
            Console.WriteLine($"Получаем видео {id}");
            VideoData tmp = new VideoData()
            {
                Id = id,
                Name = "test",
                Data = "run test"
            };
            return tmp;
        }

        public List<VideoData> ListVideos()
        {
            return new List<VideoData>
            {
                new VideoData(1, "Кошки", "Кошки танцуют джигу"),
                new VideoData(2, "Америка", "История америки")
            };
        }
    }
}
