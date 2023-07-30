using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AccApp.Library.Models
{
    public class ManufacturerModel : IModel
    {
        /// <summary>
        /// the unique identifier for the manufacturer
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// the manufacturer name
        /// </summary>
        private string _ManufacturerName;

		public string ManufacturerName
        {
			get { return _ManufacturerName; }
			set { _ManufacturerName = value; }
		}


	}
}
