using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop2000C
{
    class Loop2000C : Base, Protocol
    {

        public Loop2000C(int rowCnt)
        {
            this.rowNum = rowCnt;
        }
        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue = String.Format("HL*{0}*2*23*0~PAT*20~",hlNum++);


            if (this._childNode != null)
                this._childNode.SetValues(dt);

        }
    }
}
