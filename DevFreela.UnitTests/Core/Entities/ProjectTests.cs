using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Nome De Teste", "Descricao de Teste", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status); //testa se o status de início é Created
            Assert.Null(project.StartedAt); //testa se a data de início é nula (antes do início do projeto)

            Assert.NotNull(project.Title); //testa se título não é nulo
            Assert.NotEmpty(project.Title); //testa se título não é vazio

            Assert.NotNull(project.Description); //testa se a descrição não é nula
            Assert.NotEmpty(project.Description); //testa se a descrição não é vazia

            project.Start(); //início do projeto

            Assert.Equal(ProjectStatusEnum.InPrograss, project.Status); //testa se status esperado é igual ao status atual
            Assert.NotNull(project.StartedAt); //testa se data de início não é nula

            

        }
    }
}
