using Models;

public interface IMenuService
{
    Task<List<Menu>> GetMenusByRolIdAsync(int rolId);
    Task<List<Menu>> GetAllAsync();
}
