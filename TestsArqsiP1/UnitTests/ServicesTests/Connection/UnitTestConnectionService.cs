using ArqsiP1.DataModels;
using ArqsiP1.Dto;
using ArqsiP1.Repositories.Interfaces;
using ArqsiP1.Services;
using Moq;
using Xunit;

namespace TestsArqsiP1.UnitTests.ServicesTests.Connection
{
    public class UnitTestConnectionService
    {
        [Fact]
        public void TestCreateConnection()
        {
            // Arrange
            ConnectionSchema connectionSchemaReturned = new ConnectionSchema(1, 1, 2, 5, "REQUESTED");
            Moq.Mock<IConnectionRepo> mockedConnectionRepo = new Moq.Mock<IConnectionRepo>();
            mockedConnectionRepo.Setup(x => x.CreateConnection(It.IsAny<ConnectionSchema>())).Returns(connectionSchemaReturned);

            ConnectionDto solutionConnectionDto = new ConnectionDto(1, 1, 2, 5, "REQUESTED");

            // Act
            ConnectionService connectionService = new ConnectionService(mockedConnectionRepo.Object);
            ConnectionDto resultConnectionDTO = connectionService.CreateConnection(solutionConnectionDto);

            // Assert
            Assert.True(solutionConnectionDto.connectionId.Equals(resultConnectionDTO.connectionId));
            Assert.True(solutionConnectionDto.userA.Equals(resultConnectionDTO.userA));
            Assert.True(solutionConnectionDto.userB.Equals(resultConnectionDTO.userB));
            Assert.True(solutionConnectionDto.strength.Equals(resultConnectionDTO.strength));
            Assert.True(solutionConnectionDto.status.Equals(resultConnectionDTO.status));
        }

        [Fact]
        public void TestUpdateConnection()
        {
            // Arrange
            ConnectionSchema connectionSchemaReturned = new ConnectionSchema(1, 1, 2, 5, "REQUESTED");
            Moq.Mock<IConnectionRepo> mockedConnectionRepo = new Moq.Mock<IConnectionRepo>();
            mockedConnectionRepo.Setup(x => x.UpdateConnection(It.IsAny<ConnectionSchema>())).Returns(connectionSchemaReturned);

            ConnectionDto solutionConnectionDto = new ConnectionDto(1, 1, 2, 8, "REQUESTED");

            // Act
            ConnectionService connectionService = new ConnectionService(mockedConnectionRepo.Object);
            ConnectionDto resultConnectionDTO = connectionService.UpdateConnection(solutionConnectionDto);

            // Assert
            Assert.True(solutionConnectionDto.connectionId.Equals(resultConnectionDTO.connectionId));
            Assert.True(solutionConnectionDto.userA.Equals(resultConnectionDTO.userA));
            Assert.True(solutionConnectionDto.userB.Equals(resultConnectionDTO.userB));
            Assert.False(solutionConnectionDto.strength.Equals(resultConnectionDTO.strength));
            Assert.True(solutionConnectionDto.status.Equals(resultConnectionDTO.status));
        }

    }
}
