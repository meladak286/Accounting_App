using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccApp.Library.Models
{
    public class BillModel : IModel
    {
        /// <summary>
        /// the unique identifier for the bill
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// the customer name who bought this bill
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// the bill total amount
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// the date when the bill have been saved
        /// </summary>
        public DateTime BillDate { get; set; }
    }
}
