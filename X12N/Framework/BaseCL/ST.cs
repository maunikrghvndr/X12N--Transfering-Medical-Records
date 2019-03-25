using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.BaseCL
{
    class ST : Base, Protocol
    {
        public override void SetValues(DataTable dt)
        {
            this.parsedValue = string.Format("ST*837*{0}*005010X222A1~",dt.Rows[rowNum]["batchNum"].ToString());

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }

    }
}
