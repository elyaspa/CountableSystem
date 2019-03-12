using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountableSystem.Module.BusinessObjects.Utilities
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class DescripcionObjetos : Attribute
    {
        private string _Text;
        public DescripcionObjetos(string text)
        {
            _Text = text;
        }
        public string Text
        {
            get { return _Text; }
        }
    }
}
