using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop2010BB
{
    class Loop2010BB : Base, Protocol
    {

        public Loop2010BB(int rowCnt)
        {
            this.rowNum = rowCnt;
        }

        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue = 
                
            String.Format("NM1*PR*2*{0}*****PI*PD0010008~", dt.Rows[rowNum]["PAYER"].ToString()) +
            String.Format("N3*{0}~", dt.Rows[rowNum]["PAYER_ADDRESS"].ToString()) +
            String.Format("N4*{0}*{1}*{2}~", dt.Rows[rowNum]["PAYER_CITY"].ToString(), dt.Rows[rowNum]["PAYER_STATE"].ToString(), dt.Rows[rowNum]["PAYER_ZIP"].ToString());

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }

    }
}
