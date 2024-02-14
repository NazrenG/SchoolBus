using SchoolBus_Model.Entities.Abstract;

namespace SchoolBus_Model.Entities.Concretes
{
    public class Student: BaseEntity
    {
        public string LastName { get; set; }
        public string HomeAddress { get; set; }
        //foreign key
        public int BusId { get; set; }
        public int ClassId { get; set; }
        public int ParentId { get; set; }

        //navigation property
        public virtual Bus Bus { get; set; }
        public virtual Class Class { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
