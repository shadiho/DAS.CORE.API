﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApiModels
{
    public class AppointmentModel
    {
        public string AppointmentID { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
