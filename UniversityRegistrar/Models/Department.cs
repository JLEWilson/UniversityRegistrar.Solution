using System.Collections.Generic;

namespace Registrar.Models
{
  public class Department
  {
    public Department()
    {
      this.JoinEntities1 = new HashSet<DepartmentStudent>() ;
      this.JoinEntities2 = new HashSet<CourseDepartment>();
    }

    public int DepartmentId {get; set;}
    public string Name {get; set;}
    public virtual ICollection<DepartmentStudent> JoinEntities1 {get; set;}
    public virtual ICollection<CourseDepartment> JoinEntities2 {get; set;}
  }
}