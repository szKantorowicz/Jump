using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings.Services.Base
{
    public class RandomDataService : IRandomDataService
    {
        public int fall;
        public int length;
        public int note;
        public int sum;

        public void RandomFall()
        {
            int a = 0;
            int b = 2;
            Random nrand = new Random();
           fall = nrand.Next(a, b);

        }

        public void RandomLength()
        {
            int a = 100;
            int b = 140;
            Random nrand = new Random();
            length = nrand.Next(a, b);

        }

        public void RandomNote()
        {
            int a = 0;
            int b = 0;
            if (fall == 1)
            {
                a = 1;
                b = 12;
            }
            else
            {
                a = 13;
                b = 20;
            }
            Random nrand = new Random();
            note = nrand.Next(a, b);
        }

        public int SumResult()
        {
            return sum = note + length;
        }
    }
}
