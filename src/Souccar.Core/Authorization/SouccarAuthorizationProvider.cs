using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Souccar.Authorization
{
    public class SouccarAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Administration_HangfireDashboard, L("HangfireDashboard"));


            //Users
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Create, L("CreateNewUser"));
            context.CreatePermission(PermissionNames.Pages_Users_Edit, L("EditUser"));
            context.CreatePermission(PermissionNames.Pages_Users_Delete, L("DeleteUser"));
            context.CreatePermission(PermissionNames.Pages_Users_ResetPassword, L("ResetPassword"));
            context.CreatePermission(PermissionNames.Pages_Users_ChangePermissions, L("ChangePermissions"));

            //Roles
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Roles_Create, L("CreateNewRole"));
            context.CreatePermission(PermissionNames.Pages_Roles_Edit, L("EditRole"));
            context.CreatePermission(PermissionNames.Pages_Roles_Delete, L("DeleteRole"));

            //DailyProductions
            context.CreatePermission(PermissionNames.Pages_DailyProductions, L("DailyProductions"));
            context.CreatePermission(PermissionNames.Pages_DailyProductions_Create, L("CreateNewDailyProduction"));
            context.CreatePermission(PermissionNames.Pages_DailyProductions_Edit, L("EditDailyProduction"));
            context.CreatePermission(PermissionNames.Pages_DailyProductions_Delete, L("DeleteDailyProduction"));

            //GeneralSettings
            context.CreatePermission(PermissionNames.Pages_GeneralSettings, L("GeneralSettings"));
            context.CreatePermission(PermissionNames.Pages_GeneralSettings_Create, L("CreateNewGeneralSetting"));
            context.CreatePermission(PermissionNames.Pages_GeneralSettings_Edit, L("EditGeneralSetting"));
            context.CreatePermission(PermissionNames.Pages_GeneralSettings_Delete, L("DeleteGeneralSetting"));

            //Materials
            context.CreatePermission(PermissionNames.Pages_Materials, L("Materials"));
            context.CreatePermission(PermissionNames.Pages_Materials_Create, L("CreateNewMaterial"));
            context.CreatePermission(PermissionNames.Pages_Materials_Edit, L("EditMaterial"));
            context.CreatePermission(PermissionNames.Pages_Materials_Delete, L("DeleteMaterial"));

            //Plans
            context.CreatePermission(PermissionNames.Pages_Plans, L("Plans"));
            context.CreatePermission(PermissionNames.Pages_Plans_Create, L("CreateNewPlan"));
            context.CreatePermission(PermissionNames.Pages_Plans_Edit, L("EditPlan"));
            context.CreatePermission(PermissionNames.Pages_Plans_Delete, L("DeletePlan"));

            //Products
            context.CreatePermission(PermissionNames.Pages_Products, L("Products"));
            context.CreatePermission(PermissionNames.Pages_Products_Create, L("CreateNewProduct"));
            context.CreatePermission(PermissionNames.Pages_Products_Edit, L("EditProduct"));
            context.CreatePermission(PermissionNames.Pages_Products_Delete, L("DeleteProduct"));

            //Suppliers
            context.CreatePermission(PermissionNames.Pages_Suppliers, L("Suppliers"));
            context.CreatePermission(PermissionNames.Pages_Suppliers_Create, L("CreateNewSupplier"));
            context.CreatePermission(PermissionNames.Pages_Suppliers_Edit, L("EditSupplier"));
            context.CreatePermission(PermissionNames.Pages_Suppliers_Delete, L("DeleteSupplier"));

            //Units
            context.CreatePermission(PermissionNames.Pages_Units, L("Units"));
            context.CreatePermission(PermissionNames.Pages_Units_Create, L("CreateNewUnit"));
            context.CreatePermission(PermissionNames.Pages_Units_Edit, L("EditUnit"));
            context.CreatePermission(PermissionNames.Pages_Units_Delete, L("DeleteUnit"));

            //Transfers
            context.CreatePermission(PermissionNames.Pages_Transfers, L("Transfers"));
            context.CreatePermission(PermissionNames.Pages_Transfers_Create, L("CreateNewTransfer"));
            context.CreatePermission(PermissionNames.Pages_Transfers_Edit, L("EditTransfer"));
            context.CreatePermission(PermissionNames.Pages_Transfers_Delete, L("DeleteTransfer"));

            //Warehouses
            context.CreatePermission(PermissionNames.Pages_Warehouses, L("Warehouses"));
            context.CreatePermission(PermissionNames.Pages_Warehouses_Create, L("CreateNewWarehouse"));
            context.CreatePermission(PermissionNames.Pages_Warehouses_Edit, L("EditWarehouse"));
            context.CreatePermission(PermissionNames.Pages_Warehouses_Delete, L("DeleteWarehouse"));

            //WarehouseMaterials
            context.CreatePermission(PermissionNames.Pages_WarehouseMaterials, L("WarehouseMaterials"));
            context.CreatePermission(PermissionNames.Pages_WarehouseMaterials_Create, L("CreateNewWarehouseMaterial"));
            context.CreatePermission(PermissionNames.Pages_WarehouseMaterials_Edit, L("EditWarehouseMaterial"));
            context.CreatePermission(PermissionNames.Pages_WarehouseMaterials_Delete, L("DeleteWarehouseMaterial"));

            //OutputRquests
            context.CreatePermission(PermissionNames.Pages_OutputRquests, L("OutputRquests"));
            context.CreatePermission(PermissionNames.Pages_OutputRquests_Create, L("CreateNewOutputRquest"));
            context.CreatePermission(PermissionNames.Pages_OutputRquests_Edit, L("EditOutputRquest"));
            context.CreatePermission(PermissionNames.Pages_OutputRquests_Delete, L("DeleteOutputRquest"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SouccarConsts.LocalizationSourceName);
        }
    }
}
