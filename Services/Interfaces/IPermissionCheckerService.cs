public interface IPermissionCheckerService
{
    Task<bool> HasViewPermissionAsync(int kullaniciId, int alanId);
    Task<bool> HasEditPermissionAsync(int kullaniciId, int alanId);
}
