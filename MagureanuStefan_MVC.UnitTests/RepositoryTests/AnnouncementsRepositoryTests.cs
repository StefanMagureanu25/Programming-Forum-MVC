using MagureanuStefan_MVC.Data;
using MagureanuStefan_MVC.Models;
using MagureanuStefan_MVC.Repositories;

namespace MagureanuStefan_MVC.UnitTests.RepositoryTests
{
    public class AnnouncementsRepositoryTests
    {
        private readonly AnnouncementsRepository _announcementsRepository;
        private readonly ClubLibraDbContext _contextInMemory;
        public AnnouncementsRepositoryTests()
        {
            _contextInMemory = Helpers.DbContextHelper.GetDatabaseContext();
            _announcementsRepository = new AnnouncementsRepository(_contextInMemory);
        }
        [Fact]
        public void DeleteAnnoncement_AnnouncementNotExists()
        {
            // Ca si design pattern avem AAA.
            // Arrange
            Guid id = Guid.NewGuid();

            //Act
            _announcementsRepository.Delete(id);
        }
        [Fact]
        public void DeleteAnnouncement_AnnouncementExists()
        {
            //Arrange - ca sa verific daca exista un anunt, mock-uiesc un anunt ca sa-l verific daca exista
            Guid id = Guid.NewGuid();
            AnnouncementsModel myAnnouncement = new AnnouncementsModel
            {
                IdAnnouncement = id,
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow,
                EventDate = DateTime.UtcNow,
                Title = "Anunt pentru a fi sters",
                Tags = "#tags1",
                Text = "anunt de test"
            };
            AnnouncementsModel dbAnnouncement = Helpers.DbContextHelper.AddAnnouncement(_contextInMemory, myAnnouncement);

            //Act - chem metoda pe care vreau sa o testez
            var resultBeforeDelete = _announcementsRepository.GetAnnouncementById(id);
            _announcementsRepository.Delete(id);
            var resultAfterDelete = _announcementsRepository.GetAnnouncementById(id);

            //Assert - verific rezultatul/rezultatele
            Assert.NotNull(resultBeforeDelete);
            Assert.Null(resultAfterDelete);
        }
        public void UpdateAnnouncement_AnnouncementNotExists()
        {
            // Ca si design pattern avem AAA.
            // Arrange
            Guid id = Guid.NewGuid();

            //Act
            _announcementsRepository.UpdateAnnouncement(null);
        }
        public void UpdateAnnouncement_AnnouncementExists()
        {

        }
    }
}
