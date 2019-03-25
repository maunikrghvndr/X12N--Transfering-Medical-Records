using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.BaseCL
{
    class ISA : Base, Protocol
    {
        public override void SetValues(DataTable dt)
        {
            this.parsedValue = String.Format("ISA*00*          *00*          *ZZ*880492251      *ZZ*8664503898     *{0}*{1}*^*00501*082013837*1*T*:~", DateTime.Now.ToString("yyMMdd"), DateTime.Now.ToString(this.timeFormat));

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }
    }
}
