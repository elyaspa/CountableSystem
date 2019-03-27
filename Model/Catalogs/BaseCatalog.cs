using CS.Model.Utilities;

using DevExpress.Xpo;


namespace CS.Model.Catalog
{
    
    //[NavigationItem("Catálogos")]
    //[ModelDefault("Caption", "Catálogo Base")]
    //[Persistent(Constantes.PrefijoTabla + "CATALOGO_BASE")]
    //[DescripcionObjetos("Catálogo de cuentas comun paras las posibles empresas")]
   // [VisibleInReports(false)]
   // [DefaultProperty("Nombre")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class BaseCatalog : AuditableBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public BaseCatalog(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        BaseCatalog dependency;
        public BaseCatalog Dependency
        {
            get { return dependency; }
            set { SetPropertyValue(nameof(Dependency), ref dependency, value); }
        }

        string accountNumber;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AccountNumber
        {
            get { return accountNumber; }
            set { SetPropertyValue(nameof(AccountNumber), ref accountNumber, value); }
        }

        string name;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        Enums.CreditType creditType;
        public Enums.CreditType CreditType
        {
            get { return creditType; }
            set { SetPropertyValue(nameof(CreditType), ref creditType, value); }
        }

        int level;
        public int Level
        {
            get { return level; }
            set { SetPropertyValue(nameof(Level), ref level, value); }
        }

        Enums.AccountType type;
        public Enums.AccountType Type
        {
            get { return type; }
            set { SetPropertyValue(nameof(Type), ref type, value); }
        }

        Enums.AccountStatus status;
        public Enums.AccountStatus Status
        {
            get { return status; }
            set { SetPropertyValue(nameof(Status), ref status, value); }
        }

        bool totalizator;
        public bool Totalizator
        {
            get { return totalizator; }
            set { SetPropertyValue(nameof(Totalizator), ref totalizator, value); }
        }

        Enums.CreditImpact impact;
        public Enums.CreditImpact Impact
        {
            get { return impact; }
            set { SetPropertyValue(nameof(Impact), ref impact, value); }
        }



    }
}