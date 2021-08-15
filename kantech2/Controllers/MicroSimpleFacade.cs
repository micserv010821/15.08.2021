using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kantech2.Controllers
{
    public class MicroSimpleFacade : ISimpleFacade
    {
        public List<Simple> GetAll()
        {
            return new List<Simple>()
            {
                new Simple { Id = "3", Product = "TV"},
                new Simple { Id = "4", Product = "Motorcycle"},
            };
        }
    }
}
