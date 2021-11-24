using AbcJobSite.Data;
using AbcJobSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobsite.Services
{
    public class JobService
    {
         private readonly Guid _UserId;
        public JobService(Guid userId)
        {
            _UserId = userId;
        }
        public bool CreateJob(JobCreate model)
        {
            var Job = new Job()
            {
                JobTitle = model.JobTitle,
                JobDescription = model.JobDescription,
                Location = model.Location,
                TypeOfJob = model.TypeOfJob,
                EmployerId = model.EmployerId
            };
            using (var context = new ApplicationDbContext())
            {
                context.Jobs.Add(Job);
                return context.SaveChanges() == 1;
            }
        }
        public IEnumerable<JobList> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Jobs
                    .Where(e => e.Id == e.Id)
                    .Select(e => new JobList
                    {
                        Id = e.Id,
                        JobTitle =e.JobTitle,
                        JobDescription = e.JobDescription,
                        Location = e.Location
                        
                    }

                    );
                return query.ToList();
            }
        }
        public JobDetail GetJobById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs
                    .Single(e => e.Id == id);
                return
                    new JobDetail
                    {
                        Id = entity.Id,
                        JobTitle = entity.JobTitle,
                        JobDescription = entity.JobDescription,
                        Location = entity.Location   
                    };

            }
        }
        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Jobs
                    .Single(e => e.Id == model.Id);
                entity.JobTitle = model.JobTitle;
                entity.JobDescription = model.JobDescription;
                entity.Location = model.Location;
                entity.TypeOfJob = JobType.Remote;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteJob(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Jobs
                    .Single(e => e.Id == Id);
                ctx.Jobs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
   
 
}
