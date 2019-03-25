using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop2010CA
{
    class Loop2010CA : Base, Protocol
    {

        public Loop2010CA(int rowCnt)
        {
            this.rowNum = rowCnt;
        }

        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue = String.Format("NM1*QC*1*{0}*{1}~", dt.Rows[rowNum]["PATIENT_LAST_NAME"].ToString(), dt.Rows[rowNum]["PATIENT_FIRST_NAME"].ToString()) +
            String.Format("N3*{0}~", dt.Rows[rowNum]["PATIENT_ADDRESS"].ToString()) +
            String.Format("N4*{0}*{1}*{2}~", dt.Rows[rowNum]["PATIENT_CITY"].ToString(), dt.Rows[rowNum]["PATIENT_STATE"].ToString(), dt.Rows[rowNum]["PATIENT_ZIP"].ToString()) +
            String.Format("DMG*D8*{0}*F~", dt.Rows[rowNum]["PATIENT_DOB"].ToString()) +
            String.Format("REF*SY*{0}~", dt.Rows[rowNum]["PATIENT_ID"].ToString());

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }
    }
}
