using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace DevFreela.UnitTests.Application.Queries
//{
//    public class GetAllProjectsCommandHandlerTests
//    {
//        [Fact]
//        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
//        {
//            // Arrange
//            var projects = new List<Project>
//            {
//                new Project("Nome do Teste 1", "Descricao de Teste 1", 1, 2, 10000),
//                new Project("Nome do Teste 2", "Descricao de Teste 2", 1, 2, 20000),
//                new Project("Nome do Teste 3", "Descricao de Teste 3", 1, 2, 30000)
//            };

//            var projectRepositoryMock = Substitute.For<IProjectRepository>();
//            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

//            var getAllProjectsQuery = new GetAllProjectsQuery("");
//            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

//            // Act
//            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

//            // Assert
//            Assert.NotNull(projectViewModelList);
//            Assert.NotEmpty(projectViewModelList);
//            Assert.Equal(projects.Count, projectViewModelList.Count); // testa se o numero de projetos e o retorno são iguais

//            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
//        }
//    }
//}

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome do Teste 1", "Descricao de Teste 1", 1, 2, 10000),
                new Project("Nome do Teste 2", "Descricao de Teste 2", 1, 2, 20000),
                new Project("Nome do Teste 3", "Descricao de Teste 3", 1, 2, 30000)
            };

            var projectRepository = Substitute.For<IProjectRepository>();
            //projectRepository.GetAllAsync().Returns(Task.FromResult((IEnumerable<Project>)projects));
            projectRepository.GetAllAsync().Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepository);

            // Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count); // testa se o número de projetos e o retorno são iguais

            await projectRepository.Received(1).GetAllAsync();
        }
    }
}

