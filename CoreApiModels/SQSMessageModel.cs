using CoreApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiModels
{
    public class SQSMessageModel
    {
        public string Op { get; set; }

        public AppointmentModel Appointment { get; set; }
    }
}
