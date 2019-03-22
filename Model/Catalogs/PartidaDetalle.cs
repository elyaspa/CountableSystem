using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{
    [DefaultClassOptions]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class PartidaDetalle : AuditableBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public PartidaDetalle(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        CentroDeCosto centroCosto;
        decimal credito;
        decimal debito;
        string concepto;
        Catalogo cuentaContable;
        Partida partida;
        [Association("Partida-Detalles")]
        public Partida Partida
        {
            get { return partida; }
            set { SetPropertyValue(nameof(Partida), ref partida, value); }
        }


        public Catalogo CuentaContable
        {
            get { return cuentaContable; }
            set { SetPropertyValue(nameof(CuentaContable), ref cuentaContable, value); }
        }


        [Size(SizeAttribute.Unlimited)]
        public string Concepto
        {
            get { return concepto; }
            set { SetPropertyValue(nameof(Concepto), ref concepto, value); }
        }



        public decimal Debito
        {
            get {return debito; }
            set { SetPropertyValue(nameof(Debito), ref debito, value); }
        }


        public decimal Credito
        {
            get { return credito; }
            set { SetPropertyValue(nameof(Credito), ref credito, value); }
        }

        
        public CentroDeCosto CentroCosto
        {
            get { return centroCosto; }
            set { SetPropertyValue(nameof(CentroCosto), ref centroCosto, value); }
        }

    }
}