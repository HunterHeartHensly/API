using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models.StudentManagement
{
    public class AllPaginationModel
    {
        public List<StudentModel> Stuudents { get; set; } = new List<StudentModel>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int itemsPerPage { get; set; }
        public int stdcount { get; set; }
    }
}
