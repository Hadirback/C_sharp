using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_CompositePattern
{
    public interface Graphic
    {
        void Move(int x, int y);
        void Draw();
    }
}
