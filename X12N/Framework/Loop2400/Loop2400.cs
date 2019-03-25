using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop2400
{
    class Loop2400 : Base, Protocol
    {

        public Loop2400(int rowCnt)
        {
            this.rowNum = rowCnt;
        }
        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue = String.Format("LX*1~SV1*HC:99070:::::{0}*{1}*UN*{2}***1~", dt.Rows[rowNum]["LABEL_NAME"].ToString(), dt.Rows[rowNum]["GrossAmtDue"].ToString(), dt.Rows[rowNum]["QUANTITY_DISPENSED"].ToString()) +
                String.Format("DTP*472*D8*{0}~QTY*PT*{1}~", dt.Rows[rowNum]["RX_SOLD_DATE"].ToString(), dt.Rows[rowNum]["DAYS_SUPPLY"].ToString()) +
                String.Format("LIN**N4*{0}~CTP****{1}*UN~REF*XZ*{2}~", dt.Rows[rowNum]["PRODUCT_ID"].ToString(), dt.Rows[rowNum]["QUANTITY_DISPENSED"].ToString(), dt.Rows[rowNum]["PRESCRIPTION_REF"].ToString());

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }
    }
}
