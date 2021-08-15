using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kantech2.Controllers
{
    public class Simple
    {
        public string Id { get; set; }
        public string Product { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        ISimpleFacade m_simple_facade;

        public SimpleController(ISimpleFacade simple_facade)
        {
            m_simple_facade = simple_facade;
        }

        [HttpGet]
        public IEnumerable<Simple> Get()
        {
            // monolith- SimpleFacade
            // micro services- MicroSimpleFacade
            return m_simple_facade.GetAll();
        }
    }
}
