﻿using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Helpers
{
    public class Logger
    {
        public delegate void MessageAddedEventHandler(string message);

        public event MessageAddedEventHandler MessageAdded;

        public string MessageFormat { get; set; } = "{0:yyyy-MM-dd HH:mm:ss.fff} - {1}";
        public bool AsyncWrite { get; set; } = true;
        public bool DebugWrite { get; set; } = true;
        public bool StringWrite { get; set; } = true;
        public bool FileWrite { get; set; } = false;
        public string LogFilePath { get; private set; }

        private readonly object loggerLock = new object();
        private ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();
        private StringBuilder sbMessages = new StringBuilder();

        public Logger()
        {
        }

        public Logger(string logFilePath)
        {
            FileWrite = true;
            LogFilePath = logFilePath;
            LogFilePath.CreateDirectoryFromFilePath();
        }

        protected void OnMessageAdded(string message)
        {
            if (MessageAdded != null)
            {
                MessageAdded(message);
            }
        }

        private void ProcessMessageQueue()
        {
            lock (loggerLock)
            {
                while (messageQueue.TryDequeue(out string message))
                {
                    if (DebugWrite)
                    {
                        Debug.Write(message);
                    }

                    if (StringWrite && sbMessages != null)
                    {
                        sbMessages.Append(message);
                    }

                    if (FileWrite && !string.IsNullOrEmpty(LogFilePath))
                    {
                        try
                        {
                            File.AppendAllText(LogFilePath, message, Encoding.UTF8);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e);
                        }
                    }

                    OnMessageAdded(message);
                }
            }
        }

        public void Write(string message)
        {
            if (message != null)
            {
                message = string.Format(MessageFormat, DateTime.Now, message);
                messageQueue.Enqueue(message);

                if (AsyncWrite)
                {
                    TaskHelper.Run(() => ProcessMessageQueue());
                }
                else
                {
                    ProcessMessageQueue();
                }
            }
        }

        public void Write(string format, params object[] args)
        {
            Write(string.Format(format, args));
        }

        public void WriteLine(string message)
        {
            Write(message + Environment.NewLine);
        }

        public void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }

        public void WriteException(string exception, string message = "Exception")
        {
            WriteLine($"{message}:{Environment.NewLine}{exception}");
        }

        public void WriteException(Exception exception, string message = "Exception")
        {
            WriteException(exception.ToString(), message);
        }

        public void Clear()
        {
            lock (loggerLock)
            {
                if (sbMessages != null)
                {
                    sbMessages.Clear();
                }
            }
        }

        public override string ToString()
        {
            lock (loggerLock)
            {
                if (sbMessages != null && sbMessages.Length > 0)
                {
                    return sbMessages.ToString();
                }

                return null;
            }
        }
    }
}
