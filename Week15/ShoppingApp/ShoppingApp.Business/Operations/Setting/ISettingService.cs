namespace ShoppingApp.Business.Operations.Setting
{
    // lifetime must be specified
    public interface ISettingService
    {
        Task ToggleMaintenence();

        bool GetMaintenanceState();
    }
}