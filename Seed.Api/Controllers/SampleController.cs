using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Seed.Application.Interfaces;
using Seed.Domain.Filter;
using Seed.Dto;
using Common.API;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Seed.CrossCuting;

namespace Seed.Api.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    public class SampleController : Controller
    {

        private readonly ISampleApplicationService _app;
		private readonly ILogger _logger;
		private readonly IHostingEnvironment _env;
      
        public SampleController(ISampleApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
        {
            this._app = app;
			this._logger = logger.CreateLogger<SampleController>();
			this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]SampleFilter filters)
        {
            var result = new HttpResult<SampleDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Sample", filters, new ErrorMapCustom());
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]SampleFilter filters)
		{
			var result = new HttpResult<SampleDto>(this._logger);
            try
            {
				if (id.IsSent()) filters.SampleId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Sample", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SampleDtoSpecialized dto)
        {
            var result = new HttpResult<SampleDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Sample", dto, new ErrorMapCustom());
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]SampleDtoSpecialized dto)
        {
            var result = new HttpResult<SampleDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Sample", dto, new ErrorMapCustom());
            }
        }


        [HttpDelete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, SampleDto dto)
        {
            var result = new HttpResult<SampleDto>(this._logger);
            try
            {
				if (id.IsSent()) dto.SampleId = id;
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Sample", dto, new ErrorMapCustom());
            }
        }

		[HttpPost("Post")]
        [HttpPost("ImportNew")]
        public async Task<IActionResult> ImportNew(SampleDto model)
        {
            var result = new HttpResult<System.Collections.Generic.List<SampleDto>>(this._logger);
            try
            {
                var returnModel = await this._app.ImportNew(model);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Seed - Sample", errorMap : new ErrorMapCustom());
            }
        }




    }
}
