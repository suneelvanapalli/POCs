using SetupIOCUnitTestingMock.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetupIOCUnitTestingMock.Business.Services
{
    public class Adviser : IAdviser
    {
        public bool IsDFM()
        {
            return true;
        }
    }
}