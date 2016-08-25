using AgeRanger.Models;
using AgeRanger.Service;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace AgeRanger.Tests
{
    [TestFixture]
    public class AgeRangerTests
    {
        private Mock<IGetItemsUseCase> _getItemsUseCaseMock;

        [Test]
        public void GivenSearchTerm_WhenISearch_TheReturnFilteredResult()
        {
            const string searchTerm = "Will";
            _getItemsUseCaseMock = new Mock<IGetItemsUseCase>();
            _getItemsUseCaseMock.Setup(x => x.Execute(It.IsAny<string>())).Returns(new PersonAgeGroup[]
            {
                new PersonAgeGroup
                {
                    Id = 1,
                    FirstName = "Will",
                    LastName = "Smith",
                    Age = 50
                },
                new PersonAgeGroup
                {
                    Id = 1,
                    FirstName = "Anne",
                    LastName = "Smith",
                    Age = 51
                }
            }.AsQueryable());

            var useCase = new GetItemUseCase();
            var list = useCase.Execute(searchTerm).ToArray();
            Assert.That(list.Count(), Is.EqualTo(1));
        }
    }
}
