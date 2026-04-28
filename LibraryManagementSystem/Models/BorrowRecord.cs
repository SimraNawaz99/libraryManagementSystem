using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models;

public partial class BorrowRecord
{
    public int BorrowId { get; set; }

    public int? BookId { get; set; }

    public int? UserId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public bool? IsReturned { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
