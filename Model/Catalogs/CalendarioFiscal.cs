using CS.Model.Utilities;
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
    public class CalendarioFiscal : ObjetoBaseEmpresa
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CalendarioFiscal(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        int inicial;
        public int Inicial
        {
            get { return inicial; }
            set => SetPropertyValue(nameof(Inicial), ref inicial, value);
        }

        int final;
        public int Final
        {
            get { return final; }
            set { SetPropertyValue(nameof(Final), ref final, value); }
        }


        [Association("CalendarioFiscal-Periodos"),DevExpress.Xpo.Aggregated]
        public XPCollection<CalendarioFiscalPeriodo> Periodos
        {
            get
            {
                return GetCollection<CalendarioFiscalPeriodo>(nameof(Periodos));
            }
        }

    }
}