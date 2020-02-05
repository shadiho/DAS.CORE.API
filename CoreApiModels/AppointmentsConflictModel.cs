using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApiModels
{
    public class AppointmentsConflictModel
    {
        public string ConflictID { get; set; }
        public string Appointment1ID { get; set; }

        public string Appointment2ID { get; set; }

        public DateTime ConflictDateTime { get; set; }
    }
}
