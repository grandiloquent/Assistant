﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers
{
   static class TaskHelper
    {
        public static Task Run(Action thread)
        {
            return Task.Factory.StartNew(thread);
        }

        public static Task Run(Action thread, Action completed, bool completedInFormThread = true)
        {
            TaskScheduler taskScheduler;

            if (completedInFormThread)
            {
                taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            }
            else
            {
                taskScheduler = TaskScheduler.Current;
            }

            return Run(thread).ContinueWith(task => completed(), taskScheduler);
        }

        public static void RunDelayed(Action thread, int delay)
        {
            if (delay > 0)
            {
                Run(() => Thread.Sleep(delay), thread);
            }
            else
            {
                thread();
            }
        }
    }
}
