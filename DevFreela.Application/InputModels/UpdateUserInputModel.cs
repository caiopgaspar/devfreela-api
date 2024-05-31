using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public class UpdateUserInputModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Email { get; private set; }
        public DateTime BirthDate { get; set; }
    }
}
