using System;
using System.Collections.Generic;

namespace UMS.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public virtual Hostel? Hostel { get; set; }
}
