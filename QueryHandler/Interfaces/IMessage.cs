using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueryHandler.Interfaces
{
    public interface IMessage<T>
    {
        public Task<T> ExecRequestAsync();
    }
}
