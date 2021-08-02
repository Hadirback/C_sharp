﻿using System;
using System.Threading;

namespace ITVDN_Async_Programming
{
    internal class TPWorker<TResult>
    {
        private readonly Func<object, TResult> func;
        private TResult result;

        public TPWorker(Func<object, TResult> func)
        {
            this.func = func ?? throw new ArgumentNullException(nameof(func));
            result = default;
        }

        public bool Success { get; private set; } = false;
        public bool Completed { get; private set; } = false;
        public Exception Exception { get; private set; } = null;

        public TResult Result
        {
            get
            {
                while (Completed == false)
                    Thread.Sleep(150);

                return Success == true && Exception == null ? result : throw Exception;
            }
        }

        public void Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), state);
        }

        public void ThreadExecution(object state)
        {
            try
            {
                result = func.Invoke(state);
                Success = true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                Success = false;
            }
            finally
            {
                Completed = true;
            }
        }
    }
}
