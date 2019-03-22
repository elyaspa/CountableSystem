using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CS.Model.Catalog
{
    [DefaultClassOptions]
    //[NavigationItem("Catálogos")]
    //[ModelDefault("Caption", "Catálogo Base")]
    //[Persistent(Constantes.PrefijoTabla + "CATALOGO_BASE")]
    //[DescripcionObjetos("Catálogo de cuentas comun paras las posibles empresas")]
   // [VisibleInReports(false)]
   // [DefaultProperty("Nombre")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CatalogoBase : AuditableBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CatalogoBase(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        CatalogoBase dependencia;
        public CatalogoBase Dependencia
        {
            get { return dependencia; }
            set { SetPropertyValue(nameof(Dependencia), ref dependencia, value); }
        }

        string numeroCuenta;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NumeroCuenta
        {
            get { return numeroCuenta; }
            set { SetPropertyValue(nameof(NumeroCuenta), ref numeroCuenta, value); }
        }

        string nombre;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get { return nombre; }
            set { SetPropertyValue(nameof(Nombre), ref nombre, value); }
        }

        Enums.CreditType tipoSaldo;
        public Enums.CreditType TipoSaldo
        {
            get {return tipoSaldo; }
            set { SetPropertyValue(nameof(TipoSaldo), ref tipoSaldo, value); }
        }

        int nivel;
        public int Nivel
        {
            get { return nivel; }
            set { SetPropertyValue(nameof(Nivel), ref nivel, value); }
        }

        Enums.AccountType tipo;
        public Enums.AccountType Tipo
        {
            get { return tipo; }
            set { SetPropertyValue(nameof(Tipo), ref tipo, value); }
        }

        Enums.AccountStatus estatus;
        public Enums.AccountStatus Estatus
        {
            get { return estatus; }
            set { SetPropertyValue(nameof(Estatus), ref estatus, value); }
        }

        bool totalizadora;
        public bool Totalizadora
        {
            get { return totalizadora; }
            set { SetPropertyValue(nameof(Totalizadora), ref totalizadora, value); }
        }

        Enums.CreditImpact efecto;
        public Enums.CreditImpact Efecto
        {
            get { return efecto; }
            set { SetPropertyValue(nameof(Efecto), ref efecto, value); }
        }



    }
}