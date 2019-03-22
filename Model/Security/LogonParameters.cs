using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.Xpo.DB.Helpers;


namespace CS.Model.Security
{
   
    public interface IDatabaseNameParameter
    {
        string DatabaseName { get; set; }
    }
    [DomainComponent]
    public class CustomLogonParametersForStandardAuthentication : AuthenticationStandardLogonParameters, IDatabaseNameParameter
    {
       
        private string databaseName;
       // [ModelDefault("PredefinedValues", ChangeDatabaseHelper.Databases)]
        public string DatabaseName
        {
            get { return databaseName; }
            set {
                databaseName = value;
               
               }
        }
        
       
       
    }
    //[DomainComponent]
    //public class CustomLogonParametersForActiveDirectoryAuthentication : IDatabaseNameParameter
    //{
    //    private string databaseName = MSSqlServerChangeDatabaseHelper.Databases.Split(';')[0];

    //    [ModelDefault("PredefinedValues", MSSqlServerChangeDatabaseHelper.Databases)]
    //    public string DatabaseName
    //    {
    //        get { return databaseName; }
    //        set { databaseName = value; }
    //    }
    //}
    public class ChangeDatabaseHelper
    {
       //public const string Databases = "CountableSystem;CountableSystem2";
        public static void UpdateDatabaseName(XafApplication application, string databaseName)
        {
            ConnectionStringParser helper = new ConnectionStringParser(application.ConnectionString);
            var conection =helper.GetConnectionString();
           
            //if MSSqlServer 
            if (conection.Contains("MSSqlServer"))
            {
                helper.RemovePartByName("Initial Catalog");
                application.ConnectionString = string.Format("Initial Catalog={0};{1}", databaseName, helper.GetConnectionString());
            }//if MysqlServer,dudas con lo del server
            else if(conection.Contains("MySql"))
            {
                helper.RemovePartByName("Database");
                application.ConnectionString = string.Format("Database={0};{1}", databaseName, helper.GetConnectionString());
            }//SQL Server ,dudas con lo del server
            else if (conection.Contains("Postgres"))
            {
                helper.RemovePartByName("Database");
                application.ConnectionString = string.Format("Database={0};{1}", databaseName, helper.GetConnectionString());
            }
              


        }
    }
    //  public class ParametroAcceso : ISerializable
    //{

    //    string usuario;
    //    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    //    public string Usuario
    //    {
    //        get
    //        {
    //            return usuario;
    //        }
    //        set
    //        {
    //            if (usuario == value) return;
    //            usuario = value;
    //            //SetPropertyValue(nameof(Usuario), ref usuario, value);
    //        }
    //    }

    //    string clave;
    //    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    //    [PasswordPropertyText(true)]
    //    public string Clave
    //    {
    //        get
    //        {
    //            return clave;
    //        }
    //        set
    //        {
    //            if (clave == value) return;
    //            clave = value;
    //            //SetPropertyValue(nameof(Clave), ref clave, value);
    //        }
    //    }


    //    string codigoEmpresa;
    //    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    //    public string CodigoEmpresa
    //    {
    //        get
    //        {
    //            return codigoEmpresa;
    //        }
    //        set
    //        {
    //            if (codigoEmpresa == value) return;
    //            codigoEmpresa = value;

    //        }
    //    }


    //    public void CustomLogonParameters() { }
    //    // ISerializable 
    //    public void CustomLogonParameters(SerializationInfo info, StreamingContext context)
    //    {
    //        if (info.MemberCount > 0)
    //        {
    //            Usuario = info.GetString("Usuario");
    //            Clave = info.GetString("Clave");
    //            CodigoEmpresa = info.GetString("CodigoEmpresa");
    //        }
    //    }

    //    [System.Security.SecurityCritical]
    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("Usuario", Usuario);
    //        info.AddValue("Clave", Clave);
    //        info.AddValue("CodigoEmpresa", CodigoEmpresa);
    //    }


    //    private IObjectSpace objectSpace;
    //    [Browsable(false)]
    //    public IObjectSpace ObjectSpace
    //    {
    //        get { return objectSpace; }
    //        set { objectSpace = value; }
    //    }

    //}
}
