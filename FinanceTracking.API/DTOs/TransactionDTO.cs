using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracking.API.DTOs;

public sealed class TransactionDTO
{
    public DateTimeOffset TransactionDate { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public CategoryDTO Category { get; set; } = default!;
    public AccountDTO Account { get; set; } = default!;
    public MemberDTO Member { get; set; } = default!;
    public UserDTO User { get; set; } = default!;
}