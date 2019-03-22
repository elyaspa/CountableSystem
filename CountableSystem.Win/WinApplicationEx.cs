using System;
using System.Configuration;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Security;
using CountableSystem.Module.Win;
using CS.Model.Security;
//using CountableSystem.Module.BusinessObjects;
//using CountableSystem.Module.BusinessObjects.Security;


namespace CountableSystem.Win {
	public partial class CountableSystemWindowsFormsApplication : WinApplication {
		protected override void ReadLastLogonParametersCore(DevExpress.ExpressApp.Utils.SettingsStorage storage, object logonObject) {
			AuthenticationStandardLogonParameters standardLogonParameters = logonObject as AuthenticationStandardLogonParameters;
			if((standardLogonParameters != null) && string.IsNullOrEmpty(standardLogonParameters.UserName)) {
				base.ReadLastLogonParametersCore(storage, logonObject);
			}
		}
		protected override void OnLoggingOn(LogonEventArgs args) {
			base.OnLoggingOn(args);
			ChangeDatabaseHelper.UpdateDatabaseName(this, ((IDatabaseNameParameter)args.LogonParameters).DatabaseName);
		}
		protected override bool OnLogonFailed(object logonParameters, Exception e) {
			if(WinChangeDatabaseHelper.SkipLogonDialog) {
				return true;
			}
			return base.OnLogonFailed(logonParameters, e);
		}
		
		public static CountableSystemWindowsFormsApplication CreateApplication() {
            CountableSystemWindowsFormsApplication winApplication = new CountableSystemWindowsFormsApplication();

			((SecurityStrategyComplex)winApplication.Security).Authentication = new Authentication();

			//WinChangeDatabaseActiveDirectoryAuthentication activeDirectoryAuthentication = new WinChangeDatabaseActiveDirectoryAuthentication();
			//activeDirectoryAuthentication.CreateUserAutomatically = true;
			//((SecurityStrategyComplex)winApplication.Security).Authentication = activeDirectoryAuthentication;

			if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
				winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
			return winApplication;
		}
	}
}
