using AbcJobSite.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbcJobSite.MVC.Startup))]
namespace AbcJobSite.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();

        }

        private void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager= new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager= new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);


                var user = new ApplicationUser();
                user.UserName = "Niyi";
                user.Email = "Test@gmail.com";

                string pwd = "password1$";

                var adminUser = userManager.Create(user, pwd);
                if (adminUser.Succeeded)
                {
                    var roleResult = userManager.AddToRole(user.Id, "Admin");
                }

                
            }
            if (!roleManager.RoleExists("Applicant"))
            {

                var role = new IdentityRole();
                role.Name = "Applicant";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Employer"))
            {

                var role = new IdentityRole();
                role.Name = "Employer";
                roleManager.Create(role);
            }



        }

       
    }
}
