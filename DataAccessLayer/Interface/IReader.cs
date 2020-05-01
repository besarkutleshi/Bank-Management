using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IReader<T>
    {
        Task<IEnumerable<T>> Read();
        Task<T> Read(int id);
        Task<T> Read(string name);
    }
}
