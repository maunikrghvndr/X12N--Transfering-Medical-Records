using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.BaseCL
{
    class GE : Base, Protocol
    {
        public override void SetValues(DataTable dt)
        {
            this.parsedValue = "GE*1*082013837~";

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }

    }
}
