using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Notos.Database.Interfaces
{
    public interface IConnection
    {
        IDbConnection CreateConnection();
    }
}
