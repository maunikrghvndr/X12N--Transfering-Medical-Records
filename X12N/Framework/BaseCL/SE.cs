using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.BaseCL
{
    class SE : Base, Protocol
    {

        public void SetValues(DataTable dt,int count)
        {
            this.parsedValue = String.Format("SE*{0}*{1}~", count.ToString(), dt.Rows[rowNum]["batchNum"].ToString());

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }

        public override void SetValues(DataTable dt)
        {
            throw new NotImplementedException();
        }
    }
}
