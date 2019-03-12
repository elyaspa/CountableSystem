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

namespace CountableSystem.Module.BusinessObjects.Catalog
{
    [DefaultClassOptions]
    [NavigationItem("Catálogos")]
    [ModelDefault("Caption", "Centros de Costos")]
    [Persistent(Constantes.PrefijoTabla + "CENTRO_COSTO")]
    [DescripcionObjetos("Catálogo de centros de costo")]
    [VisibleInReports(false)]
    [DefaultProperty("Nombre")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CentroDeCosto : ObjetoBaseEmpresa
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CentroDeCosto(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string nombre;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get { return nombre; }
            set { SetPropertyValue(nameof(Nombre), ref nombre, value); }
        }

    }
}