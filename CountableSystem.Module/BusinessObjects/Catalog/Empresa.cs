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
using CountableSystem.Module.BusinessObjects.Security;

namespace CountableSystem.Module.BusinessObjects.Catalog
{
    [DefaultClassOptions]
    [NavigationItem("Catálogos")]
    [ModelDefault("Caption", "Empresas")]
    [Persistent(Constantes.PrefijoTabla + "EMPRESA")]
    [DescripcionObjetos("Catálogo de Empresas")]
    [VisibleInReports(false)]
    [DefaultProperty("Nombre")]    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).

    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Empresa : ObjetoBaseAuditable
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Empresa(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string codigo;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [ModelDefault("Caption", "Codigo")]
        [Persistent("CODIGO")]
        [DescripcionObjetos("Codigo de la empresa")]
        public string Codigo
        {
            get { return codigo; }
            set { SetPropertyValue(nameof(Codigo), ref codigo, value); }
        }

        string nombre;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [ModelDefault("Caption", "Nombre")]
        [Persistent("NOMBRE")]
        [DescripcionObjetos("Nombre de la empresa")]
        public string Nombre
        {
            get { return nombre; }
            set { SetPropertyValue(nameof(Nombre), ref nombre, value); }
        }

        Moneda moneda;
        [ModelDefault("Caption", "Moneda")]
        [Persistent("MONEDA")]
        [DescripcionObjetos("Moneda de las transacciones de la empresa")]
        public Moneda Moneda
        {
            get { return moneda; }
            set { SetPropertyValue(nameof(CountableSystem.Module.BusinessObjects.Catalog.Moneda), ref moneda, value); }
        }

        [Association("Usuario-Empresas")]
        public XPCollection<Usuario> Usuarios
        {
            get
            {
                return GetCollection<Security.Usuario>(nameof(Usuarios));
            }
        }

    }
}