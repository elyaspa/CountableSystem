﻿using DevExpress.Xpo;
using CS.Model.Catalog;

namespace CS.Model.Utilities
{
    [NonPersistent]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public abstract class ObjetoBaseEmpresa : ObjetoBaseAuditable
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ObjetoBaseEmpresa(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           // this.Empresa = BuscarObjetoEmpresa(ParametroDeAcceso);
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        Empresa empresa;
        //[ModelDefault("Caption", "Empresa")]
        //[Persistent("EMPRESA")]
        //[DescripcionObjetos("Referencia de la empresa propietaria del registro")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Empresa - Objeto Base Empresa", Enabled = false)]
        public Empresa Empresa
        {
            get {
                return empresa;
                    }
            set {
                SetPropertyValue(nameof(Empresa), ref empresa, value);
                 }
        }

        //private Empresa BuscarObjetoEmpresa(ParametroAcceso parametroDeAcceso)
        //{
        //    object EmpresaObjeto = Session.FindObject(typeof(Empresa), new BinaryOperator("Codigo", parametroDeAcceso.CodigoEmpresa), false);
        //    Empresa LaEmpresa = (Empresa)EmpresaObjeto;
        //    return LaEmpresa;
        //}


    }
}