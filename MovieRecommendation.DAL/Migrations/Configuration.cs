using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieRecommendation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.DAL.Migrations
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieRecommendationDbContext>();
            context.Database.Migrate();

            if (context.Users.Count() == 0)
            {
                context.Users.AddRange(
                    new List<Users>() {
                         new Users() { UserName="test", Password="test" },
                    }
                    );
            }

            context.SaveChanges();
        }
    }
}