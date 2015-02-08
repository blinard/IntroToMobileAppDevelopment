using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntroToMobileAppDevelopment.WebService.Utilities;

namespace IntroToMobileAppDevelopment.WebService.Controllers
{
    public class RandomNumberController : ApiController
    {
        public int Get()
        {
            return RandomNumberGenerator.Instance.GetRandomNumber();
        }
    }
}
