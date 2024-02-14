using SchoolBus_Model.Entities.Abstract;

namespace SchoolBus_Model.Entities.Concretes
{
    public class Bus:BaseEntity
    {
        public string Number { get; set; }
        public int SeatCount { get; set; }

        //navigation property
        public virtual ICollection<Student> Students { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
