using ArqsiP1.DataModels;
using ArqsiP1.Dto;
using ArqsiP1.Repositories.Interfaces;
using ArqsiP1.Services;
using Moq;
using System;
using Xunit;

namespace TestsArqsiP1
{
    public class UnitTestTagService
    {
        [Fact]
        public void TestCreateTag()
        {
            // Arrange
            TagSchema tagSchemaReturned = new TagSchema(1, 1, null, null, "testTag");
            Moq.Mock<ITagRepo> mockedTagRepo = new Moq.Mock<ITagRepo>();
            mockedTagRepo.Setup(x => x.CreateTag(It.IsAny<TagSchema>())).Returns(tagSchemaReturned);
            TagDto solutionTagDto = new TagDto(1, 1, null, null, "testTag");

            // Act
            TagService tagService = new TagService(mockedTagRepo.Object);
            TagDto resultTagDTO = tagService.CreateTag(solutionTagDto);

            // Assert
            Assert.True(solutionTagDto.tagId.Equals(resultTagDTO.tagId));
            Assert.True(solutionTagDto.playerId.Equals(resultTagDTO.playerId));
            Assert.True(solutionTagDto.tag.Equals(resultTagDTO.tag));
        }

        [Fact]
        public void TestUpdateTag()
        {
            // Arrange
            TagSchema tagSchemaReturned = new TagSchema(1, 1, null, null, "testTag");
            Moq.Mock<ITagRepo> mockedTagRepo = new Moq.Mock<ITagRepo>();
            mockedTagRepo.Setup(x => x.UpdateTag(It.IsAny<TagSchema>())).Returns(tagSchemaReturned);
            TagDto solutionTagDto = new TagDto(1, 1, null, null, "testUpdateTag");

            // Act
            TagService tagService = new TagService(mockedTagRepo.Object);
            TagDto resultTagDTO = tagService.UpdateTag(solutionTagDto);

            // Assert
            Assert.True(solutionTagDto.tagId.Equals(resultTagDTO.tagId));
            Assert.True(solutionTagDto.playerId.Equals(resultTagDTO.playerId));
            Assert.False(solutionTagDto.tag.Equals(resultTagDTO.tag));
        }
    }
}
