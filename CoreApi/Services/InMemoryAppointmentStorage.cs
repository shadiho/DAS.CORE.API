using CoreApi.Database;
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
            InMemoryDatabase.Appointments.Add(model);
            return model.AppointmentID;
        }

        public async Task<bool> Cancel(AppointmentModel model)
        {
            AppointmentModel itemToBeRemoved = InMemoryDatabase.Appointments.Single(m => m.AppointmentID == model.AppointmentID);
            if (itemToBeRemoved  == null)
                return false;
            InMemoryDatabase.Appointments.Remove(itemToBeRemoved);
            return true;
        }

    }
}
