using AbcJobSite.Data;
using AbcJobSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobsite.Services
{
    public class JobApplicationService
    {
        private readonly Guid _UserId;
        public JobApplicationService(Guid userId)
        {
            _UserId = userId;
        }
        public bool CreateJobApplication(JobApplicationCreate model)
        {
            var JobApplication = new JobApplication()
            {

                ApplicantId = model.ApplicantId,
                JobId = model.JobId,
                DateOfAplication = model.DateTimeNow
                


            };
            using (var context = new ApplicationDbContext())
            {
                context.JobApplications.Add(JobApplication);
                return context.SaveChanges() == 1;
            }
        }
        public IEnumerable<JobApplicationList> GetJobApplications()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .JobApplications
                    .Where(e => e.Id == e.Id)
                    .Select(e => new JobApplicationList
                    {
                        Id = e.Id,
                        ApplicantId = e.ApplicantId,
                        ApplicantName = e.Applicant.ApplicantName,
                        JobTitle = e.Job.JobTitle,
                        DateTimeNow = e.DateOfAplication


                    }

                    ); 
                return query.ToList();
            }
        }
        public JobApplicationDetail GetJobApplicationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.JobApplications
                    .Single(e => e.Id == id);
                return
                    new JobApplicationDetail
                    {
                        Id = entity.Id,
                        ApplicantId = entity.ApplicantId,
                        JobId = entity.JobId,
                        DateTimeNow = entity.DateOfAplication,


                    };

            }
        }
        public bool UpdateJobApplication(JobApplicationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .JobApplications
                    .Single(e => e.Id == model.Id);

                entity.ApplicantId = model.ApplicantId;
                entity.JobId = model.JobId;
                entity.DateOfAplication = model.DateTimeNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteJobApplication(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .JobApplications
                    .Single(e => e.Id == Id);
                ctx.JobApplications.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }

    }
}
