using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop2300
{
    class Loop2300 : Base, Protocol
    {
        public Loop2300(int rowCnt)
        {
            // TODO: Complete member initialization
            this.rowNum = rowCnt;
        }
        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue =
                String.Format("CLM*{0}*{1}***01:B:1*Y*A*Y*Y**EM~", dt.Rows[rowNum]["ID"].ToString(), dt.Rows[rowNum]["GrossAmtDue"].ToString()) +
            String.Format("DTP*439*D8*{0}~HI*ABK:{1}~", dt.Rows[rowNum]["INJURY_DATE"].ToString(), dt.Rows[rowNum]["PRIMARY_ICD9"].ToString());

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }
    }
}
