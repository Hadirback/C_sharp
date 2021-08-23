using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_StatePattern
{
    abstract class State
    {
        protected Context context;

        public void SetContext(Context context)
        {
            this.context = context;
        }

        public abstract void Handle1();
        public abstract void Handle2();
    }
}
