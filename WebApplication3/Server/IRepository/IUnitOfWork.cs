using WebApplication3.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication3.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Rider> Riders { get;}
        IGenericRepository<Customer> Customers { get;}
        IGenericRepository<MenuItem> MenuItems { get;}
        IGenericRepository<Order> Orders { get;}
    }
}
