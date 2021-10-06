using Cars.Api.Messages;
using Cars.Application.Interfaces;
using Cars.Application.ViewModels.CarType;
using Cars.Constant;
using Cars.DomainHelper.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Api.Controllers.Api
{
    public class CarTypeController : ApiController
    {
        private readonly ICarTypeAppService _CarTypeAppService;

        public CarTypeController(ICarTypeAppService CarTypeAppService)
        {
            _CarTypeAppService = CarTypeAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [Route(ServiceNameCommon.GetAll)]
        public async Task<IActionResult> Get()
        {
            var result = await _CarTypeAppService.GetAll();
            Response.Message = ErrorMessage.Success;
            Response.Success = true;
            Response.data = result;
            return CustomResponse(Response);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [Route(ServiceNameCommon.GetById)]
        public async Task<IActionResult> Get([Required] long idn)
        {
            var result = await _CarTypeAppService.GetById(idn);
            Response.Message = ErrorMessage.Success;
            Response.Success = true;
            Response.data = result;
            return CustomResponse(Response);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [Route(ServiceNameCommon.GetAllPaged)]
        public async Task<IActionResult> GetAllPaged([FromQuery] CarTypeFilter filter)
        {
            var result = CustomResponse(await _CarTypeAppService.GetAllPaged(filter).ConfigureAwait(false));
            Response.Message = ErrorMessage.Success;
            Response.Success = true;
            Response.data = result;
            return CustomResponse(Response);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [Route(ServiceNameCommon.GetAllExported)]
        public async Task<IActionResult> Export([FromQuery] CarTypeFilter filter)
        {
            var result = CustomResponse(await _CarTypeAppService.GetAllExported(filter).ConfigureAwait(false));
            Response.Message = ErrorMessage.Success;
            Response.Success = true;
            Response.data = result;
            return CustomResponse(Response);
        }

        //[CustomAuthorize("Customers", "Write")]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [Route(ServiceNameCommon.Add)]
        public async Task<IActionResult> Post([FromBody] CarTypeViewModel carTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                Response.Message = ErrorMessage.Error;
                Response.Success = false;
                Response.data = ModelState;
                return CustomResponse(ModelState);
            }
            await _CarTypeAppService.Add(carTypeViewModel);
            Response.Message = "";
            Response.Success = true;
            return CustomResponse(Response);
        }

        //[CustomAuthorize("carTypes", "Write")]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [Route(ServiceNameCommon.Update)]
        public async Task<IActionResult> Put([FromBody] CarTypeViewModel carTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                Response.Message = ErrorMessage.Error;
                Response.Success = false;
                return CustomResponse(ModelState);
            }
            await _CarTypeAppService.Update(carTypeViewModel);
            Response.Message = ErrorMessage.Success;
            Response.Success = true;
            return CustomResponse(Response);
        }


        //[CustomAuthorize("carTypes", "Remove")]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [Route(ServiceNameCommon.Delete)]
        public async Task<IActionResult> Delete([Required] long idn)
        {
            await _CarTypeAppService.Remove(idn);
            Response.Message = ErrorMessage.Success;
            Response.Success = true;
            return CustomResponse(Response);
        }

    }
}
