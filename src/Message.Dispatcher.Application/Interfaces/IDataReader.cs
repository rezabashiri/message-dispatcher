using System.Runtime.InteropServices;

namespace Message.Dispatcher.Application.Interfaces
{
    public interface IDataReader<T>  
    {
      public Task<IDataReaderResponse<List<T>>> GetList(string path);
    }
}