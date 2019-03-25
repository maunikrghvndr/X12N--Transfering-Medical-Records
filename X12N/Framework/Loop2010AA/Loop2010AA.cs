using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop2010AA
{
    class Loop2010AA : Base, Protocol
    {
        public Loop2010AA(int rowCnt)
        {
            this.rowNum = rowCnt;
        }

        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue = 
                String.Format("HL*{0}**20*1~NM1*85*2*{1}~",hlNum++,dt.Rows[rowNum]["PHARM_NAME"].ToString()) + 
                String.Format("N3*{0}~",dt.Rows[rowNum]["PHARM_ADDRESS"].ToString()) +
                String.Format("N4*{0}*{1}*{2}~", dt.Rows[rowNum]["PHARM_CITY"].ToString(), dt.Rows[rowNum]["PHARM_STATE"].ToString(), dt.Rows[rowNum]["PHARM_ZIP"].ToString()) +
                String.Format("REF*EI*941340523~") +
                String.Format("PER*IC**TE*{0}~", dt.Rows[rowNum]["PHARM_PHONE"].ToString());

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }

    }
}
