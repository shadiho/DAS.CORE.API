using System;
using System.Collections.Generic;
using System.Text;
using DASInMemoryDatabase;
namespace CoreAPI.Test
{
    class InMemoryDatabaseFixture : IDisposable
    {
        public InMemoryDatabaseFixture()
        {
            InMemoryDatabase.Initialize();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
