using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{
    //[DefaultClassOptions]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class BalanceCatalog : CompanyBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public BalanceCatalog(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        decimal finalBalance;
        decimal credit;
        decimal debt;
        decimal initialBalance;
        Catalog countableAccount;
        FiscalCalendarCycle cycle;

        public FiscalCalendarCycle Cycle
        {
            get { return cycle; }
            set { SetPropertyValue(nameof(Cycle), ref cycle, value); }
        }


        public Catalog CountableAccount
        {
            get { return countableAccount; }
            set { SetPropertyValue(nameof(CountableAccount), ref countableAccount, value); }
        }


        public decimal InitialBalance
        {
            get { return initialBalance; }
            set { SetPropertyValue(nameof(InitialBalance), ref initialBalance, value); }
        }


        public decimal Debt
        {
            get { return debt; }
            set { SetPropertyValue(nameof(Debt), ref debt, value); }
        }


        public decimal Credit
        {
            get { return credit; }
            set { SetPropertyValue(nameof(Credit), ref credit, value); }
        }

        
        public decimal FinalBalance
        {
            get { return finalBalance; }
            set { SetPropertyValue(nameof(FinalBalance), ref finalBalance, value); }
        }
    }
}