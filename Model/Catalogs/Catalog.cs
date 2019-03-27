using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CS.Model.Catalog
{

   // [DefaultClassOptions]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Catalog : CompanyBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Catalog(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        Catalog dependency;
        public Catalog Dependency
        {
            get { return dependency; }
            set { SetPropertyValue(nameof(Dependency), ref dependency, value); }
        }

        string accountNumber;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AccountNumber
        {
            get { return accountNumber; }
            set { SetPropertyValue(nameof(AccountNumber), ref accountNumber, value); }
        }

        string name;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
            }

        int level;
        public int Level
        {
            get { return level; }
            set { SetPropertyValue(nameof(Level), ref level, value); }
            }

            Enums.CreditType creditType;
        public Enums.CreditType CreditType
        {
            get { return creditType; }
            set { SetPropertyValue(nameof(CreditType), ref creditType, value); }
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

        bool requireCC;
        public bool RequireCC
        {
            get { return requireCC; }
            set { SetPropertyValue(nameof(RequireCC), ref requireCC, value); }
            }

        }
    }