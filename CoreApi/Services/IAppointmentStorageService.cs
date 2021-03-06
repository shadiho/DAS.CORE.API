﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiModels;

namespace CoreApi.Services
{
    public interface IAppointmentStorageService
    {
        Task<string> Book(AppointmentModel model);
        Task<bool> Cancel(AppointmentModel model);

    }
}
