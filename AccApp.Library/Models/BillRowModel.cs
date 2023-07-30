using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccApp.Library.Models
{
    public class BillRowModel
    {
        /// <summary>
        /// the unique identifier for the bill
        /// </summary>
        public int BillId { get; set; }
        /// <summary>
        /// the unique identifier for the product
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// the product name
        /// </summary>
        public string  ProductName { get; set; }
        /// <summary>
        /// the quantity of the product
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// the price of 1 piece of this product
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// the total price for this row
        /// </summary>
        public decimal TotalPrice 
        {
            get
            {
                return Quantity * Price;
            } 
        }
    }
}
