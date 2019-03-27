using CS.Model.Utilities;
using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;

namespace CS.Model.Catalog
{
   // [DefaultClassOptions]
    //[ModelDefault("Caption", "Periodos")]
    //[Persistent(Constantes.PrefijoTabla + "CALENDARIO_FISCAL_PERIODOS")]
    //[DescripcionObjetos("Periodos del calendario fiscal")]
    //[VisibleInReports(false)]
    //[DefaultProperty("Item")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class FiscalCalendarCycle : AuditableBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public FiscalCalendarCycle(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        FiscalCalendar fiscalCalendar;
        [Association("FiscalCalendar-Cycle")]
        public FiscalCalendar FiscalCalendar
        {
            get { return fiscalCalendar; }
            set { SetPropertyValue(nameof(FiscalCalendar), ref fiscalCalendar, value); }
        }

        int item;
        public int Item
        {
            get { return item; }
            set { SetPropertyValue(nameof(Item), ref item, value); }
        }

        DateTime initialDate;
        public DateTime InitialDate
        {
            get { return initialDate; }
            set { SetPropertyValue(nameof(InitialDate), ref initialDate, value); }
        }

        DateTime finalDate;
        public DateTime FinalDate
        {
            get { return finalDate; }
            set { SetPropertyValue(nameof(FinalDate), ref finalDate, value); }
        }

        Enums.PeriodStatus status;
        public Enums.PeriodStatus Status
        {
            get { return status; }
            set { SetPropertyValue(nameof(Status), ref status, value); }
        }

    }
}