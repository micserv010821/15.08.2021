using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kantech2.Controllers
{
    public interface ISimpleFacade
    {
        List<Simple> GetAll();
    }
}
