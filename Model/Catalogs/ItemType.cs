using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{
   // [DefaultClassOptions]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemType : CompanyBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string code;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Code
        {
            get { return code; }
            set { SetPropertyValue(nameof(Code), ref code, value); }
        }

        string name;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        Catalog account;
        public Catalog Account
        {
            get { return account; }
            set { SetPropertyValue(nameof(Account), ref account, value); }
        }
    }
}