using SchoolBus_Model.Entities.Abstract;

namespace SchoolBus_Model.Entities.Concretes
{
    public class Class:BaseEntity
    {

        //navigation property
        public virtual ICollection<Student> Students { get; set; }
    }
}
