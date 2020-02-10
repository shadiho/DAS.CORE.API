using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Services;
using CoreApi.Services.Queue;
using CoreApiModels;
using DASInMemoryDatabase;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace CoreApi.Controllers
{
    [EnableCors("AllowAll")]
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

        [HttpPost]
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

        [HttpPost]
        [Route("ResetApp")]
        public async Task<IActionResult> ResetApp()
        {
            InMemoryDatabase.Appointments.Clear();
            InMemoryDatabase.AppointmentsConflicts.Clear();
            InMemoryDatabase.AppointmentsOpLog.Clear();
            return await Task.FromResult(new OkResult());
        }
    }
}