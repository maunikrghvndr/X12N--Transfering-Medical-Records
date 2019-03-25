using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop1000A
{
    class Loop1000A : Base
    {
        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue = 
                String.Format("NM1*41*2*RISARC*****46*880492251~PER*IC*{0}*TE*{1}~","Tamara Hill","8189533020");

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }
    }
}
