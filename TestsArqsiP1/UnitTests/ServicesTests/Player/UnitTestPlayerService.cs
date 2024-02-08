using ArqsiP1.DataModels;
using ArqsiP1.Dto;
using ArqsiP1.Repositories.Interfaces;
using ArqsiP1.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestsArqsiP1.UnitTests.ServicesTests.Player
{
    public class UnitTestPlayerService
    {
        [Fact]
        public void TestCreatePlayer()
        {
            // Arrange
            PlayerSchema playerSchemaReturned = new PlayerSchema(1, "Teste Player", "testePais", "testeCidade",
                "testePassword", "testeEmail@email.com", "testePhone", "testeBirth", "testeAvatar", "testeLinked", "testeFace", "testeDesc", "JOY");
            Moq.Mock<IPlayerRepo> mockedPlayerRepo = new Moq.Mock<IPlayerRepo>();
            mockedPlayerRepo.Setup(x => x.CreatePlayer(It.IsAny<PlayerSchema>())).Returns(playerSchemaReturned);

            PlayerDto solutionPlayerDto = new PlayerDto(1, "Teste Player", "testePais", "testeCidade",
                "testePassword", "testeEmail@email.com", "testePhone", "testeBirth", "testeAvatar", "testeLinked", "testeFace", "testeDesc", "JOY");

            // Act
            PlayerService playerService = new PlayerService(mockedPlayerRepo.Object);
            PlayerDto resultPlayerDTO = playerService.CreatePlayer(solutionPlayerDto);

            // Assert
            Assert.True(solutionPlayerDto.playerId.Equals(resultPlayerDTO.playerId));
            Assert.True(solutionPlayerDto.nome.Equals(resultPlayerDTO.nome));
            Assert.True(solutionPlayerDto.country.Equals(resultPlayerDTO.country));
            Assert.True(solutionPlayerDto.city.Equals(resultPlayerDTO.city));
            Assert.True(solutionPlayerDto.password.Equals(resultPlayerDTO.password));
            Assert.True(solutionPlayerDto.email.Equals(resultPlayerDTO.email));
            Assert.True(solutionPlayerDto.phone.Equals(resultPlayerDTO.phone));
            Assert.True(solutionPlayerDto.birthdate.Equals(resultPlayerDTO.birthdate));
            Assert.True(solutionPlayerDto.avatar.Equals(resultPlayerDTO.avatar));
            Assert.True(solutionPlayerDto.linkedIn.Equals(resultPlayerDTO.linkedIn));
            Assert.True(solutionPlayerDto.facebook.Equals(resultPlayerDTO.facebook));
            Assert.True(solutionPlayerDto.description.Equals(resultPlayerDTO.description));
            Assert.True(solutionPlayerDto.emotionalState.Equals(resultPlayerDTO.emotionalState));
        }

        [Fact]
        public void TestUpdatePlayer()
        {
            // Arrange
            PlayerSchema playerSchemaReturned = new PlayerSchema(1, "Teste Player", "testePais", "testeCidade",
                "testePassword", "testeEmail@email.com", "testePhone", "testeBirth", "testeAvatar", "testeLinked", "testeFace", "testeDesc", "JOY");
            Moq.Mock<IPlayerRepo> mockedPlayerRepo = new Moq.Mock<IPlayerRepo>();
            mockedPlayerRepo.Setup(x => x.UpdatePlayer(It.IsAny<PlayerSchema>())).Returns(playerSchemaReturned);

            PlayerDto solutionPlayerDto = new PlayerDto(1, "Teste Player", "testePais", "testeCidade",
                "testePassword", "testeEmail@email.com", "testeNewPhone", "testeBirth", "testeAvatar", "testeLinked", "testeFace", "testeDesc", "ANGRY");

            // Act
            PlayerService playerService = new PlayerService(mockedPlayerRepo.Object);
            PlayerDto resultPlayerDTO = playerService.UpdatePlayer(solutionPlayerDto);

            // Assert
            Assert.True(solutionPlayerDto.playerId.Equals(resultPlayerDTO.playerId));
            Assert.True(solutionPlayerDto.nome.Equals(resultPlayerDTO.nome));
            Assert.True(solutionPlayerDto.country.Equals(resultPlayerDTO.country));
            Assert.True(solutionPlayerDto.city.Equals(resultPlayerDTO.city));
            Assert.True(solutionPlayerDto.password.Equals(resultPlayerDTO.password));
            Assert.True(solutionPlayerDto.email.Equals(resultPlayerDTO.email));
            Assert.False(solutionPlayerDto.phone.Equals(resultPlayerDTO.phone));
            Assert.True(solutionPlayerDto.birthdate.Equals(resultPlayerDTO.birthdate));
            Assert.True(solutionPlayerDto.avatar.Equals(resultPlayerDTO.avatar));
            Assert.True(solutionPlayerDto.linkedIn.Equals(resultPlayerDTO.linkedIn));
            Assert.True(solutionPlayerDto.facebook.Equals(resultPlayerDTO.facebook));
            Assert.True(solutionPlayerDto.description.Equals(resultPlayerDTO.description));
            Assert.False(solutionPlayerDto.emotionalState.Equals(resultPlayerDTO.emotionalState));
        }

    }
}
