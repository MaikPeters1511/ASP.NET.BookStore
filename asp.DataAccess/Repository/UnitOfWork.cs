﻿using asp.DataAccess.Data;
using asp.DataAccess.Repository.IRepository;

namespace asp.DataAccess.Repository
{
    public class UnitOfWork(ApplicationDbContext? context) : IUnitOfWork
    {
        private readonly ApplicationDbContext? _context = context;
        public IGategoryRepository Category { get; private set; } = new CategoryRepository(context);
        public ICoverTypeRepository CoverType { get; private set; } = new CoverTypeRepository(context);
        public IProductRepository Product { get; private set; } = new ProductRepository(context);
        public void Save()
        {
            _context?.SaveChangesAsync();
        }
    }

}
