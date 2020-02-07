using System;
using Jumpings.DTO;
using Jumpings.Services.Base;

namespace Jumpings.Services
{
    public class RandomDataService : IRandomDataService
    {
        private bool _isFall;
        private int _length;
        private int _note;

        public JumperResult GetResult()
        {
            bool isJumperFalls = RandomFall();
            int jumpLength = RandomLength();
            int jumpNote = RandomNote();
            int jumpSum = GetSummary();

            return new JumperResult
            {
                Length = jumpLength,
                Note = jumpNote,
                IsFall = isJumperFalls,
                Summary = jumpSum
            };
        }

        private bool RandomFall()
        {
            const int min = 0;
            const int max = 2;
            var random = new Random();
            int fall = random.Next(min, max);

            if (fall == 0)
            {
                return _isFall = false;
            }

            return _isFall = true;
        }

        private int RandomLength()
        {
            const int min = 100;
            const int max = 140;
            var random = new Random();

            return _length = random.Next(min, max);
        }

        private int RandomNote()
        {
            int min;
            int max;

            if (_isFall)
            {
                min = 1;
                max = 12;
            }
            else
            {
                min = 13;
                max = 20;
            }

            var random = new Random();

            return _note = random.Next(min, max);
        }

        private int GetSummary()
        {
            return _note + _length;
        }
    }
}