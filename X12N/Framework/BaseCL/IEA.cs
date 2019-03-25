using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.BaseCL
{
    class IEA : Base, Protocol
    {
        public override void SetValues(DataTable dt)
        {
            this.parsedValue = "IEA*1*082013837~";

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }

    }
}
