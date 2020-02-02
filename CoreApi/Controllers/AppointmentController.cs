using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Services;
using CoreApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/v1/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentStorageService _appointmentStorageService;

        public AppointmentController(IAppointmentStorageService appointmentStorageService)
        {
            _appointmentStorageService = appointmentStorageService;
        }

        [HttpPost]
        [Route("Book")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Book(AppointmentModel model)
        {
            try
            {
                bool ok = await _appointmentStorageService.Book(model);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return new OkResult();
        }

        [HttpDelete]
        [Route("Cancel")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cancel(AppointmentModel model)
        {
            try
            {
                bool ok = await _appointmentStorageService.Cancel(model);
                if (!ok)
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return new OkResult();
        }
    }
}