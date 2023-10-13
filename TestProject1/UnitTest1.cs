using IntroToRepositoryMVC.Data;
using IntroToRepositoryMVC.Models;
using IntroToRepositoryMVC.Models.BusinessLogicLayer;
using Moq;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var movieRepoMock = new Mock<IRepository<Movie>>();
            var actorRepoMock = new Mock<IRepository<Actor>>();
            var roleRepoMock = new Mock<IRepository<Role>>();

            MovieBusinessLogic mbl = new MovieBusinessLogic(movieRepoMock.Object, actorRepoMock.Object);

            movieRepoMock.Setup(m => m.Get(1))
                .Returns(new Movie { Id = 1, Genre = "Action", ReleaseDate = DateTime.Now, Title = "Death Race 2000" });

            Movie got = mbl.GetMovie(1);

            Assert.AreEqual("Death Race 2000", got.Title);
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                mbl.GetMovie(2);
            });

            mbl.CreateMovie(got);
            movieRepoMock.Verify(m => m.Create(got));

        }
    }
}