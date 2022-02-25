using System;
using System.Linq;
using InstantService.API.DAL.SeedDatas.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InstantService.API.DAL.SeedDatas
{
    public class Seed
    {
        public static void Run(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<InstantServiceContext>();

                if (!context.Users.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            UserSeed.Run(context);
                            // add anothers seed datas
                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            transaction.Rollback();
                        }
                    }
                }
            }
        }
    }
}