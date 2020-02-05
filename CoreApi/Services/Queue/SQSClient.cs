using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using CoreApiModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CoreApi.Services.Queue
{
    public class SQSClient : IQueueClientService
    {
        public  IConfiguration Configuration { get; }

        public SQSClient(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        bool IQueueClientService.SendMessage(AppointmentModel appointment, string operation)
        {
            IAmazonSQS sqs = new AmazonSQSClient(RegionEndpoint.USEast2);
            var queueUrl = sqs.GetQueueUrlAsync(Configuration.GetValue<string>("DASAppointmentsQueueName")).Result.QueueUrl;
            var message = new SQSMessageModel
            {
                Op = operation,
                Appointment = appointment
            };
            var sqsMessageRequest = new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = JsonConvert.SerializeObject(message),
                MessageGroupId = "Appointments",
                //MessageDeduplicationId = Guid.NewGuid().ToString(),
            };
            try
            {
                SendMessageResponse response = sqs.SendMessageAsync(sqsMessageRequest).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

           

            return true;
        }
    }
}
