using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFirmaService
    {
        Task<List<Firma>> GetAllAsync();
        Task<Firma?> GetByIdAsync(int id);
        Task AddAsync(Firma firma);
        Task UpdateAsync(Firma firma);
        Task DeleteAsync(int id);
    }
}
