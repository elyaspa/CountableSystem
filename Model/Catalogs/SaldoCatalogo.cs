using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{
    [DefaultClassOptions]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SaldoCatalogo : CompanyBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SaldoCatalogo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        decimal saldoFinal;
        decimal credito;
        decimal debito;
        decimal saldoInicial;
        Catalogo cuentaContable;
        CalendarioFiscalPeriodo periodo;

        public CalendarioFiscalPeriodo Periodo
        {
            get { return periodo; }
            set { SetPropertyValue(nameof(Periodo), ref periodo, value); }
        }


        public Catalogo CuentaContable
        {
            get { return cuentaContable; }
            set { SetPropertyValue(nameof(CuentaContable), ref cuentaContable, value); }
        }


        public decimal SaldoInicial
        {
            get { return saldoInicial; }
            set { SetPropertyValue(nameof(SaldoInicial), ref saldoInicial, value); }
        }


        public decimal Debito
        {
            get { return debito; }
            set { SetPropertyValue(nameof(Debito), ref debito, value); }
        }


        public decimal Credito
        {
            get { return credito; }
            set { SetPropertyValue(nameof(Credito), ref credito, value); }
        }

        
        public decimal SaldoFinal
        {
            get { return saldoFinal; }
            set { SetPropertyValue(nameof(SaldoFinal), ref saldoFinal, value); }
        }
    }
}