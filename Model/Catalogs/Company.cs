using CS.Model.Security;
using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CS.Model.Catalog
{
    [DefaultClassOptions]
    //[NavigationItem("Catálogos")]
    //[ModelDefault("Caption", "Empresas")]
    //[Persistent(Constantes.PrefijoTabla + "EMPRESA")]
    //[DescripcionObjetos("Catálogo de Empresas")]
    //[VisibleInReports(false)]
    //[DefaultProperty("Nombre")]    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).

    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Company : AuditableBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Company(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string code;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[ModelDefault("Caption", "Codigo")]
        //[Persistent("CODIGO")]
        //[DescripcionObjetos("Codigo de la empresa")]
        public string Code
        {
            get { return code; }
            set { SetPropertyValue(nameof(Code), ref code, value); }
        }

        string name;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[ModelDefault("Caption", "Nombre")]
        //[Persistent("NOMBRE")]
        //[DescripcionObjetos("Nombre de la empresa")]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        Currency currency;
        //[ModelDefault("Caption", "Moneda")]
        //[Persistent("MONEDA")]
        //[DescripcionObjetos("Moneda de las transacciones de la empresa")]
        public Currency Currency
        {
            get { return currency; }
            set { SetPropertyValue(nameof(Currency), ref currency, value); }
        }

        [Association("User-Companies")]
        public XPCollection<CompanyUser> Users
        {
            get
            {
                return GetCollection<CompanyUser>(nameof(Users));
            }
        }

    }
}