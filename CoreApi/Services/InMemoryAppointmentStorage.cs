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
        public async Task<bool> Book(AppointmentModel model)
        {
            InMemoryDatabase.Appointments.AddLast(model);
            return true;
        }

        public async Task<bool> Cancel(AppointmentModel model)
        {
            if (!InMemoryDatabase.Appointments.Contains(model))
                return false;
            InMemoryDatabase.Appointments.Remove(model);
            return true;
        }

    }
}
