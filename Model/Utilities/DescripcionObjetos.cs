using System;

namespace CS.Model.Utilities
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
