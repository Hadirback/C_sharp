using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_ProxyPattern
{
    public class VideoData
    {
        public VideoData()
        {

        }
        public VideoData(int id, string name, string data)
        {
            Id = id;
            Name = name;
            Data = data;
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public String Data { get; set; }

        public override string ToString()
        {
            return $"Id {Id} Name {Name} Data {Data}";
        }
    }
}
