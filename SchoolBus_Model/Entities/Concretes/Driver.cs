using SchoolBus_Model.Entities.Abstract;

namespace SchoolBus_Model.Entities.Concretes
{
    public class Driver: BaseEntity_Parent_Driv
    {
        public bool Licence { get; set; }
        //foreign key
        public int BusId { get; set; }

        //navigation property
        public virtual Bus Bus { get; set; }
    }
}
