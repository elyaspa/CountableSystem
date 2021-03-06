﻿using System;
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
using DevExpress.ExpressApp.ConditionalAppearance;
using System.Runtime.Serialization;

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
            ITypeInfo CompanyUserTypeInfo = typesInfo.FindTypeInfo(typeof(CompanyUser));
            ITypeInfo CustomLogonTypeInfo = typesInfo.FindTypeInfo(typeof(CustomLogonParametersForStandardAuthentication));
            ITypeInfo UserRoleTypeInfo = typesInfo.FindTypeInfo(typeof(UserRole));
            ITypeInfo AuditableBaseTypeInfo = typesInfo.FindTypeInfo(typeof(AuditableBaseObject));
            ITypeInfo CompanyBaseTypeInfo = typesInfo.FindTypeInfo(typeof(CompanyBaseObject));
            ITypeInfo ConstsTypeInfo = typesInfo.FindTypeInfo(typeof(Consts)); 
            ITypeInfo ObjectsDescriptionTypeInfo = typesInfo.FindTypeInfo(typeof(ObjectsDescription));
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
                //CompanyTypeInfo.AddAttribute(new AssociationAttribute("User-Companies",typeof(CompanyUser)));
                IMemberInfo NameMemberInfo = CompanyTypeInfo.OwnMembers.Where(m => m.Name == "Name").FirstOrDefault();
                IMemberInfo CodeMemberInfo = CompanyTypeInfo.OwnMembers.Where(m => m.Name == "Code").FirstOrDefault();
                IMemberInfo CurrencyMemberInfo = CompanyTypeInfo.OwnMembers.Where(m => m.Name == "Currency").FirstOrDefault();
                IMemberInfo UsersMemberInfo = CompanyTypeInfo.OwnMembers.Where(m => m.Name == "Users").FirstOrDefault();
                if (NameMemberInfo != null && CodeMemberInfo != null && CurrencyMemberInfo != null && UsersMemberInfo!=null)
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
                    //
                    UsersMemberInfo.AddAttribute(new AssociationAttribute("Company-User",typeof(CompanyUser)),true);
                }
                
            }
            //CompanyUser
            if (CompanyUserTypeInfo != null)
            {

                CompanyUserTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                CompanyUserTypeInfo.AddAttribute(new NavigationItemAttribute("Security"));
                CompanyUserTypeInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Users"));
                CompanyUserTypeInfo.AddAttribute(new PersistentAttribute(Consts.TablePrefix + "USER"));
                CompanyUserTypeInfo.AddAttribute(new ObjectsDescription("System Users"));
                CompanyUserTypeInfo.AddAttribute(new VisibleInReportsAttribute(false));
                CompanyUserTypeInfo.AddAttribute(new DefaultPropertyAttribute("FullName"));
                CompanyUserTypeInfo.AddAttribute(new ImageNameAttribute("BO_Contact"));
                IMemberInfo FullNameMemberInfo = CompanyUserTypeInfo.OwnMembers.Where(m => m.Name == "FullName").FirstOrDefault();
                IMemberInfo CompaniesMemberInfo = CompanyUserTypeInfo.OwnMembers.Where(m => m.Name == "Companies").FirstOrDefault();


                if (FullNameMemberInfo != null && CompaniesMemberInfo != null)
                {
                    FullNameMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                    FullNameMemberInfo.AddAttribute(new PersistentAttribute("FULL_NAME"));
                    FullNameMemberInfo.AddAttribute(new ObjectsDescription("User Full Name"));
                    CompaniesMemberInfo.AddAttribute(new AssociationAttribute("Company-User",typeof(Company)),true);
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
                IMemberInfo NameMemberInfo = CostCenterTypeInfo.OwnMembers.Where(m => m.Name == "Name").FirstOrDefault();
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
                    DescriptionMemberInfo.AddAttribute(new ObjectsDescription("Description or Currency Name"));
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
                IMemberInfo CycleMemberInfo = FiscalCalendarTypeInfo.OwnMembers.Where(m => m.Name == "Cycle").FirstOrDefault();
                if (CycleMemberInfo!=null)
                {
                    CycleMemberInfo.AddAttribute(new AssociationAttribute("FiscalCalendar-FiscalCalendarCycle", typeof(FiscalCalendarCycle)), true);
                    CycleMemberInfo.AddAttribute(new DevExpress.Xpo.AggregatedAttribute(),true);
                }
               

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
                IMemberInfo FiscalCalendarMemberInfo = FiscalCalendarCycleTypeInfo.OwnMembers.Where(m => m.Name == "FiscalCalendar").FirstOrDefault();
                if (FiscalCalendarMemberInfo != null)
                {
                    FiscalCalendarMemberInfo.AddAttribute(new AssociationAttribute("FiscalCalendar-FiscalCalendarCycle", typeof(FiscalCalendar)), true);
                    
                }
            }
            //Item or Invoice
            if(ItemTypeInfo!=null)
            {
                ItemTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                IMemberInfo ConceptMemberInfo = ItemTypeInfo.OwnMembers.Where(m => m.Name == "Concept").FirstOrDefault();
                IMemberInfo DetailMemberInfo = ItemTypeInfo.OwnMembers.Where(m => m.Name == "Details").FirstOrDefault();
                if (ConceptMemberInfo!=null)
                {
                    ConceptMemberInfo.AddAttribute(new SizeAttribute(250));
                    DetailMemberInfo.AddAttribute(new AssociationAttribute("Item-ItemDetails",typeof(ItemDetail)),true);
                    DetailMemberInfo.AddAttribute(new DevExpress.Xpo.AggregatedAttribute(),true);

                }
            }
            //ItemDetail or InvoiceDetail
            if (ItemDetailTypeInfo!=null)
            {
                ItemDetailTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
                IMemberInfo ConceptMemberInfo = ItemDetailTypeInfo.OwnMembers.Where(m => m.Name == "Concept").FirstOrDefault();
                IMemberInfo ItemMemberInfo = ItemDetailTypeInfo.OwnMembers.Where(m => m.Name == "Item").FirstOrDefault();

                if (ConceptMemberInfo != null)
                {
                    ConceptMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.Unlimited));
                    ItemMemberInfo.AddAttribute(new AssociationAttribute("Item-ItemDetails",typeof(Item)),true);
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
           
            //CustomLogonParametersForStandardAuthentication
            if(CustomLogonTypeInfo!=null)
            {
                CustomLogonTypeInfo.AddAttribute(new DomainComponentAttribute());
            }
            //User Role
            if (UserRoleTypeInfo!=null)
            {
               UserRoleTypeInfo.AddAttribute(new DefaultClassOptionsAttribute());
               UserRoleTypeInfo.AddAttribute(new NavigationItemAttribute("Security"));
               UserRoleTypeInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Users Roles"));
               UserRoleTypeInfo.AddAttribute(new PersistentAttribute(Consts.TablePrefix + "USER_ROLE"));
               UserRoleTypeInfo.AddAttribute(new ObjectsDescription("System Users Roles"));                          
               UserRoleTypeInfo.AddAttribute(new ImageNameAttribute("BO_Contact"));
            }
            //AuditableBaseObject
            if (AuditableBaseTypeInfo != null)
            {
                AuditableBaseTypeInfo.AddAttribute(new NonPersistentAttribute());
                IMemberInfo CreatedByMemberInfo = AuditableBaseTypeInfo.OwnMembers.Where(m => m.Name == "CreatedBy").FirstOrDefault();
                IMemberInfo ModifiedByMemberInfo = AuditableBaseTypeInfo.OwnMembers.Where(m => m.Name == "ModifiedBy").FirstOrDefault();
                IMemberInfo CreationDateMemberInfo = AuditableBaseTypeInfo.OwnMembers.Where(m => m.Name == "CreationDate").FirstOrDefault();
                IMemberInfo ModificationDateMemberInfo = AuditableBaseTypeInfo.OwnMembers.Where(m => m.Name == "ModificationDate").FirstOrDefault();
                IMemberInfo UserMemberInfo = AuditableBaseTypeInfo.OwnMembers.Where(m => m.Name == "User").FirstOrDefault();
                if (CreatedByMemberInfo != null && ModifiedByMemberInfo != null && CreationDateMemberInfo != null && ModificationDateMemberInfo != null && UserMemberInfo != null)
                {
                    CreatedByMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                    CreatedByMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Created By"));
                    CreatedByMemberInfo.AddAttribute(new PersistentAttribute("CREATED_BY"));
                    CreatedByMemberInfo.AddAttribute(new ObjectsDescription("Name of the record creator "));
                    CreatedByMemberInfo.AddAttribute(new VisibleInDetailViewAttribute(false));
                    CreatedByMemberInfo.AddAttribute(new VisibleInListViewAttribute(false));
                    CreatedByMemberInfo.AddAttribute(new VisibleInLookupListViewAttribute(false));
                    AppearanceAttribute attribute=new AppearanceAttribute("Disable CreatedBy");
                    attribute.TargetItems= "CreatedBy";
                    attribute.Enabled=false;
                    CreatedByMemberInfo.AddAttribute(attribute);
                    //
                   ModifiedByMemberInfo.AddAttribute(new SizeAttribute(SizeAttribute.DefaultStringMappingFieldSize));
                   ModifiedByMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Modified By"));
                   ModifiedByMemberInfo.AddAttribute(new PersistentAttribute("MODIFIED_BY"));
                   ModifiedByMemberInfo.AddAttribute(new ObjectsDescription("Last user that modified the record"));
                   ModifiedByMemberInfo.AddAttribute(new VisibleInDetailViewAttribute(false));
                   ModifiedByMemberInfo.AddAttribute(new VisibleInListViewAttribute(false));
                   ModifiedByMemberInfo.AddAttribute(new VisibleInLookupListViewAttribute(false));
                   AppearanceAttribute attribute2 = new AppearanceAttribute("Disable ModifiedBy");
                   attribute2.TargetItems = "ModifiedBy";
                   attribute2.Enabled = false;
                   ModifiedByMemberInfo.AddAttribute(attribute2);
                    //
                   
                    CreationDateMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Creation Date"));
                    CreationDateMemberInfo.AddAttribute(new PersistentAttribute("CREATION_DATE"));
                    CreationDateMemberInfo.AddAttribute(new ObjectsDescription("Record's Creation Date"));
                    CreationDateMemberInfo.AddAttribute(new VisibleInDetailViewAttribute(false));
                    CreationDateMemberInfo.AddAttribute(new VisibleInListViewAttribute(false));
                    CreationDateMemberInfo.AddAttribute(new VisibleInLookupListViewAttribute(false));
                    AppearanceAttribute attribute3 = new AppearanceAttribute("Disable CreationDate");
                    attribute3.TargetItems = "CreationDate";
                    attribute3.Enabled = false;
                    CreationDateMemberInfo.AddAttribute(attribute3);
                    //
                   ModificationDateMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Modification Date"));
                   ModificationDateMemberInfo.AddAttribute(new PersistentAttribute("MODIFICATION_DATE"));
                   ModificationDateMemberInfo.AddAttribute(new ObjectsDescription("Record's Creation Date"));
                   ModificationDateMemberInfo.AddAttribute(new VisibleInDetailViewAttribute(false));
                   ModificationDateMemberInfo.AddAttribute(new VisibleInListViewAttribute(false));
                   ModificationDateMemberInfo.AddAttribute(new VisibleInLookupListViewAttribute(false));
                   AppearanceAttribute attribute4 = new AppearanceAttribute("Disable ModificationDate");
                   attribute4.TargetItems = "ModificationDate";
                   attribute4.Enabled = false;
                   ModificationDateMemberInfo.AddAttribute(attribute4);
                    //
                  UserMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "User"));
                  UserMemberInfo.AddAttribute(new PersistentAttribute("USER"));
                  UserMemberInfo.AddAttribute(new ObjectsDescription("User that Create or Modify the Record"));
                  UserMemberInfo.AddAttribute(new VisibleInDetailViewAttribute(false));
                  UserMemberInfo.AddAttribute(new VisibleInListViewAttribute(false));
                  UserMemberInfo.AddAttribute(new VisibleInLookupListViewAttribute(false));
                  AppearanceAttribute attribute5 = new AppearanceAttribute("Disable User");
                  attribute5.TargetItems = "User";
                  attribute5.Enabled = false;
                  UserMemberInfo.AddAttribute(attribute5);
                }
            }
            //CompanyBaseObject
            if (CompanyBaseTypeInfo!=null)
            {
                CompanyBaseTypeInfo.AddAttribute(new NonPersistentAttribute());
                IMemberInfo CompanyBaseMemberInfo = AuditableBaseTypeInfo.OwnMembers.Where(m => m.Name == "Company").FirstOrDefault();
                if (CompanyBaseMemberInfo!=null)
                {
                    CompanyBaseMemberInfo.AddAttribute(new ModelDefaultAttribute("Caption", "Company"));
                    CompanyBaseMemberInfo.AddAttribute(new PersistentAttribute("COMPANY"));
                    CompanyBaseMemberInfo.AddAttribute(new ObjectsDescription("Reference to the Owner Company  of the Record"));
                    CompanyBaseMemberInfo.AddAttribute(new VisibleInDetailViewAttribute(false));
                    CompanyBaseMemberInfo.AddAttribute(new VisibleInListViewAttribute(false));
                    CompanyBaseMemberInfo.AddAttribute(new VisibleInLookupListViewAttribute(false));
                    AppearanceAttribute attribute6= new AppearanceAttribute("Disable Company");
                    attribute6.TargetItems = "Company";
                    attribute6.Enabled = false;
                    CompanyBaseMemberInfo.AddAttribute(attribute6);
                }

            }
            //Consts
            if (ConstsTypeInfo!=null)
            {
                ConstsTypeInfo.AddAttribute(new DataContractAttribute());
                IMemberInfo TablePrefixMemberInfo=ConstsTypeInfo.OwnMembers.Where(m => m.Name =="TablePrefix").FirstOrDefault();
                IMemberInfo TwoDecimalNumericMaskMemberInfo = ConstsTypeInfo.OwnMembers.Where(m => m.Name == "TwoDecimalNumericMask").FirstOrDefault();
                IMemberInfo SixDecimalNumericMaskxMemberInfo = ConstsTypeInfo.OwnMembers.Where(m => m.Name == "SixDecimalNumericMask").FirstOrDefault();
                IMemberInfo NoDecimalNumericMaskMemberInfo = ConstsTypeInfo.OwnMembers.Where(m => m.Name == "NoDecimalNumericMask").FirstOrDefault();
                if (TablePrefixMemberInfo!=null && TwoDecimalNumericMaskMemberInfo != null && SixDecimalNumericMaskxMemberInfo != null && NoDecimalNumericMaskMemberInfo != null)
                {
                    TablePrefixMemberInfo.AddAttribute(new DataMemberAttribute());
                    TwoDecimalNumericMaskMemberInfo.AddAttribute(new DataMemberAttribute());
                    SixDecimalNumericMaskxMemberInfo.AddAttribute(new DataMemberAttribute());
                    NoDecimalNumericMaskMemberInfo.AddAttribute(new DataMemberAttribute());



                }
            }
            //ObjectDescription
            if (ObjectsDescriptionTypeInfo!=null)
            {
                ObjectsDescriptionTypeInfo.AddAttribute(new AttributeUsageAttribute(AttributeTargets.Class));
                ObjectsDescriptionTypeInfo.AddAttribute(new AttributeUsageAttribute(AttributeTargets.Property));
            }
        }
    }
}
