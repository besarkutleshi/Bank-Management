using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ICrud<T> : IReader<T> , IDelete<T> , IInsert<T> , IUpdate<T>
    {
    }
}
