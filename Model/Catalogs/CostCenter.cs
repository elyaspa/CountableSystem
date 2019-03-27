using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CS.Model.Catalog
{
    //[DefaultClassOptions]
    //[NavigationItem("Catálogos")]
    //[ModelDefault("Caption", "Centros de Costos")]
   // [Persistent(Constantes.PrefijoTabla + "CENTRO_COSTO")]
   // [DescripcionObjetos("Catálogo de centros de costo")]
   //// [VisibleInReports(false)]
   // [DefaultProperty("Nombre")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CostCenter : CompanyBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CostCenter(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string name;
       // [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

    }
}