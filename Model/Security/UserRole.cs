using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;


namespace CS.Model.Security
{
    //[DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[NavigationItem("Seguridad")]
    //[ModelDefault("Caption", "Perfiles de usuario")]
    //[Persistent(Constantes.PrefijoTabla + "PERFIL_USUARIO")]
    //[DescripcionObjetos("Perfiles de seguridad del Usuario")]    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class UserRole : PermissionPolicyRole
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public UserRole(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        
    }
}