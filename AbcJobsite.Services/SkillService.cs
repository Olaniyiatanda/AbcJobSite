using AbcJobSite.Data;
using AbcJobSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobsite.Services
{
    public class SkillService
    {

        private readonly Guid _UserId;
        public SkillService(Guid userId)
        {
            _UserId = userId;
        }
        public bool CreateSkill(SkillCreate model)
        {
            var skill = new Skill()
            {
                SkillName = model.SkillName,
                


            };
            using (var context = new ApplicationDbContext())
            {
                context.Skills.Add(skill);
                return context.SaveChanges() == 1;
            }
        }
        public IEnumerable<SkillList> GetSkills()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Skills
                    .Where(e => e.Id == e.Id)
                    .Select(e => new SkillList
                    {
                        Id = e.Id,
                        SkillName = e.SkillName,


                    }

                    );
                return query.ToList();
            }
        }
        public SkillDetail GetSkillById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Skills
                    .Single(e => e.Id == id);
                return
                    new SkillDetail
                    {
                        Id = entity.Id,
                        SkillName = entity.SkillName,


                    };

            }
        }
        public bool UpdateSkill(SkillEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Skills
                    .Single(e => e.Id == model.Id);

                entity.SkillName = model.SkillName;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSkill(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Skills
                    .Single(e => e.Id == Id);
                ctx.Skills.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
    
}
