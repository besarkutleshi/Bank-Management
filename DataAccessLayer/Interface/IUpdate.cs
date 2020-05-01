using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IUpdate<T>
    {
        Task<ActionResult<T>> Update(T obj);
    }
}
