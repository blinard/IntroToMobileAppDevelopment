using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using IntroToMobileAppDevelopment.WebService.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroToMobileAppDevelopment.WebService.Tests.Utilities
{
    [TestClass]
    public class RandomNumberGeneratorTest
    {
        private readonly ConcurrentBag<int> _randomNumbers = new ConcurrentBag<int>();
        private readonly List<Thread> _threads = new List<Thread>(10);
            
        [TestMethod]
        public void RandomNumbersInMultipleThreads()
        {
            for (int i = 0; i < 10; i++)
            {
                var newThread =
                    new Thread(() => _randomNumbers.Add(RandomNumberGenerator.Instance.GetRandomNumber()));
                newThread.Start();
                _threads.Add(newThread);
            }

            foreach (var thread in _threads)
                thread.Join();

            var unlikelyNumberGrouping = _randomNumbers.GroupBy(i => i).FirstOrDefault(grp => grp.Count() > 3);
            Assert.IsNull(unlikelyNumberGrouping);
        }
    }
}
