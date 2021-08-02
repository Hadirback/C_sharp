using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_CommandPattern
{
    public class SimpleCommand : ICommand
    {
        private String payload = "";

        public SimpleCommand(String payload)
        {
            this.payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({this.payload})");
        }
    }
}
