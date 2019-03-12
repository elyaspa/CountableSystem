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
    [ModelDefault("Caption", "Catálogo Base")]
    [Persistent(Constantes.PrefijoTabla + "CATALOGO_BASE")]
    [DescripcionObjetos("Catálogo de cuentas comun paras las posibles empresas")]
    [VisibleInReports(false)]
    [DefaultProperty("Nombre")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CatalogoBase : ObjetoBaseAuditable
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CatalogoBase(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        CatalogoBase dependencia;
        public CatalogoBase Dependencia
        {
            get { return dependencia; }
            set { SetPropertyValue(nameof(Dependencia), ref dependencia, value); }
        }

        string numeroCuenta;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NumeroCuenta
        {
            get { return numeroCuenta; }
            set { SetPropertyValue(nameof(NumeroCuenta), ref numeroCuenta, value); }
        }

        string nombre;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get { return nombre; }
            set { SetPropertyValue(nameof(Nombre), ref nombre, value); }
        }

        Enumeradores.TipoSaldo tipoSaldo;
        public Enumeradores.TipoSaldo TipoSaldo
        {
            get {return tipoSaldo; }
            set { SetPropertyValue(nameof(TipoSaldo), ref tipoSaldo, value); }
        }

        int nivel;
        public int Nivel
        {
            get { return nivel; }
            set { SetPropertyValue(nameof(Nivel), ref nivel, value); }
        }

        Enumeradores.TipoCuenta tipo;
        public Enumeradores.TipoCuenta Tipo
        {
            get { return tipo; }
            set { SetPropertyValue(nameof(Tipo), ref tipo, value); }
        }

        Enumeradores.EstatusCuenta estatus;
        public Enumeradores.EstatusCuenta Estatus
        {
            get { return estatus; }
            set { SetPropertyValue(nameof(Estatus), ref estatus, value); }
        }

        bool totalizadora;
        public bool Totalizadora
        {
            get { return totalizadora; }
            set { SetPropertyValue(nameof(Totalizadora), ref totalizadora, value); }
        }

        Enumeradores.EfectoSaldo efecto;
        public Enumeradores.EfectoSaldo Efecto
        {
            get { return efecto; }
            set { SetPropertyValue(nameof(Efecto), ref efecto, value); }
        }



    }
}