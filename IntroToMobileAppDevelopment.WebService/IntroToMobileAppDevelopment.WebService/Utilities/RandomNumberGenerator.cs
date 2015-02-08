using System;

namespace IntroToMobileAppDevelopment.WebService.Utilities
{
    public class RandomNumberGenerator
    {
        private volatile static RandomNumberGenerator _instance;
        private readonly Random _random;
        private static readonly object _lock = new object();
        private const int _seed = 35043;

        private RandomNumberGenerator() { _random = new Random(_seed); }

        public static RandomNumberGenerator Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (_lock)
                {
                    if (_instance != null)
                        return _instance;
                    _instance = new RandomNumberGenerator();
                    return _instance;
                }
            }
        }

        public int GetRandomNumber()
        {
            lock (_lock)
            {
                return _random.Next(0,200);
            }
        }
    }
}