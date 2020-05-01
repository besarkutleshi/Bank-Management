using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDelete<T>
    {
        Task<ActionResult<T>> Delete(int id);
    }
}
