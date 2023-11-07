using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class CustomerVM
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }

    public int? Age { get; set; }

    public string Email { get; set; }
    public string? Password { get; set; }
    public bool? Status { get; set; }
}
