using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AccApp.Library.Models
{
    public class ProductModel : IModel
    {
        public ProductModel(int id =0, string name="", int qty=0, decimal Price =0, int manufacturerId=0)
        {
            Id = id;
            ProductName = name;
            Quantity = qty;
            this.Price = Price;
            ManufacturerID = manufacturerId;


        }
		/// <summary>
		/// the unique identifier for the product
		/// </summary>
        public int Id { get; set; }
		/// <summary>
		/// the product name
		/// </summary>
        private string _ProductName;

		public string ProductName
		{
			get { return _ProductName; }
			set { _ProductName = value; }
		}
		/// <summary>
		/// the product quantity
		/// </summary>
		private int _Quantity;

		public int Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}
		/// <summary>
		/// the price of one piece of this product
		/// </summary>
		private decimal _Price;

		public decimal Price
		{
			get { return _Price; }
			set { _Price = value; }
		}
		/// <summary>
		/// the manufacturer id
		/// </summary>
		private int _ManufacturerID;

		public int ManufacturerID
		{
			get { return _ManufacturerID; }
			set { _ManufacturerID = value; }
		}





	}
}
