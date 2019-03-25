using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.Loop1000B
{
    class Loop1000B : Base
    {

        public override void SetValues(System.Data.DataTable dt)
        {
            this.parsedValue = "NM1*40*2*P2PLINK*****46*8664503898~";

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }
    }
}
