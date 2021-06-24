using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Sections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopcoderNetApi.Controllers
{
    [Route("section")]
    [ApiController]
    [Authorize]
    public class SectionsController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly ISectionService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionsController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public SectionsController(ISectionService service)
        {
            _service = service;
        }
        
        // GET: api/<SectionsController>
        [HttpGet]
        public IEnumerable<Section> Get()
        {
            return _service.GetSections();
        }

        // GET api/<SectionsController>/5
        [HttpGet("{id}")]
        public Section Get(Guid id)
        {
            var section = _service.GetSection(id);
            return section;
        }

        // POST api/<SectionsController>
        [HttpPost]
        public void Post([FromBody] Section section)
        {
            _service.AddSetion(section);
        }
    }
}
