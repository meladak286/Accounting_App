using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AccApp.Library.Models
{
	public class CustomerModel : IModel
	{
		public CustomerModel()
		{
		}
		/// <summary>
		/// the unique identifier for the customer
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// the customer name
		/// </summary>
		private string _CustomerName;

		public string CustomerName
		{
			get { return _CustomerName; }
			set { _CustomerName = value; }
		}
		/// <summary>
		/// the customer address
		/// </summary>
		private string _CustomerAddress;

		public string CustomerAddress
		{
			get { return _CustomerAddress; }
			set { _CustomerAddress = value; }
		}
		/// <summary>
		/// the customer list of phone numbers
		/// </summary>
		private List<string> _CustomerPhones = new List<string>();

        public List<string> CustomerPhones 
		{
			get { return _CustomerPhones; }
			set { _CustomerPhones = value; } 
		}

	}
}
