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
using CS.Model.Catalog;
using DevExpress.Persistent.Base;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Model;
using System.ComponentModel;

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
           
            ITypeInfo BaseCatalogTypeInfo =typesInfo.FindTypeInfo(typeof(BaseCatalog));           
            ITypeInfo BalanceCatalogTypeInfo = typesInfo.FindTypeInfo(typeof(BalanceCatalog));
            ITypeInfo CatalogTypeInfo = typesInfo.FindTypeInfo(typeof(Catalog));
            ITypeInfo CompanyTypeInfo = typesInfo.FindTypeInfo(typeof(Company));
            ITypeInfo CorrelativeTypeInfo = typesInfo.FindTypeInfo(typeof(Correlative));
            ITypeInfo CostCenterTypeInfo = typesInfo.FindTypeInfo(typeof(CostCenter));
            ITypeInfo CurrencyTypeInfo = typesInfo.FindTypeInfo(typeof(Currency));
            ITypeInfo FiscalCalendarTypeInfo = typesInfo.FindTypeInfo(typeof(FiscalCalendar));
            ITypeInfo FiscalCalendarCycleTypeInfo = typesInfo.FindTypeInfo(typeof(FiscalCalendarCycle));
            ITypeInfo ItemTypeInfo = typesInfo.FindTypeInfo(typeof(Item));
            ITypeInfo ItemDetailTypeInfo = typesInfo.FindTypeInfo(typeof(ItemDetail));
            ITypeInfo ItemTypeTypeInfo = typesInfo.FindTypeInfo(typeof(ItemType));

            //BaseCatalog
            if (BaseCatalogTypeInfo!=null){
                BaseCatalogTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                IMemberInfo AccountNumberMemberInfo = BaseCatalogTypeInfo.OwnMembers.Where(m => m.Name == "AccountNumber").FirstOrDefault();
                IMemberInfo NameMemberInfo = BaseCatalogTypeInfo.OwnMembers.Where(m => m.Name == "Name").FirstOrDefault();

                if (AccountNumberMemberInfo != null && NameMemberInfo != null)
                {
                    AccountNumberMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                    NameMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                }
            }
            //BalanceCatalog
            if (BalanceCatalogTypeInfo != null)
            {
                BalanceCatalogTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
               
            }
            //Catalog
            if (CatalogTypeInfo!=null)
            {
                CatalogTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                IMemberInfo AccountNumberMemberInfo = CatalogTypeInfo.OwnMembers.Where(m => m.Name == "AccountNumber").FirstOrDefault();
                IMemberInfo NameMemberInfo = CatalogTypeInfo.OwnMembers.Where(m => m.Name == "Name").FirstOrDefault();

                if (AccountNumberMemberInfo != null && NameMemberInfo != null)
                {
                    AccountNumberMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                    NameMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                }
            }
            //Company
            if (CompanyTypeInfo!=null)
            {
                CompanyTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                CompanyTypeInfo.AddAttribute(new NavigationItemAttribute("Catalogs"));
                CompanyTypeInfo.AddAttribute(new ModelDefaultAttribute("Caption","Companies"));
                CompanyTypeInfo.AddAttribute(new PersistentAttribute(Consts.TablePrefix + "COMPANY"));
                CompanyTypeInfo.AddAttribute(new ObjectsDescription("Companies Catalog"));
                CompanyTypeInfo.AddAttribute(new VisibleInReportsAttribute(false));
                CompanyTypeInfo.AddAttribute(new DefaultPropertyAttribute("Name"));
                IMemberInfo NameMemberInfo = CompanyTypeInfo.OwnMembers.Where(m => m.Name == "Name").FirstOrDefault();
                IMemberInfo CodeMemberInfo = CompanyTypeInfo.OwnMembers.Where(m => m.Name == "Code").FirstOrDefault();
                IMemberInfo CurrencyMemberInfo = CompanyTypeInfo.OwnMembers.Where(m => m.Name == "Currency").FirstOrDefault();
                if (NameMemberInfo != null && CodeMemberInfo != null && CurrencyMemberInfo != null)
                {
                    NameMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                    NameMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Name"));
                    NameMemberInfo.AddAttribute(new PersistentAttribute("NAME"));
                    NameMemberInfo.AddAttribute(new ObjectsDescription("Company Name"));
                    //
                    CodeMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                    CodeMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Code"));
                    CodeMemberInfo.AddAttribute(new PersistentAttribute("CODE"));
                    CodeMemberInfo.AddAttribute(new ObjectsDescription("Company Code"));
                    //
                    CurrencyMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Currency"));
                    CurrencyMemberInfo.AddAttribute(new PersistentAttribute("CURRENCY"));
                    CurrencyMemberInfo.AddAttribute(new ObjectsDescription("Company Transactions Currency"));
                }
                
            }
            //Correlative
            if (CorrelativeTypeInfo != null)
            {
                CorrelativeTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
            }
            //CostCenter
            if (CostCenterTypeInfo != null)
            {
                CostCenterTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                CostCenterTypeInfo.AddAttribute(new NavigationItemAttribute("Catalogs"));
                CostCenterTypeInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Cost Center"));
                CostCenterTypeInfo.AddAttribute(new PersistentAttribute(Consts.TablePrefix + "COST_CENTER"));
                CostCenterTypeInfo.AddAttribute(new ObjectsDescription("CostCenter Catalog"));
                CostCenterTypeInfo.AddAttribute(new VisibleInReportsAttribute(false));
                CostCenterTypeInfo.AddAttribute(new DefaultPropertyAttribute("Name"));
                IMemberInfo NameMemberInfo = CompanyTypeInfo.OwnMembers.Where(m => m.Name == "Name").FirstOrDefault();
                if (NameMemberInfo!=null)
                {
                    NameMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                }
            }
            //Currency
            if (CurrencyTypeInfo!=null)
            {
                CurrencyTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                CurrencyTypeInfo.AddAttribute(new NavigationItemAttribute("Catalogs"));
                CurrencyTypeInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Currency"));
                CurrencyTypeInfo.AddAttribute(new PersistentAttribute(Consts.TablePrefix + "CURRENCY"));
                CurrencyTypeInfo.AddAttribute(new ObjectsDescription("Currency Catalog"));
                CurrencyTypeInfo.AddAttribute(new VisibleInReportsAttribute(false));
                CurrencyTypeInfo.AddAttribute(new DefaultPropertyAttribute("Description"));
                CurrencyTypeInfo.AddAttribute(new ImageNameAttribute("BO_Contact"));
                IMemberInfo DescriptionMemberInfo = CurrencyTypeInfo.OwnMembers.Where(m => m.Name == "Description").FirstOrDefault();
                IMemberInfo SymbolMemberInfo = CurrencyTypeInfo.OwnMembers.Where(m => m.Name == "Symbol").FirstOrDefault();
                if (SymbolMemberInfo!=null && DescriptionMemberInfo!=null)
                {
                    DescriptionMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                    DescriptionMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Description"));
                    DescriptionMemberInfo.AddAttribute(new PersistentAttribute("DESCRIPTION"));
                    DescriptionMemberInfo.AddAttribute(new ObjectsDescription("Description or Currecny Name"));
                    //
                   SymbolMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                   SymbolMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Symbol"));
                   SymbolMemberInfo.AddAttribute(new PersistentAttribute("SYMBOL"));
                   SymbolMemberInfo.AddAttribute(new ObjectsDescription("World Wide Representative Currency Character"));

                }
            }
            //FiscalCalendar
            if (FiscalCalendarTypeInfo!=null)
            {
               FiscalCalendarTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
               FiscalCalendarTypeInfo.AddAttribute(new NavigationItemAttribute("Catalogs"));
               FiscalCalendarTypeInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Fiscal Calendar"));
               FiscalCalendarTypeInfo.AddAttribute(new PersistentAttribute(Consts.TablePrefix + "FISCAL_CALENDAR"));
               FiscalCalendarTypeInfo.AddAttribute(new ObjectsDescription("Work Calendar"));
               FiscalCalendarTypeInfo.AddAttribute(new VisibleInReportsAttribute(false));
               FiscalCalendarTypeInfo.AddAttribute(new DefaultPropertyAttribute("Initial"));

            }
            //FiscalCalendarCycle
            if (FiscalCalendarCycleTypeInfo!=null)
            {
               FiscalCalendarCycleTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());               
               FiscalCalendarCycleTypeInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Cycle"));
               FiscalCalendarCycleTypeInfo.AddAttribute(new PersistentAttribute(Consts.TablePrefix + "FISCAL_CALENDAR_CYCLES"));
               FiscalCalendarCycleTypeInfo.AddAttribute(new ObjectsDescription("Fiscal Calendar Cycles"));
               FiscalCalendarCycleTypeInfo.AddAttribute(new VisibleInReportsAttribute(false));
               FiscalCalendarCycleTypeInfo.AddAttribute(new DefaultPropertyAttribute("Item"));
            }
            //Item or Invoice
            if(ItemTypeInfo!=null)
            {
                ItemTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                IMemberInfo ConceptMemberInfo = CurrencyTypeInfo.OwnMembers.Where(m => m.Name == "Concept").FirstOrDefault();
                if (ConceptMemberInfo!=null)
                {
                    ConceptMemberInfo.AddAttribute(new SizeAttribute(250));
                }
            }
            //ItemDetail or InvoiceDetail
            if (ItemDetailTypeInfo!=null)
            {
                ItemDetailTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                IMemberInfo ConceptMemberInfo = CurrencyTypeInfo.OwnMembers.Where(m => m.Name == "Concept").FirstOrDefault();
              
                if (ConceptMemberInfo != null)
                {
                    ConceptMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.Unlimited));
                }
            }
            //ItemType or InvoiceType
            if (ItemTypeTypeInfo != null)
            {
                ItemTypeTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                IMemberInfo NameMemberInfo = ItemTypeTypeInfo.OwnMembers.Where(m => m.Name == "Name").FirstOrDefault();
                IMemberInfo CodeMemberInfo = ItemTypeTypeInfo.OwnMembers.Where(m => m.Name == "Code").FirstOrDefault();
                if (NameMemberInfo != null && CodeMemberInfo != null)
                {
                    NameMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                    CodeMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                }
            }
        }
    }
}
