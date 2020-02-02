﻿using CoreApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Database
{
    public static class InMemoryDatabase
    {
        public static AppointmentsTable Appointments { get; set; }
        public static DoctorsTable Doctors { get; set; }

        public static PatientsTable Patients { get; set; }

        public static void Initialize()
        {
            Appointments = new AppointmentsTable();
            Doctors = new DoctorsTable();
            Patients = new PatientsTable();

            Patients.Add(new PatientModel() { PatientId = "19860813-XXXX", PatientName = "Henrik Karlsson" });
            Patients.Add(new PatientModel() { PatientId = "19750612-XXXX", PatientName = "Erik Henriksson" });
            Patients.Add(new PatientModel() { PatientId = "19600519-XXXX", PatientName = "Cecilia Eliasson" });

            Doctors.Add(new DoctorModel() { DoctorId = "201012-1425", DoctorName = "Mikael Seström" });
            Doctors.Add(new DoctorModel() { DoctorId = "200911-1758", DoctorName = "Carina Axel" });
            Doctors.Add(new DoctorModel() { DoctorId = "199005-1875", DoctorName = "Martin Eriksson" });
        }

    }
}
