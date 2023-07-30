using AccApp.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace AccApp.Library
{
    public static class dbManager
    {




        private static SqlConnection DataBaseConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AccConnString"].ConnectionString);
        private static SqlDataAdapter adapter = new SqlDataAdapter("select * from customer", DataBaseConnection);
        private static DataSet ds;

        const string CUSTOMER_TABLE = "Customer";
        const string PHONE_TABLE = "Phone";
        const string MANUFACTURER_TABLE = "Manufacturer";
        const string PRODUCT_TABLE = "Product";
        const string BILL_TABLE = "Bill";
        const string BILLROW_TABLE = "BillRow";

        public static BindingList<ManufacturerProductModel> ManufacturerProducts = new BindingList<ManufacturerProductModel>();


        /// <summary>
        /// fills the data set with data from the database
        /// </summary>
        public static void FillDS()
        {
            ds = new DataSet();
            string[] tablesNames = { CUSTOMER_TABLE, MANUFACTURER_TABLE, PRODUCT_TABLE, BILL_TABLE, PHONE_TABLE, BILLROW_TABLE };
            foreach (string table in tablesNames)
            {
                DataTable tbl = new DataTable();
                adapter.SelectCommand = new SqlCommand($"select * from {table}", DataBaseConnection);
                adapter.FillSchema(tbl, SchemaType.Mapped);
                adapter.Fill(tbl);
                ds.Tables.Add(tbl);
            }
        }

        /// <summary>
        /// adds constraints to the data set tables
        /// </summary>
        public static void AddConstraints()
        {
            UniqueConstraint ManufacturerNameUq = new UniqueConstraint(ds.Tables[MANUFACTURER_TABLE].Columns[1]);
            UniqueConstraint ProductNameManufacturerUq = new UniqueConstraint(new DataColumn[] { ds.Tables[PRODUCT_TABLE].Columns[1], ds.Tables[PRODUCT_TABLE].Columns[2] });
            UniqueConstraint CustomerNameUq = new UniqueConstraint(ds.Tables[CUSTOMER_TABLE].Columns[1]);

            if (ds.Tables[MANUFACTURER_TABLE].Constraints.Count < 2)
            {
                ds.Tables[MANUFACTURER_TABLE].Constraints.Add(ManufacturerNameUq);
            }
            if (ds.Tables[PRODUCT_TABLE].Constraints.Count < 2)
            {
                ds.Tables[PRODUCT_TABLE].Constraints.Add(ProductNameManufacturerUq);
            }
            if (ds.Tables[CUSTOMER_TABLE].Constraints.Count < 2)
            {
                ds.Tables[CUSTOMER_TABLE].Constraints.Add(CustomerNameUq);
            }

        }
        /// <summary>
        /// refresh the data set records
        /// </summary>
        /// <param name="tableName">the data table name that needs the update</param>
        private static void UpdateDataBase(string tableName)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from {tableName}", ConfigurationManager.ConnectionStrings["AccConnString"].ConnectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(ds, tableName);
        }

        /// <summary>
        /// get the manufacturer id by name
        /// </summary>
        /// <param name="name">the name of the manufacturer</param>
        /// <returns>the id for this manufacturer</returns>
        public static int GetManufacturerID(string name)
        {

            if (ds.Tables.Count > 0)
            {
                DataRow[] rows = ds.Tables[1].Select($"mname = '{name}' ", "");
                if (rows.Count() > 0)
                    return Convert.ToInt32(rows[0]["mid"]);
            }
            return -1;
        }
        /// <summary>
        /// start the connection with the database
        /// </summary>
        public static void OpenDB()
        {
            DataBaseConnection.Open();
        }
        /// <summary>
        /// close the connection with the database
        /// </summary>
        public static void CloseDB()
        {
            DataBaseConnection.Close();
        }

        /// <summary>
        /// fills the given data grid view with data from the data base
        /// </summary>
        /// <param name="dgv">the data grid view </param>
        /// <param name="type">the type of models the data grid view displays</param>
        public static void FillDGVFromDB(DataGridView dgv, modelTypes type)
        {
            if (dgv.Tag != null)
            {
                if (type == modelTypes.Customer)
                {
                    dgv.DataSource = ds.Tables[CUSTOMER_TABLE];
                }
                else if (type == modelTypes.Manufacturer)
                {
                    dgv.DataSource = ds.Tables[MANUFACTURER_TABLE];
                }
                else if (type == modelTypes.Product)
                {
                    GetManufactureProducts();
                    dgv.DataSource = ManufacturerProducts;
                }
                else if(type == modelTypes.Bill){
                    dgv.DataSource = ds.Tables[BILL_TABLE];
                }

            }
        }
        /// <summary>
        /// fills the manufacturer products list
        /// </summary>
        public static void GetManufactureProducts()
        {
            ManufacturerProducts = new BindingList<ManufacturerProductModel>
                ((from pro in ds.Tables[PRODUCT_TABLE].AsEnumerable()
                  join man in ds.Tables[MANUFACTURER_TABLE].AsEnumerable()
                  on (int)pro["mid"] equals (int)man["mid"]
                  select new ManufacturerProductModel
                  {
                      ProductId = (int)pro["pid"],
                      ProductName = (string)pro["pname"],
                      ManufacturerName = (string)man["mname"],
                      ManufacturerId = (int)man["mid"],
                      Price = (decimal)pro["price"],
                      Quantity = (int)pro["qty"]
                  }).ToList());
        }
        /// <summary>
        /// fills the given combo box with data from the data base
        /// </summary>
        /// <param name="cbx">the combo box</param>
        public static void FillCBXFromDB(ComboBox cbx, modelTypes type)
        {
            if (type == modelTypes.Manufacturer)
            {
                cbx.DataSource = ds.Tables[MANUFACTURER_TABLE];
                cbx.DisplayMember = "mname";
            }
            else if (type == modelTypes.Customer)
            {
                cbx.DataSource = ds.Tables[CUSTOMER_TABLE];
                cbx.DisplayMember = "cname";
                cbx.ValueMember = "cid";
            }
            else if (type == modelTypes.Product)
            {
                GetManufactureProducts();
                cbx.DataSource = ManufacturerProducts;
                cbx.DisplayMember = "FullInfo";
                cbx.ValueMember = "ProductId";
            }
        }

        /// <summary>
        /// find the data row by the model id
        /// </summary>
        /// <param name="tableName">the table name which contains the data row</param>
        /// <param name="id">the model id </param>
        /// <returns>the data row that represents this id</returns>
        private static DataRow FindRow(string tableName, int id)
        {
            return ds.Tables[tableName].Rows.Find(id);
        }

        /// <summary>
        /// save the model to the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">the model to be saved</param>
        public static void AddModelsToDataBase<T>(T model)
        {
            if (model is CustomerModel c)
            {
                ds.Tables[CUSTOMER_TABLE].Rows.Add(c.Id, c.CustomerName, c.CustomerAddress);
                UpdateDataBase(CUSTOMER_TABLE);
                InsertPhone(c);
            }
            else if (model is ProductModel p)
            {
                ds.Tables[PRODUCT_TABLE].Rows.Add(p.Id, p.ProductName, p.ManufacturerID, p.Price, p.Quantity);
                UpdateDataBase(PRODUCT_TABLE);
            }
            else if (model is ManufacturerModel m)
            {
                ds.Tables[MANUFACTURER_TABLE].Rows.Add(m.Id, m.ManufacturerName);
                UpdateDataBase(MANUFACTURER_TABLE);
            }
            else if (model is BillRowModel r)
            {
                ds.Tables[BILLROW_TABLE].Rows.Add(r.BillId, r.ProductName, r.Quantity, r.Price);
                UpdateDataBase(BILLROW_TABLE);
            }
            else if (model is BillModel b)
            {
                ds.Tables[BILL_TABLE].Rows.Add(b.Id, b.CustomerName, b.Total, b.BillDate);
                UpdateDataBase(BILL_TABLE);
            }
        }
        /// <summary>
        /// edit the model in the data base
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">the model to be edited</param>
        public static void EditModel<T>(T model)
        {
            DataRow row;
            if (model is CustomerModel c)
            {
                row = ds.Tables[CUSTOMER_TABLE].Rows.Find(c.Id);
                row[1] = c.CustomerName;
                row[2] = c.CustomerAddress;
                DataRow[] phones = ds.Tables[PHONE_TABLE].Select($"cid = {c.Id}");
                foreach (var item in phones)
                {
                    item.Delete();
                }
                InsertPhone(c);
                UpdateDataBase(CUSTOMER_TABLE);
            }
            else if (model is ProductModel p)
            {
                row = ds.Tables[PRODUCT_TABLE].Rows.Find(p.Id);
                row[1] = p.ProductName;
                row[2] = p.ManufacturerID;
                row[3] = p.Price;
                row[4] = p.Quantity;
                UpdateDataBase(PRODUCT_TABLE);
            }
            else if (model is ManufacturerModel m)
            {
                row = ds.Tables[MANUFACTURER_TABLE].Rows.Find(m.Id);
                row[1] = m.ManufacturerName;
                UpdateDataBase(MANUFACTURER_TABLE);
            }
        }
        /// <summary>
        ///  gets the id for the new model
        /// </summary>
        /// <param name="type">the type of the new model</param>
        /// <returns>the id</returns>
        public static int GetModelsId(modelTypes type)
        {
            SqlCommand cmd;
            SqlDataReader reader;
            int id = 1000;
            if (type == modelTypes.Customer)
            {
                cmd = new SqlCommand($"SELECT IDENT_CURRENT('{CUSTOMER_TABLE}')", DataBaseConnection);
                reader = cmd.ExecuteReader();
                reader.Read();                
                id = Convert.ToInt32(reader[0]); 
                reader.Close();
            }
            else if (type == modelTypes.Product)
            {
                cmd = new SqlCommand($"SELECT IDENT_CURRENT('{PRODUCT_TABLE}')", DataBaseConnection);
                reader = cmd.ExecuteReader();
                reader.Read();
                id = Convert.ToInt32(reader[0]);
                reader.Close();
            }
            else if (type == modelTypes.Bill)
            {
                cmd = new SqlCommand($"SELECT IDENT_CURRENT('{BILL_TABLE}')", DataBaseConnection);
                reader = cmd.ExecuteReader();
                reader.Read();
                id = Convert.ToInt32(reader[0]);
                reader.Close();
            }
            else if (type == modelTypes.Manufacturer)
            {
                cmd = new SqlCommand($"SELECT IDENT_CURRENT('{MANUFACTURER_TABLE}')", DataBaseConnection);
                reader = cmd.ExecuteReader();
                reader.Read();
                id = Convert.ToInt32(reader[0]);
                reader.Close();
            }
            return id + 1;
        }
        /// <summary>
        /// delete the model from the data base
        /// </summary>
        /// <param name="id">the id of the model to be deleted</param>
        /// <param name="type">the type of the model</param>
        public static void DeleteModelFromDB(int id, modelTypes type)
        {
            DataRow row = null;
            string tableName = "";
            if (type == modelTypes.Customer)
            {
                tableName = CUSTOMER_TABLE;
                DataRow[] phones = ds.Tables[PHONE_TABLE].Select($"cid = {id}", "");
                foreach (var phone in phones)
                {
                    phone.Delete();
                }
                UpdateDataBase(PHONE_TABLE);
            }
            else if (type == modelTypes.Manufacturer)
            {
                tableName = MANUFACTURER_TABLE;
            }
            else if (type == modelTypes.Product)
            {
                tableName = PRODUCT_TABLE;
            }
            else if (type == modelTypes.BillRow)
            {
                tableName = BILLROW_TABLE;
            }
            else if (type == modelTypes.Bill)
            {
                tableName = BILL_TABLE;
            }
            row = FindRow(tableName, id);
            row.Delete();
            UpdateDataBase(tableName);
        }

        /// <summary>
        /// get the phone numbers list for the customer using his id
        /// </summary>
        /// <param name="id">the customer id </param>
        /// <returns>phone numbers list</returns>
        public static BindingList<string> GetPhoneNumbers(int id)
        {
            BindingList<string> output = new BindingList<string>();
            var result = ds.Tables[PHONE_TABLE].Select($"cid = {id}");
            foreach (var item in result)
            {
                output.Add(item[1].ToString());
            }
            return output;
        }
        /// <summary>
        /// add new phone numbers to the customer phone table
        /// </summary>
        /// <param name="c">the customer to add phones to his list</param>
        public static void InsertPhone(CustomerModel c)
        {
            foreach (string ph in c.CustomerPhones)
            {
                ds.Tables[PHONE_TABLE].Rows.Add(c.Id, ph);
                UpdateDataBase(PHONE_TABLE);
            }
        }

        /// <summary>
        /// adds new quantity to the existing product quantity
        /// </summary>
        /// <param name="id">the product id</param>
        /// <param name="qty">the new quantity</param>
        public static void AddQTY(int id, int qty)
        {
            DataRow row = ds.Tables[PRODUCT_TABLE].Rows.Find(id);
            int oldQty = Convert.ToInt32(row[4]);
            row[4] = oldQty + qty;
            UpdateDataBase(PRODUCT_TABLE);
        }
        /// <summary>
        /// get the maximum quantity for this product
        /// </summary>
        /// <param name="id">the product id</param>
        /// <returns>the maximum quantity</returns>
        public static int GetMaxQTY(int id)
        {
            int output;
            DataRow rows = ds.Tables[PRODUCT_TABLE].Rows.Find(id);
            if(rows is null)
            {
                return 0;
            }
            output = Convert.ToInt32(rows[4]);
            return output;
        }

        /// <summary>
        /// get this product price
        /// </summary>
        /// <param name="id">the id of the product</param>
        /// <returns>the price of the product</returns>
        public static decimal GetProductPrice(int id)
        {
            decimal price = 0;
            DataRow row = ds.Tables[PRODUCT_TABLE].Rows.Find(id);
            if (row != null)
            {
                price = Convert.ToDecimal(row[3]);
            }

            return price;
        }

        /// <summary>
        /// get the bill list of items
        /// </summary>
        /// <param name="billId">the bill id </param>
        /// <returns>list of bill items (bill rows)</returns>
        public static List<BillRowModel> GetBillRows(int billId)
        {
            List<BillRowModel> output = (from rows in ds.Tables[BILLROW_TABLE].AsEnumerable()
                                         where (int)rows["bid"] == billId
                                         select new BillRowModel
                                         {
                                             Price = (decimal)rows["price"],
                                             ProductName = (string)rows["pname"],
                                             Quantity = (int)rows["qty"]
                                         }).ToList();
            return output;
                                        
        }
        /// <summary>
        /// remove the sold product quantities from the database
        /// </summary>
        /// <param name="billRows">the bill items</param>
        public static void RemoveSoldProducts(List<BillRowModel> billRows)
        {
            foreach (BillRowModel row in billRows)
            {
                int productId = row.ProductId;
                int quantity = row.Quantity;
                DataRow result = ds.Tables[PRODUCT_TABLE].Rows.Find(productId);
                result[4] = Convert.ToInt32(result[4]) - quantity;
                if (Convert.ToInt32(result[4]) == 0)
                {
                    result.Delete();
                }
                else if (Convert.ToInt32(result[4]) < 0)
                {
                    billRows.Remove(row);
                }

            }
            UpdateDataBase(PRODUCT_TABLE);
        }

    }


}
