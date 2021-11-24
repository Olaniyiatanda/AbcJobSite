using AbcJobSite.Data;
using AbcJobSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobsite.Services
{
    public class ApplicantService
    {
        private readonly Guid _UserId;
        public ApplicantService(Guid userId)
        {
            _UserId = userId;
        }
        public bool CreateApplicant(ApplicantCreate model)
        {
            var applicant = new Applicant()
            {
                ApplicantName = model.ApplicantName,
                ApplicantEmail = model.ApplicantEmail,
                PhoneNumber = model.PhoneNumber,
                Location = model.Location,
                Address = model.Address,
                CreatedUtc = DateTime.UtcNow,
                Skill = model.Skill
            };
            using (var context = new ApplicationDbContext())
            {
                context.Applicants.Add(applicant);
                return context.SaveChanges() == 1;
            }
        }
        public IEnumerable<ApplicantList> GetApplicants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Applicants
                    .Where(e => e.Id == e.Id)
                    .Select(e => new ApplicantList
                    {
                        Id = e.Id,
                        ApplicantName = e.ApplicantName,
                        ApplicantEmail = e.ApplicantEmail
                    }

                    );
                return query.ToList();
            }
        }
        public ApplicantDetail GetApplicantById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Applicants
                    .Single(e => e.Id == id);
                return
                    new ApplicantDetail
                    {
                        Id = entity.Id,
                        ApplicantName = entity.ApplicantName,
                        ApplicantEmail = entity.ApplicantEmail,
                        PhoneNumber = entity.PhoneNumber,
                        Location = entity.Location,
                        Address = entity.Address,
                        CreatedUtc = DateTime.UtcNow
               
                    };

            }
        }
        public bool UpdateApplicant(ApplicantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Applicants
                    .Single(e => e.Id == model.Id);

                entity.ApplicantName = model.ApplicantName;
               entity.ApplicantEmail = model.ApplicantEmail;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Location = model.Location;
                entity.Address = model.Address;
                entity.CreatedUtc = DateTime.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteApplicant(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Applicants
                    .Single(e => e.Id == Id);
                ctx.Applicants.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }

    }
   
}
