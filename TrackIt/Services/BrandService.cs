using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackIt.Models;

namespace TrackIt.Services
{
    public interface IBrandService
    {
        Task<Brand> GetBrandById(long id);
    }

    public class BrandService : IBrandService
    {
        private InventoryContext _context;

        public BrandService(InventoryContext context)
        {
            _context = context;
        }

        public async Task<Brand> GetBrandById(long id)
        {
            var brand = await _context.Brands
                .Include(item => item.CompanyAddress)
                .FirstOrDefaultAsync(item => item.Id == id);
            return brand;
        }
    }
}
