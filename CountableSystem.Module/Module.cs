using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using CS.Model;
using CS.Model.Utilities;
using CS.Model.Security;

namespace CountableSystem.Module
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class CountableSystemModule : ModuleBase {
        public CountableSystemModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
            //added by yaspa
            //AyudanteDeReflection AyudanteReflection = new AyudanteDeReflection();
            //var HeredadosDeObjetoBaseAuditable = AyudanteReflection.ObtenerDescendientesBase(typeof(ObjetoBaseAuditable));
            //foreach (Type ElTipo in HeredadosDeObjetoBaseAuditable)
            //{
            //    AdditionalExportedTypes.Add(ElTipo);
            //}
            //ends
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application) {
            //added by yaspa
           // application.CreateCustomLogonWindowObjectSpace += application_CreateCustomLogonWindowObjectSpace;
            //end
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        //added yaspa
        //private void application_CreateCustomLogonWindowObjectSpace(object sender, CreateCustomLogonWindowObjectSpaceEventArgs e)
        //{
        //    IObjectSpace objectSpace = ((XafApplication)sender).CreateObjectSpace();
        //    ((CustomLogonParametersForStandardAuthentication)e.LogonParameters).ObjectSpace = objectSpace;
        //    e.ObjectSpace = objectSpace;
        //}
        //end
        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }
    }
}
