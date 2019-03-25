using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework.BaseCL
{
    class GS : Base, Protocol
    {
        public override void SetValues(DataTable dt)
        {
            this.parsedValue = String.Format("GS*HC*880492251*8664503898*{0}*{1}*082013837*X*005010X222A1~", DateTime.Now.ToString(this.dateFormat), DateTime.Now.ToString(this.timeFormat));

            if (this._childNode != null)
                this._childNode.SetValues(dt);
        }

    }
}
