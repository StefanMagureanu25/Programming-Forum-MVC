using MagureanuStefan_MVC.Data;
using MagureanuStefan_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MagureanuStefan_MVC.Repositories
{
    public class AnnouncementsRepository
    {
        private readonly ClubLibraDbContext _context;
        //injectarea se face la nivel de constructor (dependinta fiind contextul bazei de date)
        public AnnouncementsRepository(ClubLibraDbContext context)
        {
            _context = context;
        }
        public DbSet<AnnouncementsModel> GetAllAnnouncements()
        {
            return _context.Announcements;
        }
        public void Delete(Guid idAnnouncement)
        {
            var announcement = _context.Announcements.FirstOrDefault(x => x.IdAnnouncement == idAnnouncement);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
                _context.SaveChanges();
            }
        }
        public AnnouncementsModel? GetAnnouncementById(Guid idAnnouncement)
        {
            return _context.Announcements.FirstOrDefault(x => x.IdAnnouncement == idAnnouncement);
        }
        public void AddAnnouncement(AnnouncementsModel announcement)
        {
            announcement.IdAnnouncement = Guid.NewGuid();
            _context.Announcements.Add(announcement);
            _context.SaveChanges();
        }
        public void UpdateAnnouncement(AnnouncementsModel announcement)
        {
            if (announcement != null)
            {
                _context.Announcements.Update(announcement);
                _context.SaveChanges();
            }
        }
    }
}
