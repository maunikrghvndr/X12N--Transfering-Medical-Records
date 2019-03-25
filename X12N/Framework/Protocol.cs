using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework
{
    interface Protocol
    {
        void SetValues(DataTable dt);

    }
}
