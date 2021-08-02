using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_PrototypePattern
{
    abstract class Prototype
    {
        public int Id { get; set; }
        public Prototype(int id)
        {
            Id = id;
        }
        public abstract Prototype Clone();
    }
}
