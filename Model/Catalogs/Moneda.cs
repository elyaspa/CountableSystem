using CS.Model.Utilities;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CS.Model.Catalog
{
    [DefaultClassOptions]
    ////[ImageName("BO_Contact")]
    //[NavigationItem("Catálogos")]
    //[ModelDefault("Caption", "Monedas")]
    //[Persistent(Constantes.PrefijoTabla + "MONEDA")]
    //[DescripcionObjetos("Catálogo de monedas")]
    //[VisibleInReports(false)]
    //[DefaultProperty("Descripcion")]    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Moneda : ObjetoBaseAuditable
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Moneda(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string descripcion;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[ModelDefault("Caption", "Descripción")]
        //[Persistent("DESCRIPCION")]
        //[DescripcionObjetos("Descripción o nombre de la moneda")]
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                SetPropertyValue(nameof(Descripcion), ref descripcion, value);
            }
        }


        string simbolo;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[ModelDefault("Caption", "Simbolo")]
        //[Persistent("SIMBOLO")]
        //[DescripcionObjetos("Caracter grafico que representa la moneda a nivel mundial")]
        public string Simbolo
        {
            get
            {
                return simbolo;
            }
            set
            {
                SetPropertyValue(nameof(Simbolo), ref simbolo, value);
            }
        }

    }
}