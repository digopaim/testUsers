using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.WebAPI.ViewAndInputModel
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string DocumentNumber { get; set; }
    }
}
