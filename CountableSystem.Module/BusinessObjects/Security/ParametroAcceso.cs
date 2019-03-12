using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CountableSystem.Module.BusinessObjects.Security
{
    [ModelDefault("Caption", "Validación de acceso")]
    [NonPersistent()]
    [ImageName("")]
      public class ParametroAcceso : ISerializable
    {

        string usuario;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                if (usuario == value) return;
                usuario = value;
                //SetPropertyValue(nameof(Usuario), ref usuario, value);
            }
        }

        string clave;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [PasswordPropertyText(true)]
        public string Clave
        {
            get
            {
                return clave;
            }
            set
            {
                if (clave == value) return;
                clave = value;
                //SetPropertyValue(nameof(Clave), ref clave, value);
            }
        }


        string codigoEmpresa;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CodigoEmpresa
        {
            get
            {
                return codigoEmpresa;
            }
            set
            {
                if (codigoEmpresa == value) return;
                codigoEmpresa = value;

            }
        }


        public void CustomLogonParameters() { }
        // ISerializable 
        public void CustomLogonParameters(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount > 0)
            {
                Usuario = info.GetString("Usuario");
                Clave = info.GetString("Clave");
                CodigoEmpresa = info.GetString("CodigoEmpresa");
            }
        }

        [System.Security.SecurityCritical]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Usuario", Usuario);
            info.AddValue("Clave", Clave);
            info.AddValue("CodigoEmpresa", CodigoEmpresa);
        }


        private IObjectSpace objectSpace;
        [Browsable(false)]
        public IObjectSpace ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }

    }
}
