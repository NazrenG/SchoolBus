using SchoolBus_Model.Entities.Abstract;

namespace SchoolBus_Model.Entities.Concretes
{
    public class Route: BaseEntity
    {
        //foreign key
        public int BusId { get; set; }

        //navigation property
        public virtual Bus Bus { get; set; }
    }
}
