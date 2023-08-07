using MagureanuStefan_MVC.Data;
using MagureanuStefan_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MagureanuStefan_MVC.UnitTests.Helpers
{
    public class DbContextHelper
    {
        public static ClubLibraDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ClubLibraDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .Options;
            //UseInMemoryDatabase -> permite configurarea si utilizarea unei baze de date in memorie

            var databaseContext = new ClubLibraDbContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }
        public static AnnouncementsModel AddAnnouncement(ClubLibraDbContext dbContext, AnnouncementsModel model)
        {
            dbContext.Add(model);
            dbContext.SaveChanges();
            dbContext.Entry(model).State = EntityState.Detached;
            return model;
        }
    }
}
