using ArqsiP1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Services
{
    public class TestService
    {
        ITestRepo _repo;

        public TestService(ITestRepo repo)
        {
            _repo = repo;
        }

        public void TearDown()
        {
            _repo.TearDown();
        }
    }
}
