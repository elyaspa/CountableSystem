using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{
    //[DefaultClassOptions]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemDetail : AuditableBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemDetail(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        CostCenter costCenter;
        decimal credit;
        decimal debt;
        string concept;
        Catalog contableAccount;
        Item item;
        [Association("Item-Details")]
        public Item Item
        {
            get { return item; }
            set { SetPropertyValue(nameof(Item), ref item, value); }
        }


        public Catalog ContableAccount
        {
            get { return contableAccount; }
            set { SetPropertyValue(nameof(ContableAccount), ref contableAccount, value); }
        }


       // [Size(SizeAttribute.Unlimited)]
        public string Concept
        {
            get { return concept; }
            set { SetPropertyValue(nameof(Concept), ref concept, value); }
        }



        public decimal Debt
        {
            get {return debt; }
            set { SetPropertyValue(nameof(Debt), ref debt, value); }
        }


        public decimal Credit
        {
            get { return credit; }
            set { SetPropertyValue(nameof(Credit), ref credit, value); }
        }

        
        public CostCenter CostCenter
        {
            get { return costCenter; }
            set { SetPropertyValue(nameof(CostCenter), ref costCenter, value); }
        }

    }
}