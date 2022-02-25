using System;
using System.Collections.Generic;
using InstantService.API.DAL;
using InstantService.BO;
using InstantService.BO.Helpers.Enum;

namespace InstantService.API.DAL.SeedDatas.Users
{
    public class UserSeed
    {
        public static void Run(InstantServiceContext context)
        {
            var users = new List<User> 
            {
                // User Company
                new User(){Id = Guid.Parse("08d9b10c-2b11-4c8c-8a44-8218e44e20a5"), FirstName = "Getsmarter", LastName = "Group", Password = "45k8ee8f7c171ce132f7bed0572sd012", Email = "group@getsmarter.be", PhoneNumber = "+237690010101", Isconnected = true, LastconnecteAt = null, Civility = CivilityTypeEnum.SINGLE, Country = "Cameroun", City = "Douala", FullAdressName = "Bonamoussadi sabe, face Istama - Douala", IdPaperNumber = "000085476213", Street = "Bonamoussadi", PostalCode = "2022", EmailConfirm = true, CodeConfirm = "0000", Birthday = DateTime.Parse("1995-01-10 00:00:00"), Gender = GenderTypeEnum.MAN, StepRegistration = StepEnum.STEPTREE, CreateAt = DateTime.Now, UpdateAt = null},

            };

            context.AddRange(users);
            context.SaveChanges();
        }
    }
}