namespace CountableSystem.Module.Win {
    partial class CountableSystemWindowsFormsModule {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            // 
            // CountableSystemWindowsFormsModule
            // 
           
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.BaseObject));
          
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Xpo.XPCustomObject));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Xpo.XPBaseObject));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Xpo.PersistentBase));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRoleBase));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyTypePermissionObject));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyNavigationPermissionObject));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyMemberPermissionsObject));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyObjectPermissionsObject));
          
            this.RequiredModuleTypes.Add(typeof(CountableSystem.Module.CountableSystemModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule));

        }

        #endregion
    }
}