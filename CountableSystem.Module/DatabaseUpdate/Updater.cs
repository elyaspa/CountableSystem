using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using CS.Model.Security;
//using CountableSystem.Module.BusinessObjects;

namespace CountableSystem.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}

            CompanyUser sampleUser = ObjectSpace.FindObject<CompanyUser>(new BinaryOperator("UserName", "User"));
            if (sampleUser == null)
            {
                sampleUser = ObjectSpace.CreateObject<CompanyUser>();
                sampleUser.UserName = "User";
                sampleUser.SetPassword("123");
            }
            UserRole defaultRole = CreateDefaultRole();
            sampleUser.Roles.Add(defaultRole);

            CS.Model.Security.CompanyUser userAdmin = ObjectSpace.FindObject<CompanyUser>(new BinaryOperator("UserName", "Admin"));
            if (userAdmin == null)
            {
                userAdmin = ObjectSpace.CreateObject<CompanyUser>();
                userAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("123");
            }
            // If a role with the Administrators name doesn't exist in the database, create this role
            UserRole adminRole = ObjectSpace.FindObject<UserRole>(new BinaryOperator("Name", "Administrators"));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<UserRole>();
                adminRole.Name = "Administrators";
            }
            adminRole.IsAdministrative = true;
            adminRole.PermissionPolicy = SecurityPermissionPolicy.AllowAllByDefault;
            userAdmin.Roles.Add(adminRole);
            ObjectSpace.CommitChanges();

            //This line persists created object(s).
        }
        //ADDED BY YASPA


        //private void CreacionDeSeguridad()
        //{
        //    Session LocalSesion = ((XPObjectSpace)this.ObjectSpace).Session;

        //    Usuario userAdmin = ObjectSpace.FindObject<Usuario>(new BinaryOperator("UserName", "Admin"));
        //    if (userAdmin == null)
        //    {
        //        userAdmin = ObjectSpace.CreateObject<Usuario>();
        //        userAdmin.UserName = "Admin";
        //        // Set a password if the standard authentication type is used
        //        userAdmin.SetPassword("123");
        //    }

        //    RolUsuario adminRole = ObjectSpace.FindObject<RolUsuario>(new BinaryOperator("Name", "Administrators"));
        //    if (adminRole == null)
        //    {
        //        adminRole = ObjectSpace.CreateObject<RolUsuario>();
        //        adminRole.Name = "Administrators";
        //    }

        //    adminRole.IsAdministrative = true;
        //    adminRole.PermissionPolicy = SecurityPermissionPolicy.AllowAllByDefault;
        //    userAdmin.Roles.Add(adminRole);
        //    ObjectSpace.CommitChanges();
        //}

            //ENDS HERE
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
        private UserRole CreateDefaultRole() {
            UserRole defaultRole = ObjectSpace.FindObject<UserRole>(new BinaryOperator("Name", "Default"));
            if(defaultRole == null) {
                defaultRole = ObjectSpace.CreateObject<UserRole>();
                defaultRole.Name = "Default";

				defaultRole.AddObjectPermission<PermissionPolicyUser>(SecurityOperations.Read, "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails", SecurityPermissionState.Allow);
				defaultRole.AddMemberPermission<PermissionPolicyUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
				defaultRole.AddMemberPermission<PermissionPolicyUser>(SecurityOperations.Write, "StoredPassword", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
                defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
				defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create, SecurityPermissionState.Allow);                
            }
            return defaultRole;
        }
    }
}
