using System;
using Xunit;
using CoreApi.Services;
using CoreApiModels;
using System.Threading.Tasks;

namespace CoreAPI.Test
{
    public class UnitTest1: IClassFixture<InMemoryDatabaseFixture>
    {
        public AppointmentModel bookAppointment()
        {
            IAppointmentStorageService storageSrv = new InMemoryAppointmentStorage();
            AppointmentModel app = new AppointmentModel();
            app.PatientId = "19860813-XXXX";
            app.DoctorId = "201012-1425";
            app.FromDate = new DateTime(2020, 3, 1, 14, 0, 0);
            app.FromDate = new DateTime(2020, 3, 1, 15, 0, 0);
            storageSrv.Book(app);
            return app;
        }

        public async Task<bool> cancelAppointment(AppointmentModel appointment)
        {
            IAppointmentStorageService storageSrv = new InMemoryAppointmentStorage();
            return await storageSrv.Cancel(appointment);
        }
        [Fact]
        public void TestAppointmentBooking()
        {
            AppointmentModel app= bookAppointment();

            Assert.True(!string.IsNullOrEmpty(app.AppointmentID));
        }

        [Fact]
        public void TestAppointmentCanceling()
        {
            AppointmentModel app = bookAppointment();
            Boolean result = cancelAppointment(app).Result;
            Assert.True(result);
        }
    }
}
