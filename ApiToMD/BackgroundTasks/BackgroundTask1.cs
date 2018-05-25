using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Windows.ApplicationModel.Background;
using Windows.System.Threading;

namespace ApiToMD.BackgroundTasks
{
    public sealed class BackgroundTask1 : BackgroundTask
    {
        public static string Message { get; set; }

        private volatile bool _cancelRequested = false;
        private IBackgroundTaskInstance _taskInstance;
        private BackgroundTaskDeferral _deferral;

        public override void Register()
        {
            var taskName = GetType().Name;

            if (!BackgroundTaskRegistration.AllTasks.Any(t => t.Value.Name == taskName))
            {
                var builder = new BackgroundTaskBuilder()
                {
                    Name = taskName
                };

                // TODO WTS: Define the trigger for your background task and set any (optional) conditions
                // More details at https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-an-inproc-background-task
                builder.SetTrigger(new TimeTrigger(15, false));
                builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));

                builder.Register();
            }
        }

        public override void RunInternal(IBackgroundTaskInstance taskInstance)
        {
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);
            _deferral = taskInstance.GetDeferral();

            _taskInstance = taskInstance;
            ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(SampleTimerCallback), TimeSpan.FromSeconds(1));
        }

        public override void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            // TODO WTS: Insert code to handle the cancelation request here.
            // Documentation: https://docs.microsoft.com/windows/uwp/launch-resume/handle-a-cancelled-background-task
            _cancelRequested = true;
            Debug.WriteLine("Background " + sender.Task.Name + " Cancel Requested...");
        }

        private void SampleTimerCallback(ThreadPoolTimer timer)
        {
            if ((_cancelRequested == false) && (_taskInstance.Progress < 100))
            {
                _taskInstance.Progress += 10;
                Message = $"Background Task {_taskInstance.Task.Name} running";
            }
            else
            {
                timer.Cancel();

                if (_cancelRequested)
                {
                    Message = $"Background Task {_taskInstance.Task.Name} cancelled";
                }
                else
                {
                    Message = $"Background Task {_taskInstance.Task.Name} finished";
                }

                _deferral?.Complete();
            }
        }
    }
}
