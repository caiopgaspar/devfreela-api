
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha Descricao de Projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha Descricao de Projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha Descricao de Projeto 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Caio Gaspar", "caiohpgaspar@gmail.com", new DateTime(1991, 7, 17)),
                new User("Henrique", "caio_gaspar@yahoo.com.br", new DateTime(1991, 1, 1)),
                new User("Caio Pessoa", "caiohpgaspar@gmail.com", new DateTime(1991, 7, 7)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
