using System.Collections.Generic;
using System.Linq;
using Cars.Api.Messages;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cars.Api.Controllers.Api
{
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(GenericSuccessResponse<object>), StatusCodes.Status200OK)]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        public readonly GenericResponse Response = new GenericResponse();

        private readonly ICollection<string> _errors = new List<string>();
        //private readonly GenericSuccessResponse<object> Response = new GenericSuccessResponse<object>();

        protected ActionResult CustomResponse(object result = null, bool isBadRequest = false, bool isDownloadFile = false)
        {
            if (isBadRequest)
            {
                return BadRequest();
            }

            if (isDownloadFile)
            {
                return Accepted(new
                {
                    Success = true,
                    data = result
                });
            }

            if (IsOperationValid())
            {
                return Ok(new
                {
                    Success = true,
                    data = result
                });
            }

            return Ok(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(GenericResponse model)
        {
            return Ok(model);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
