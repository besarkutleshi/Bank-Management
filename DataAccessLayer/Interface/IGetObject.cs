using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IGetObject<T>
    {
        T GetObject(SqlDataReader sdr);
    }
}
