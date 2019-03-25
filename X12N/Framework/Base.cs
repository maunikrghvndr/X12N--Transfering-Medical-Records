using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Framework
{
    abstract class Base
    {
        protected Base _childNode = null;
        public Base _lastNode = null;
        protected string _fieldSeperator = "*";
        protected string segmentSeperator = "~";
        protected string dateFormat = "yyyyMMdd";
        protected string timeFormat = "HHmm";
        protected int rowNum = 0;
        protected static int hlNum = 1;
        
        
        protected string parsedValue;
        public string ParsedValue { get { return parsedValue;} }


        public Base()
        {
            //_fieldSeperator = Convert.ToChar(28).ToString();
            segmentSeperator = String.Empty;
        }

        public void SetSuccessor(Base childObject)
        {
            this._childNode = childObject;
        }

        public void SetLastSuccessor(Base childObject)
        {
            if (this._childNode != null)
                this._childNode.SetLastSuccessor(childObject);
            else
                this.SetSuccessor(childObject);
        }

        public override string ToString()
        {
            String values = string.Empty;
            Type TObject = this.GetType();

            values = values + this.segmentSeperator;

            foreach (PropertyInfo property in TObject.GetProperties())
            {
                 values = values + property.GetValue(this).ToString();
            }

            if (this._childNode != null)
                values = values + _childNode.ToString();

            return values;
        }

        public string ConvertTodate(string dateValue)
        {
            return dateValue.Substring(0, 4) + '-' + dateValue.Substring(4, 2) + '-' + dateValue.Substring(6, 2);
        }

        public abstract void SetValues(DataTable dt);

        protected string TruncateOrPad(string value, int len)
        {
            if (value.Length > len)
                return value.Substring(0, len);
            else
                return value + new StringBuilder().Append(' ', len - value.Length);
        }
    }
}
