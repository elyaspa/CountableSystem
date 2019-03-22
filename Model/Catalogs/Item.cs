using System;
using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{

    [DefaultClassOptions]
    public class Item : CompanyBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Item(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        FiscalCalendarCycle cycle;
        decimal totalCredit;
        decimal totalDebt;
        string concept;
        ItemType type;
        int number;
        DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { SetPropertyValue(nameof(Date), ref date, value); }
        }


        public int Number
        {
            get { return number; }
            set { SetPropertyValue(nameof(Number), ref number, value); }
        }


        public ItemType Type
        {
            get { return type; }
            set { SetPropertyValue(nameof(Type), ref type, value); }
        }


        [Size(250)]
        public string Concept
        {
            get { return concept; }
            set { SetPropertyValue(nameof(Concept), ref concept, value); }
        }


        public decimal TotalDebt
        {
            get { return totalDebt; }
            set { SetPropertyValue(nameof(TotalDebt), ref totalDebt, value); }
        }


        public decimal TotalCredit
        {
            get { return totalCredit; }
            set { SetPropertyValue(nameof(TotalCredit), ref totalCredit, value); }
        }

        
        public FiscalCalendarCycle Cycle
        {
            get { return cycle; }
            set { SetPropertyValue(nameof(Cycle), ref cycle, value); }
        }

        [Association("Item-Details"),DevExpress.Xpo.Aggregated]
        public XPCollection<ItemDetail> Details
        {
            get
            {
                return GetCollection<ItemDetail>(nameof(Details));
            }
        }

    }
}