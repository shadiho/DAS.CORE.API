using CoreApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Services.Queue
{
    public interface IQueueClientService
    {
        public bool SendMessage(AppointmentModel appointment, string operation);
    }
}
