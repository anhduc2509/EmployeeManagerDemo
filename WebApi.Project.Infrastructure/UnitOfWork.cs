using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeedbContext _dbContext;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public IEmployeeRepository employeeRepository
        {
            get { return _employeeRepository ?? new EmployeeRepository(_dbContext); }
        }

        public IDepartmentRepository departmentRepository
        {
            get => _departmentRepository ?? new DepartmentRepository(_dbContext);
        }

        public UnitOfWork(EmployeedbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
