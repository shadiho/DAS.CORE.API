using DASInMemoryDatabase;
using CoreApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Services
{
    public class InMemoryAppointmentStorage : IAppointmentStorageService
    {
        public async Task<string> Book(AppointmentModel model)
        {
            model.AppointmentID = Guid.NewGuid().ToString();
            model.CreationDateTime = DateTime.Now;
            InMemoryDatabase.Appointments.Add(model);
            return await Task.FromResult(model.AppointmentID);
        }

        public async Task<bool> Cancel(AppointmentModel model)
        {
            AppointmentModel itemToBeRemoved = InMemoryDatabase.Appointments.SingleOrDefault(m => m.AppointmentID == model.AppointmentID);
            if (itemToBeRemoved  == null)
                return false;
            InMemoryDatabase.Appointments.Remove(itemToBeRemoved);
            return await Task.FromResult(true);
        }

    }
}
