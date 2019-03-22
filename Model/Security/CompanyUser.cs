using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using CS.Model.Catalog;

namespace CS.Model.Security
{
    //[DefaultClassOptions]
    ////[ImageName("BO_Contact")]
    //[NavigationItem("Seguridad")]
    //[ModelDefault("Caption", "Usuarios")]
    //[Persistent(Constantes.PrefijoTabla + "USUARIO")]
    //[DescripcionObjetos("Usuarios del sistema")]
    //[VisibleInReports(false)]
    //[DefaultProperty("NombreCompleto")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CompanyUser : PermissionPolicyUser
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CompanyUser(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string fullName;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[Persistent("NOMBRE_COMPLETO")]
        //[DescripcionObjetos("Nombre completo del usuario")]
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                SetPropertyValue(nameof(FullName), ref fullName, value);
            }
        }

        [Association("User-Companies")]
        public XPCollection<Company> Companies
        {
            get
            {
                return GetCollection<Company>(nameof(Companies));
            }
        }

    }
}