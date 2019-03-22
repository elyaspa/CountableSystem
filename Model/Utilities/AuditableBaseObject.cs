using CS.Model.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

using System;

namespace CS.Model.Utilities
{
    [NonPersistent]
    public abstract class AuditableBaseObject : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public AuditableBaseObject(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            //parametroDeAcceso = ObtenerParametrosAcceso();
            //this.Usuario = ObtenerObjetoUsuario(parametroDeAcceso);
            //this.CreadoPor = parametroDeAcceso.Usuario;
            this.CreationDate = DateTime.Now;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string createdBy;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[ModelDefault("Caption", "Creado Por")]
        //[Persistent("CREADO_POR")]
        //[DescripcionObjetos("Nombre Corto del usuario que crea el registro")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Creado Por - Objeto Base Auditable", Enabled = false)]
        public string CreatedBy
        {
            get
            {
                return createdBy;
            }
            set
            {
                SetPropertyValue(nameof(CreatedBy), ref createdBy, value);
            }
        }

        string modifiedBy;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[ModelDefault("Caption", "Modificado Por")]
        //[Persistent("MODIFICADO_POR")]
        //[DescripcionObjetos("Ultimo usuario que modificó el registro")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Modificado Por - Objeto Base Auditable", Enabled = false)]
        public string ModifiedBy
        {
            get
            {
                return modifiedBy;
            }
            set
            {
                SetPropertyValue(nameof(ModifiedBy), ref modifiedBy, value);
            }
        }

        DateTime creationDate;
        //[ModelDefault("Caption", "Fecha de creación")]
        //[Persistent("FECHA_CREACION")]
        //[DescripcionObjetos("Fecha de creación del registro")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Fecha Creación - Objeto Base Auditable", Enabled = false)]
        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set
            {
                SetPropertyValue(nameof(CreationDate), ref creationDate, value);
            }
        }

        DateTime modificationDate;
        //[ModelDefault("Caption", "Fecha de modificación")]
        //[Persistent("FECHA_MODIFICACION")]
        //[DescripcionObjetos("Fecha de modificación")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Fecha Modificación - Objeto Base Auditable", Enabled = false)]
        public DateTime ModificationDate
        {
            get
            {
                return modificationDate;
            }
            set
            {
                SetPropertyValue(nameof(ModificationDate), ref modificationDate, value);
            }
        }

        CompanyUser user;
        //[ModelDefault("Caption", "Usuario")]
        //[Persistent("USUARIO")]
        //[DescripcionObjetos("Objeto del usuario que creo o modifico el registro")]
        //[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        //[Appearance("Deshabilitar Usuario - Objeto Base Auditable", Enabled = false)]
        public CompanyUser User
        {
            get
            {
                return user;
            }
            set
            {
                SetPropertyValue(nameof(User), ref user,value);
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