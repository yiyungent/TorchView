using System;
using System.Collections.Generic;
using System.Text;

namespace TorchView
{
    public interface ILogger
    {

        void Info(string message);

        void Error(string message, Exception exception);

    }
}
