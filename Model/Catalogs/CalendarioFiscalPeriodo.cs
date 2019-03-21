using CS.Model.Utilities;
using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;

namespace CS.Model.Catalog
{
    [DefaultClassOptions]
    //[ModelDefault("Caption", "Periodos")]
    //[Persistent(Constantes.PrefijoTabla + "CALENDARIO_FISCAL_PERIODOS")]
    //[DescripcionObjetos("Periodos del calendario fiscal")]
    //[VisibleInReports(false)]
    //[DefaultProperty("Item")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CalendarioFiscalPeriodo : ObjetoBaseAuditable
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CalendarioFiscalPeriodo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        CalendarioFiscal calendarioFiscal;
        [Association("CalendarioFiscal-Periodos")]
        public CalendarioFiscal CalendarioFiscal
        {
            get { return calendarioFiscal; }
            set { SetPropertyValue(nameof(CalendarioFiscal), ref calendarioFiscal, value); }
        }

        int item;
        public int Item
        {
            get { return item; }
            set { SetPropertyValue(nameof(Item), ref item, value); }
        }

        DateTime fechaInicial;
        public DateTime FechaInicial
        {
            get { return fechaInicial; }
            set { SetPropertyValue(nameof(FechaInicial), ref fechaInicial, value); }
        }

        DateTime fechaFinal;
        public DateTime FechaFinal
        {
            get { return fechaFinal; }
            set { SetPropertyValue(nameof(FechaFinal), ref fechaFinal, value); }
        }

        Enumeradores.EstatusPeriodo estatus;
        public Enumeradores.EstatusPeriodo Estatus
        {
            get { return estatus; }
            set { SetPropertyValue(nameof(Estatus), ref estatus, value); }
        }

    }
}