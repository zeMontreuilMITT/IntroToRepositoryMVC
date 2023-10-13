using IntroToRepositoryMVC.Data;
using IntroToRepositoryMVC.Models;
using IntroToRepositoryMVC.Models.BusinessLogicLayer;
using Moq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RepoPatternTests
{
    [TestClass]
    public class MovieBLLTests
    {
        private Mock<IRepository<Movie>> _movieRepo = new Mock<IRepository<Movie>>();
        private Mock<IRepository<Actor>> _actorRepo = new Mock<IRepository<Actor>>();
        private Mock<IRepository<Role>> _roleRepo = new Mock<IRepository<Role>>();
        public MovieBusinessLogic InitializeBLL()
        {
            return new MovieBusinessLogic(_movieRepo.Object, _actorRepo.Object, _roleRepo.Object);
        }

        [TestMethod]
        public void GetActor_ValidId_ReturnsActorObject()
        {
            // arrange
            int actorId = 1;
            Actor testActor = new Actor() { Id = 1 };
            MovieBusinessLogic mbl = InitializeBLL();

            _actorRepo.Setup(r => r.Get(actorId)).Returns(testActor);

            // act
            Actor queriedActor = mbl.GetActor(actorId);

            // assert
            _actorRepo.Verify(r => r.Get(actorId));
            Assert.AreEqual(testActor, queriedActor);
        }

        [TestMethod]
        public void GetActor_IdNotFound_ThrowsInvalidOperation()
        {
            // arrange
            int invalidId = 2;
            int actorId = 1;
            Actor testActor = new Actor() { Id = actorId };
            MovieBusinessLogic mbl = InitializeBLL();

            _actorRepo.Setup(r => r.Get(actorId)).Returns(testActor);

            // act and assert
            Assert.ThrowsException<InvalidOperationException>(() => mbl.GetActor(invalidId));
        }

        [TestMethod]
        public void AddToRole_ValidInputs_InvokesCreateRoleOnRepoAndReturnsRole()
        {
            // arrange
            Movie movie = new Movie { Id = 1 };
            Actor actor = new Actor { Id = 1 };
            string roleTitle = "test";
            MovieBusinessLogic mbl = InitializeBLL();

            Role correctRole = new Role { ActorId = actor.Id, MovieId = movie.Id, RoleCredit = roleTitle };

            //act 
            Role testRole = mbl.AddToRole(movie, actor, roleTitle);

            // assert
            _roleRepo.Verify(r => r.Create(testRole));

            string testSerial = JsonSerializer.Serialize(testRole);
            string correctSerial = JsonSerializer.Serialize(correctRole);

            Assert.AreEqual(correctSerial, testSerial);
        }

    }
}