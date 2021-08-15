using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kantech2.Controllers
{
    public class SimpleFacade : ISimpleFacade
    {
        public List<Simple> GetAll()
        {
            return new List<Simple>()
            {
                new Simple { Id = "1", Product = "Computer"},
                new Simple { Id = "2", Product = "Car"},
            };
        }
    }
}
