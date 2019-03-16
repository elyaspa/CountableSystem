using CS.Model.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

using System;

namespace CS.Model.Utilities
{
    [NonPersistent]
    public abstract class ObjetoBaseAuditable : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ObjetoBaseAuditable(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            //parametroDeAcceso = ObtenerParametrosAcceso();
            //this.Usuario = ObtenerObjetoUsuario(parametroDeAcceso);
            //this.CreadoPor = parametroDeAcceso.Usuario;
            this.FechaCreacion = DateTime.Now;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string creadoPor;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[ModelDefault("Caption", "Creado Por")]
        //[Persistent("CREADO_POR")]
        //[DescripcionObjetos("Nombre Corto del usuario que crea el registro")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Creado Por - Objeto Base Auditable", Enabled = false)]
        public string CreadoPor
        {
            get
            {
                return creadoPor;
            }
            set
            {
                SetPropertyValue(nameof(CreadoPor), ref creadoPor, value);
            }
        }

        string modificadoPor;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[ModelDefault("Caption", "Modificado Por")]
        //[Persistent("MODIFICADO_POR")]
        //[DescripcionObjetos("Ultimo usuario que modificó el registro")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Modificado Por - Objeto Base Auditable", Enabled = false)]
        public string ModificadoPor
        {
            get
            {
                return modificadoPor;
            }
            set
            {
                SetPropertyValue(nameof(ModificadoPor), ref modificadoPor, value);
            }
        }

        DateTime fechaCreacion;
        //[ModelDefault("Caption", "Fecha de creación")]
        //[Persistent("FECHA_CREACION")]
        //[DescripcionObjetos("Fecha de creación del registro")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Fecha Creación - Objeto Base Auditable", Enabled = false)]
        public DateTime FechaCreacion
        {
            get
            {
                return fechaCreacion;
            }
            set
            {
                SetPropertyValue(nameof(FechaCreacion), ref fechaCreacion, value);
            }
        }

        DateTime fechaModificacion;
        //[ModelDefault("Caption", "Fecha de modificación")]
        //[Persistent("FECHA_MODIFICACION")]
        //[DescripcionObjetos("Fecha de modificación")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Fecha Modificación - Objeto Base Auditable", Enabled = false)]
        public DateTime FechaModificacion
        {
            get
            {
                return fechaModificacion;
            }
            set
            {
                SetPropertyValue(nameof(FechaModificacion), ref fechaModificacion, value);
            }
        }

        Usuario usuario;
        //[ModelDefault("Caption", "Usuario")]
        //[Persistent("USUARIO")]
        //[DescripcionObjetos("Objeto del usuario que creo o modifico el registro")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Usuario - Objeto Base Auditable", Enabled = false)]
        public Usuario Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                SetPropertyValue(nameof(Usuario), ref usuario, value);
            }
        }

        //old code
        //ParametroAcceso parametroDeAcceso;
        //[Browsable(false)]
        //public ParametroAcceso ParametroDeAcceso
        //{
        //    get
        //    {
        //        return parametroDeAcceso;
        //    }
     
        //}

        //private static ParametroAcceso ObtenerParametrosAcceso()
        //{
        //    ParametroAcceso ParametrosDeAcceso = (ParametroAcceso)(SecuritySystem.LogonParameters);
        //    return ParametrosDeAcceso;
        //}

        //public Usuario ObtenerObjetoUsuario(ParametroAcceso parametroDeAcceso)
        //{
        //    object UsuarioObjecto = Session.FindObject(typeof(Usuario), new BinaryOperator("UserName", parametroDeAcceso.Usuario), false);
        //    Usuario ElUsuario = (Usuario)UsuarioObjecto;
        //    return ElUsuario;
        //}


        //protected override void OnSaving()
        //{
        //    base.OnSaving();
        //    parametroDeAcceso = ObtenerParametrosAcceso();
        //    this.ModificadoPor = parametroDeAcceso.Usuario;
        //    this.FechaModificacion = DateTime.Now;
        //}

    }
}