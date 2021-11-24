using AbcJobSite.Data;
using AbcJobSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobsite.Services
{
    public class EmployerService
    {
        private readonly Guid _UserId;
        public EmployerService(Guid userId)
        {
            _UserId = userId;
        }
        public bool CreateEmployer(EmployerCreate model)
        {
            var employer = new Employer()
            {

                EmployerName = model.EmployerName,
                EmployerEmail = model.EmployerEmail,
                EmployerAddress = model.EmployerAddress,
                City = model.City,
                State = model.State

            };

            using (var context =  new ApplicationDbContext())
            {
                context.Employers.Add(employer);
                return context.SaveChanges() == 1;
            }
        }
        public IEnumerable<EmployerList> GetEmployers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Employers
                    .Where(e => e.Id == e.Id)
                    .Select( e => new EmployerList
                    {
                        Id = e.Id,
                        EmployerName = e.EmployerName,
                        EmployerEmail = e.EmployerEmail
                    }

                    );
                return query.ToArray();
            }
        }
        public EmployerDetail GetEmployerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Employers
                    .Single(e => e.Id == id);
                return
                    new EmployerDetail
                    {
                        Id = entity.Id,
                        EmployerName = entity.EmployerName,
                        EmployerEmail = entity.EmployerEmail,
                        EmployerAddress = entity.EmployerAddress,
                        City =entity.City,
                        State =entity.State
                    };

            }
        }
        public bool UpdateEmployer(EmployerEdit model)
        {
            using ( var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employers
                    .Single(e => e.Id == model.Id);
             
                entity.EmployerName = model.EmployerName;
                entity.EmployerEmail = model.EmployerEmail;
                entity.EmployerAddress = model.EmployerAddress;
                entity.City = model.City;
                entity.State = model.State;
                

                    return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEmployer(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employers
                    .Single(e => e.Id == Id);
                ctx.Employers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
