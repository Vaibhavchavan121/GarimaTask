using Microsoft.AspNetCore.Mvc.Rendering;

namespace GarimaTask.Models
{
    public class StudentVM
    {
       public List<Student> StudentsList { get;set; }
       public Student student { get; set; }
        public IEnumerable<SelectListItem> cities { get; set; }
        public IEnumerable<SelectListItem> states { get; set; }
        public bool IsEditMode { get; set; }
    }
}
