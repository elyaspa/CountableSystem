using System;

namespace CS.Model.Utilities
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class ObjectsDescription : Attribute
    {
        private string _Text;
        public ObjectsDescription(string text)
        {
            _Text = text;
        }
        public string Text
        {
            get { return _Text; }
        }
    }
}
