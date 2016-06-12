using System;

namespace SetupIOCUnitTestingMock.Controllers
{
    public interface IAdviser
    {
        bool IsDFM();
    }

    public class Adviser : IAdviser
    {
        public bool IsDFM()
        {
            return true;
        }
    }
}