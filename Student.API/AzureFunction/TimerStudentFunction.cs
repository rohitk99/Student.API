using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions;
using Microsoft.Extensions.Logging;

namespace Student.API.Azure_Function
{
    namespace MyCompany.Function
    {
        public class TimerStudentFunction
        {
            private readonly ILogger<TimerStudentFunction> _logger;

            // Dependency injection works natively in the Isolated Worker model
            public TimerStudentFunction(ILogger<TimerStudentFunction> logger)
            {
                _logger = logger;
            }

            // Runs every 5 minutes based on the CRON expression
            [Function("ExecutePeriodicTask")]
            public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
            {
                _logger.LogInformation($"Timer trigger executed at: {DateTime.Now}");

                if (myTimer.ScheduleStatus is not null)
                {
                    _logger.LogInformation($"Next scheduled execution: {myTimer.ScheduleStatus.Next}");
                }
            }
        }
    }
}





