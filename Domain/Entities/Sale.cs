using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Sale
{
    public int Id { get; set; }
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    public decimal TotalPrice { get; set; }
    public ICollection<SaleDetails> SaleDetails { get; set; } = new List<SaleDetails>();
}
