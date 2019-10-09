using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gwent.Data
{
    public class DatabaseIntializer : DropCreateDatabaseAlways<Context>
    {

    }
}