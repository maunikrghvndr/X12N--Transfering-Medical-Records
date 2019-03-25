using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop2310C
{
    class Loop2310C : Base, Protocol
    {

        public Loop2310C(int rowCnt)
        {
            this.rowNum = rowCnt;
        }

        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue =
                String.Format("NM1*77*2*{0}*****XX*{1}~", dt.Rows[rowNum]["PHARM_NAME"].ToString(), dt.Rows[rowNum]["PHARM_ID"].ToString()) +
                String.Format("N3*{0}~", dt.Rows[rowNum]["PHARM_ADDRESS"].ToString()) +
            String.Format("N4*{0}*{1}*{2}~", dt.Rows[rowNum]["PHARM_CITY"].ToString(), dt.Rows[rowNum]["PHARM_STATE"].ToString(), dt.Rows[rowNum]["PHARM_ZIP"].ToString());

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }
    }
}
