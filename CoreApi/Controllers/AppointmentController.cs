using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Services;
using CoreApi.Services.Queue;
using CoreApiModels;
using Microsoft.AspNetCore.Mvc;


namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/v1/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentStorageService _appointmentStorageService;
        private readonly IQueueClientService _queueClientService;
        public AppointmentController(IAppointmentStorageService appointmentStorageService,IQueueClientService queueClientService)
        {
            _appointmentStorageService = appointmentStorageService;
            _queueClientService = queueClientService;
        }


        [HttpGet]
        [Route("GetAppointment")]
        [ProducesResponseType(200)]
        public async Task<AppointmentModel> GetAppointment()
        {

            return new AppointmentModel() { DoctorId = "1234", PatientId = "234455", FromDate = DateTime.Now, ToDate = DateTime.Now };

        }

        [HttpPost]
        [Route("Book")]
        [ProducesResponseType(200, Type = typeof(AppointmentModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Book(AppointmentModel model)
        {
            try
            {
                string appointmentId = await _appointmentStorageService.Book(model);
                model.AppointmentID = appointmentId;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            _queueClientService.SendMessage(model,"bookAppointment");
            return StatusCode(201, model);
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
            _queueClientService.SendMessage(model, "cancelAppointment");
            return new OkResult();
        }
    }
}