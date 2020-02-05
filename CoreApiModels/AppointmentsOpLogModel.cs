using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApiModels
{
    public class AppointmentsOpLogModel
    {
        public string LogID { get; set; }
        public string AppointmentID { get; set; }

        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime CreationDateTime { get; set; }
        public string Operation { get; set; }

        public DateTime LogDateTime { get; set; }


    }
}
