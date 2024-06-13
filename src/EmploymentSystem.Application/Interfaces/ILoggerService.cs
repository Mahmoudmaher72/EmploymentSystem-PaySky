#region Using ...
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace EmploymentSystem.Application.Interfaces
{
    public interface ILoggerService
    {
        void LogError(string content);
        void LogError(Exception ex);
        void LogInfo(string content);
        void LogWarning(string content);
    }
}
