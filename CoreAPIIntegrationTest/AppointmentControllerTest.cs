using CoreApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPIIntegrationTest
{
    public class AppointmentControllerTest : IntegrationTestClass
    {
        const string bookURL = "api/v1/appointments/Book";
        const string cancelURL = "api/v1/appointments/Cancel";
        [Fact]
        public async Task BookTest()
        {
            HttpResponseMessage resp = await testClient.PostAsJsonAsync(bookURL, new { patientId = "19860813-XXXX", doctorId = "201012-1425", fromDate = new DateTime(), toDate = new DateTime().AddHours(2)});
            //testClient.ReadAsJsonAsync<AppointmentModel> (resp.Content);
            var res = resp.Content.ReadAsStringAsync();
            AppointmentModel appointment = JsonConvert.DeserializeObject<AppointmentModel>(res.Result);
            appointment.AppointmentID.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Cancel_WrongID_Test()
        {
            HttpResponseMessage resp = await testClient.PostAsJsonAsync(cancelURL, new { appointmentID="222222", patientId = "XX", doctorId = "201012-1425", fromDate = new DateTime(), toDate = new DateTime().AddHours(2) });
            resp.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public  async Task BookAndCancelValidTest()
        {
            HttpResponseMessage resp = await testClient.PostAsJsonAsync(bookURL, new { patientId = "19860813-XXXX", doctorId = "201012-1425", fromDate = new DateTime(), toDate = new DateTime().AddHours(2) });
            var res = resp.Content.ReadAsStringAsync();
            AppointmentModel appointment = JsonConvert.DeserializeObject<AppointmentModel>(res.Result);
            HttpResponseMessage resp1 = await testClient.PostAsJsonAsync(cancelURL, new { appointmentID = appointment.AppointmentID });
            resp1.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        }
    }

    public class CustomResponse
    {
        public string type { get; set; }
        public string title { get; set; }

        public int status { get; set; }

        public string traceId { get; set; }
    }
}
