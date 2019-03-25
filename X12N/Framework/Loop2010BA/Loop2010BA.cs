using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop2010BA
{
    class Loop2010BA : Base, Protocol
    {
        public Loop2010BA(int rowCnt)
        {
            this.rowNum = rowCnt;
        }

        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue = 
                
            String.Format("HL*{0}*1*22*1~",hlNum++) +
            String.Format("SBR*P**{0}*{1}*****WC~", dt.Rows[rowNum]["PAYER_CLAIM_NUMBER"].ToString(), dt.Rows[rowNum]["EMP_NAME"].ToString()) +
            String.Format("NM1*IL*2*{0}~N3*{1}~", dt.Rows[rowNum]["EMP_NAME"].ToString(),dt.Rows[rowNum]["EMP_ADDRESS"].ToString()) +
            String.Format("N4*{0}*{1}*{2}~", dt.Rows[rowNum]["EMP_CITY"].ToString(), dt.Rows[rowNum]["EMP_STATE"].ToString(), dt.Rows[rowNum]["EMP_ZIP"].ToString());
                        
            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }

    }
}
