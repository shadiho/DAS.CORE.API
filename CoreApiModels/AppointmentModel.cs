using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApiModels
{
    public class AppointmentModel
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
