using CountableSystem.Module.BusinessObjects.Utilities;
using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;


namespace CountableSystem.Module.BusinessObjects.Security
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [NavigationItem("Seguridad")]
    [ModelDefault("Caption", "Perfiles de usuario")]
    [Persistent(Constantes.PrefijoTabla + "PERFIL_USUARIO")]
    [DescripcionObjetos("Perfiles de seguridad del Usuario")]    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class RolUsuario : PermissionPolicyRole
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RolUsuario(Session session)
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