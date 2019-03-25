using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.BaseCL
{
    class BHT : Base, Protocol
    {
        public override void SetValues(DataTable dt)
        {
            this.parsedValue = String.Format("BHT*0019*00*{0}*{1}*{2}*CH~", dt.Rows[0]["ID"].ToString(), DateTime.Now.ToString(this.dateFormat), DateTime.Now.ToString(this.timeFormat));

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }

    }
}
