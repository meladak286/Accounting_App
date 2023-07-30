using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccApp.Library.Models
{
    public class ManufacturerProductModel
    {
        /// <summary>
        /// the unique identifier for the product
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// the unique identifier for the manufacturer
        /// </summary>
        public int ManufacturerId { get; set; }
        /// <summary>
        /// the product name
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// the manufacturer name
        /// </summary>
        public string ManufacturerName { get; set; }
        /// <summary>
        /// the price of this product
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// the quantity of this product
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// the name of the product and it's manufacturer
        /// </summary>
        public string FullInfo 
        {
            get 
            {
                return $"{ProductName} {ManufacturerName}";
            }
        }
    }
}
