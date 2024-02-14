using SchoolBus_Model.Entities.Abstract;

namespace SchoolBus_Model.Entities.Concretes
{
    public class Parent: BaseEntity_Parent_Driv
    {

        //navigation property
        public virtual ICollection<Student> Students { get; set; }
    }
}
