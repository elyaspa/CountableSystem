using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{
    [DefaultClassOptions]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Correlative : CompanyBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Correlative(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        FiscalCalendarCycle cycle;
        public FiscalCalendarCycle Cycle
        {
            get { return cycle; }
            set { SetPropertyValue(nameof(Cycle), ref cycle, value); }
        }

        ItemType itemType;
        public ItemType ItemType
        {
            get { return itemType; }
            set { SetPropertyValue(nameof(ItemType), ref itemType, value); }
        }

        int number;
        public int Number
        {
            get { return number; }
            set { SetPropertyValue(nameof(Number), ref number, value); }
        }

    }
}