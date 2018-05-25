using System;
using System.Threading.Tasks;

using Windows.ApplicationModel.Background;

namespace ApiToMD.BackgroundTasks
{
    public abstract class BackgroundTask
    {
        public abstract void Register();

        public abstract void RunInternal(IBackgroundTaskInstance taskInstance);


        public abstract void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason);

        public bool Match(string name)
        {
            return name == GetType().Name;
        }

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            SubscribeToEvents(taskInstance);
            RunInternal(taskInstance);
        }

        public void SubscribeToEvents(IBackgroundTaskInstance taskInstance)
        {
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);
        }
    }
}
