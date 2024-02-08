using ArqsiP1.DataModels;
using ArqsiP1.Dto;
using ArqsiP1.Repositories.Interfaces;
using ArqsiP1.Services;
using Moq;
using Xunit;

namespace TestsArqsiP1.UnitTests.ServicesTests.Introduction
{
    public class UnitTestIntroductionService
    {
        [Fact]
        public void TestCreateIntroduction()
        {
            // Arrange
            IntroductionSchema introductionSchemaReturned = new IntroductionSchema(1, 1, 2, 3, "message Teste", "REQUESTED");
            Moq.Mock<IIntroductionRepo> mockedIntroductionRepo = new Moq.Mock<IIntroductionRepo>();
            mockedIntroductionRepo.Setup(x => x.CreateIntroduction(It.IsAny<IntroductionSchema>())).Returns(introductionSchemaReturned);

            IntroductionDto solutionIntroductionDto = new IntroductionDto(1, 1, 2, 3, "message Teste", "REQUESTED");

            // Act
            IntroductionService introductionService = new IntroductionService(mockedIntroductionRepo.Object);
            IntroductionDto resultIntroductionDTO = introductionService.CreateIntroduction(solutionIntroductionDto);

            // Assert
            Assert.True(solutionIntroductionDto.introductionId.Equals(resultIntroductionDTO.introductionId));
            Assert.True(solutionIntroductionDto.playerId.Equals(resultIntroductionDTO.playerId));
            Assert.True(solutionIntroductionDto.itermediatePlayerId.Equals(resultIntroductionDTO.itermediatePlayerId));
            Assert.True(solutionIntroductionDto.targetPlayerId.Equals(resultIntroductionDTO.targetPlayerId));
            Assert.True(solutionIntroductionDto.message.Equals(resultIntroductionDTO.message));
            Assert.True(solutionIntroductionDto.status.Equals(resultIntroductionDTO.status));
        }

   
        [Fact]
        public void TestUpdateIntroduction()
        {
            // Arrange
            IntroductionSchema introductionSchemaReturned = new IntroductionSchema(1, 1, 2, 3, "message Teste", "REQUESTED");
            Moq.Mock<IIntroductionRepo> mockedIntroductionRepo = new Moq.Mock<IIntroductionRepo>();
            mockedIntroductionRepo.Setup(x => x.UpdateIntroduction(It.IsAny<IntroductionSchema>())).Returns(introductionSchemaReturned);

            IntroductionDto solutionIntroductionDto = new IntroductionDto(1, 1, 2, 3, "message Teste", "ACEPTED");

            // Act
            IntroductionService introductionService = new IntroductionService(mockedIntroductionRepo.Object);
            IntroductionDto resultIntroductionDTO = introductionService.UpdateIntroduction(solutionIntroductionDto);

            // Assert
            Assert.True(solutionIntroductionDto.introductionId.Equals(resultIntroductionDTO.introductionId));
            Assert.True(solutionIntroductionDto.playerId.Equals(resultIntroductionDTO.playerId));
            Assert.True(solutionIntroductionDto.itermediatePlayerId.Equals(resultIntroductionDTO.itermediatePlayerId));
            Assert.True(solutionIntroductionDto.targetPlayerId.Equals(resultIntroductionDTO.targetPlayerId));
            Assert.True(solutionIntroductionDto.message.Equals(resultIntroductionDTO.message));
            Assert.False(solutionIntroductionDto.status.Equals(resultIntroductionDTO.status));
        }

    }
}
