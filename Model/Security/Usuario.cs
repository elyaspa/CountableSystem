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
    public class Usuario : PermissionPolicyUser
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Usuario(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string nombreCompleto;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[Persistent("NOMBRE_COMPLETO")]
        //[DescripcionObjetos("Nombre completo del usuario")]
        public string NombreCompleto
        {
            get
            {
                return nombreCompleto;
            }
            set
            {
                SetPropertyValue(nameof(NombreCompleto), ref nombreCompleto, value);
            }
        }

        [Association("Usuario-Empresas")]
        public XPCollection<Empresa> Empresas
        {
            get
            {
                return GetCollection<Empresa>(nameof(Empresas));
            }
        }

    }
}