using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Dispatcher.Core.Jobs.Interfaces
{
    /// <summary>
    /// To run any type of jobs, just implement IJob interface
    /// </summary>
    public interface IJob
    {
        public Task Todo();

    }
}
