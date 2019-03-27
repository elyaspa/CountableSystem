using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;


namespace CS.Model.Catalog
{
   //[DefaultClassOptions]
    //[NavigationItem("Catálogos")]
    //[ModelDefault("Caption", "Calendario Fiscal")]
    //[Persistent(Constantes.PrefijoTabla + "CALENDARIO_FISCAL")]
    //[DescripcionObjetos("Calendario de trabajo")]
    //[VisibleInReports(false)]
    //[DefaultProperty("Inicial")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class FiscalCalendar : CompanyBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public FiscalCalendar(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        int initial;
        public int Initial
        {
            get { return initial; }
            set => SetPropertyValue(nameof(Initial), ref initial, value);
        }

        int final;
        public int Final
        {
            get { return final; }
            set { SetPropertyValue(nameof(Final), ref final, value); }
        }


        [Association("FiscalCalendar-Cycle"),DevExpress.Xpo.Aggregated]
        public XPCollection<FiscalCalendarCycle> Cycle
        {
            get
            {
                return GetCollection<FiscalCalendarCycle>(nameof(Cycle));
            }
        }

    }
}