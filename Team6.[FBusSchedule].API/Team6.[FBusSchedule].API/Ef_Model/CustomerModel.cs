using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FBusSchedule_.API.Ef_Model
{
    public class CustomerModel
    {
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int? Age { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
