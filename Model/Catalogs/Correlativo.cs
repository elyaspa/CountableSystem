using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{
    [DefaultClassOptions]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Correlativo : CompanyBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Correlativo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        CalendarioFiscalPeriodo periodo;
        public CalendarioFiscalPeriodo Periodo
        {
            get { return periodo; }
            set { SetPropertyValue(nameof(Periodo), ref periodo, value); }
        }

        TipoPartida tipoPartida;
        public TipoPartida TipoPartida
        {
            get { return tipoPartida; }
            set { SetPropertyValue(nameof(TipoPartida), ref tipoPartida, value); }
        }

        int numero;
        public int Numero
        {
            get { return numero; }
            set { SetPropertyValue(nameof(Numero), ref numero, value); }
        }

    }
}