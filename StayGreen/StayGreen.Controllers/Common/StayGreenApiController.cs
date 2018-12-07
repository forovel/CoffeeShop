using Microsoft.AspNetCore.Mvc;
using StayGreen.Controllers.Code;
using StayGreen.Services.Interfaces.Common;
using System;

namespace StayGreen.Controllers.Common
{
    public class StayGreenApiController<TService, TReadDto, TCreateDto, TUpdateDto> : BaseApiController where TService : IBaseService<TReadDto, TCreateDto, TUpdateDto, Guid>
    {
        protected TService _service;

        [HttpGet]
        public virtual IActionResult Get([FromQuery] QueryOptions options)
        {
            var result = _service.GetFiltered(options);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }


        [HttpPost]
        public virtual IActionResult Create([FromBody] TCreateDto model)
        {
            var createdModel = _service.Create(model);
            return Created(string.Empty, createdModel);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(Guid id, [FromBody] TUpdateDto model)
        {
            var updateModel = _service.Update(id, model);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
