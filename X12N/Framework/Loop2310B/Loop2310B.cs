using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop2310B
{
    class Loop2310B : Base, Protocol
    {
        public Loop2310B(int rowCnt)
        {
            this.rowNum = rowCnt;
        }

        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue = String.Format("NM1*82*1*{0}*{1}****XX*{2}~", dt.Rows[rowNum]["PRESCR_LAST_NAME"].ToString(), dt.Rows[rowNum]["PRESCR_FIRST_NAME"].ToString(),
                dt.Rows[rowNum]["PRESCR_ID"].ToString());

             if (this._childNode != null)
                this._childNode.SetValues(dt);
        }
    }
}
