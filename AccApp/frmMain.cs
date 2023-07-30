using AccApp.Library;
using AccApp.Library.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            
            InitializeComponent();

        }


        const int PHONE_NUMBER_LEN = 10;


        BindingList<string> Phones = new BindingList<string>();
        BindingList<BillRowModel> billRows = new BindingList<BillRowModel>();
        BillModel bill;



        /// <summary>
        /// getting the values of the new product from the input fields and returning the full model.
        /// </summary>
        /// <returns>populated product model</returns>
        private ProductModel FillNewProductInfo()
        {

            int.TryParse(txtNewProductID.Text, out int id);
            string name = txtNewProductName.Text;
            int.TryParse(txtNewProductQTY.Text, out int qty);
            decimal.TryParse(txtNewProductPrice.Text, out decimal Price);

            // get the manufacturer id using the manufacturer name.
            int mID = dbManager.GetManufacturerID(cbxProductManufacturerName.Text);

            ProductModel product = new ProductModel(id, name, qty, Price, mID);
            return product;

        }
        /// <summary>
        /// getting the values of the new customer from the input fields and returning the full model.
        /// </summary>
        /// <returns>populated customer model</returns>
        private CustomerModel FillNewCustomerInfo()
        {
            CustomerModel customer = new CustomerModel()
            {
                Id = int.Parse(txtCustomerId.Text),
                CustomerName = txtCustomerName.Text,
                CustomerAddress = txtCustomerAddress.Text,
                CustomerPhones = lbxPhones.Items.Cast<string>().ToList()
            };
            return customer;
        }
        /// <summary>
        /// getting the values of the new manufacturer from the input fields and returning the full model.
        /// </summary>
        /// <returns>populated manufacturer model</returns>
        private ManufacturerModel FillNewManufacturerInfo()
        {
            ManufacturerModel manufacturer = new ManufacturerModel
            {
                Id = int.Parse(txtManufacturerId.Text),
                ManufacturerName = txtManufacturerName.Text
            };
            return manufacturer;
        }
        /// <summary>
        /// validate the input fields for the manufacturer information.
        /// </summary>
        /// <returns>returns if the inputs are valid or not</returns>
        private bool CheckFieldsForManufacturer()
        {
            bool output = true;
            if(txtManufacturerId.Text.Trim() == string.Empty)
            {
                ManufacturerIdReq.Visible = true;
                output = false;
            }
            if(txtManufacturerName.Text.Trim() == string.Empty)
            {
                ManufactuereNameReq.Visible = true;
                output = false;
            }
            return output;
        }
        /// <summary>
        /// validate the input fields for the product information.
        /// </summary>
        /// <returns>returns if the inputs are valid or not</returns>
        private bool CheckFieldsForProduct()
        {
            bool output = true;
            if(txtNewProductID.Text.Trim() == string.Empty)
            {
                ProductIdReq.Visible = true;
                output = false;
            }
            if(txtNewProductName.Text.Trim() == string.Empty)
            {
                ProductNameReq.Visible = true;
                output = false;
            }
            if(txtNewProductPrice.Text.Trim() == string.Empty)
            {
                ProductPriceReq.Visible = true;
                output = false;
            }
            if(txtNewProductQTY.Text.Trim() == string.Empty)
            {
                ProductQuantityReq.Visible = true;
                output = false;
            }
            if(cbxProductManufacturerName.SelectedIndex == -1)
            {
                ProductManufacturerReq.Visible = true;
                output = false;
            }
            return output;
        }
        /// <summary>
        /// validate the input fields for the customer information.
        /// </summary>
        /// <returns>returns if the inputs are valid or not</returns>
        private bool CheckFieldsForCustomer()
        {
            bool output = true;
            if(txtCustomerId.Text.Trim() == string.Empty)
            {
                CustomerIdReq.Visible = true;
                output = false;
            }
            if(txtCustomerName.Text.Trim() == string.Empty)
            {
                CustomerNameReq.Visible = true;
                output = false;
            }
            if(txtCustomerAddress.Text.Trim() == string.Empty)
            {
                CustomerAddressReq.Visible = true;
                output = false;
            }


            return output;
        }
        /// <summary>
        /// validate the input fields for the bill information.
        /// </summary>
        /// <returns>returns if the inputs are valid or not</returns>
        private bool CheckFieldsForNewBill()
        {
            bool output = true;
            if(cbxCustomerName.SelectedIndex == -1)
            {
                output = false;
                BillCustomerNameReq.Visible = true;
            }
            return output;
        }
        /// <summary>
        /// validate the input fields for the product information. 
        /// </summary>
        /// <returns>returns if the bill is ready to add products to it</returns>
        private bool CheckFieldsToAddProductToBill()
        {
            
            bool output = true;
            if (cbxProductName.SelectedIndex == -1)
            {
                output = false;
                BillProductNameReq.Visible = true;
            }
            if (lblBillId.Text == string.Empty)
            {
                output = false;
                BillIdReq.Visible = true;
            }
            return output;
        }
        /// <summary>
        /// check if the bill is not empty.
        /// </summary>
        /// <returns>returns if the bill is ready for saving</returns>
        private bool CheckIfBillReadyToSave()
        {            
            return billRows.Count > 0;
        }
        /// <summary>
        /// display the new bill info in the display fields.
        /// </summary>
        private void CreateNewBill()
        {
            bill.Id = dbManager.GetModelsId(modelTypes.Bill);
            lblBillId.Text = bill.Id.ToString();
            bill.CustomerName = cbxCustomerName.Text;
            bill.BillDate = DateTime.Now;
            lblCustomerName.Text = bill.CustomerName;
            lblBillDate.Text = bill.BillDate.ToString("g");
            BillIdReq.Visible = false;
        }

        /// <summary>
        /// displays the new ids for the models
        /// </summary>
        private void DisplayId()
        {
            txtManufacturerId.Text = dbManager.GetModelsId(modelTypes.Manufacturer).ToString();
            txtNewProductID.Text = dbManager.GetModelsId(modelTypes.Product).ToString();
            txtCustomerId.Text = dbManager.GetModelsId(modelTypes.Customer).ToString();
        }

        /// <summary>
        /// adds the phone to the customer phones list
        /// </summary>
        private void AddPhone()
        {
            string PhoneNumber = txtPhone.Text;
            if (PhoneNumber.Length == PHONE_NUMBER_LEN)
            {
                Phones.Add(PhoneNumber);
                txtPhone.Clear();
                txtPhone.Focus();
            }
            else
            {
                MessageBox.Show("the number is is too short or too long...");
            }
        }

        private void LoadPhones()
        {
            lbxPhones.DataSource = Phones;
        }
        /// <summary>
        /// displays the bill items in the bill data grid view
        /// </summary>
        private void LoadBillRows()
        {
            dgvBill.DataSource = billRows;
        }

        /// <summary>
        /// show the selected manufacturer information
        /// </summary>
        /// <param name="row">the selected data grid view row</param>
        private void ShowSelectedManufacturerData(DataGridViewRow row)
        {
            txtManufacturerId.Text = row.Cells[0].Value?.ToString();
            txtManufacturerName.Text = row.Cells[1].Value?.ToString();
        }
        /// <summary>
        /// show the selected product information
        /// </summary>
        /// <param name="row">the selected data grid view row</param>
        private void ShowSelectedProductData(DataGridViewRow row)
        {
            txtNewProductID.Text = row.Cells[0].Value?.ToString();
            txtNewProductName.Text = row.Cells[2].Value?.ToString();
            cbxProductManufacturerName.Text = row.Cells[3].Value?.ToString();
            txtNewProductPrice.Text = row.Cells[4].Value?.ToString();
            txtNewProductQTY.Text = row.Cells[5].Value?.ToString();
        }
        /// <summary>
        /// show the selected customer information
        /// </summary>
        /// <param name="row">the selected data grid view row</param>
        private void ShowSelectedCustomer(DataGridViewRow row)
        {
            txtCustomerId.Text = row.Cells[0].Value?.ToString();
            txtCustomerName.Text = row.Cells[1].Value?.ToString();
            txtCustomerAddress.Text = row.Cells[2].Value?.ToString();

        }

        private void ClearDGVSelection(DataGridView dgv)
        {
            dgv.ClearSelection();
        }


        /// <summary>
        /// clears all the text boxes in the given tab page
        /// </summary>
        /// <param name="page"></param>
        private void ClearTextBox(TabPage page)
        {
            foreach(Control c in page.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// shows the maximum product quantity
        /// </summary>
        private void ShowMaximumQuantity()
        {
            // check if the user has selected an item and if the selected value type is int
            if (cbxProductName.SelectedIndex >= 0 && cbxProductName.SelectedValue is Int32)
            {
                // get the product id 
                int id = Convert.ToInt32(cbxProductName.SelectedValue);
                // get the max
                numericBillProductQty.Maximum = dbManager.GetMaxQTY(Convert.ToInt32(id));
            }
        }
        /// <summary>
        /// prepare the form to edit the selected row
        /// </summary>
        private void EnableEditModeManufacturer()
        {
            btnNewManufacturer.Enabled = true;
            btnAddManufacturer.Enabled = false;
            btnEditManufacturer.Enabled = true;
            btnDeleteManufacturer.Enabled = true;
        }
        /// <summary>
        /// prepare the form to edit the selected row
        /// </summary>
        private void EnableEditModeProduct()
        {
            btnNewProduct.Enabled = true;
            btnAddNewProduct.Enabled = false;
            btnDeleteProduct.Enabled = true;
            btnEditProduct.Enabled = true;
            btnAddNewQTY.Enabled = true;
            txtAddNewQTY.Enabled = true;
        }
        /// <summary>
        /// prepare the form to edit the selected row
        /// </summary>
        private void EnableEditModeCustomer()
        {
            btnNewCustomer.Enabled = true;
            btnAddCustomer.Enabled = false;
            btnEditCustomer.Enabled = true;
            btnDeleteCustomer.Enabled = true;
        }
        /// <summary>
        /// prepare the form to add new manufacturer
        /// </summary>
        private void EnableAddModeManufacturer()
        {
            btnNewManufacturer.Enabled = false;
            btnAddManufacturer.Enabled = true;
            btnEditManufacturer.Enabled = false;
            btnDeleteManufacturer.Enabled = false;
            ClearDGVSelection(dgvManufacturer);
            ClearTextBox(ManufacturerPage);
            DisplayId();
        }
        /// <summary>
        /// prepare the form to add new product
        /// </summary>
        private void EnableAddModeProduct()
        {
            btnNewProduct.Enabled = false;
            btnAddNewProduct.Enabled = true;
            btnDeleteProduct.Enabled = false;
            btnEditProduct.Enabled = false;
            btnAddNewQTY.Enabled = false;
            txtAddNewQTY.Enabled = false;
            // unselect the data grid view selection
            ClearDGVSelection(dgvAllProducts);
            // clear the text boxes 
            ClearTextBox(ProductPage);
            // display the id for the new model
            DisplayId();
            txtNewProductQTY.Value = 1;
        }

        /// <summary>
        /// prepare the form to add new customer
        /// </summary>
        private void EnableAddModeCustomer()
        {
            btnNewCustomer.Enabled = false;
            btnAddCustomer.Enabled = true;
            btnEditCustomer.Enabled = false;
            btnDeleteCustomer.Enabled = false;
            // unselect the data grid view selection
            ClearDGVSelection(dgvCustomer);
            // clear the text boxes 
            ClearTextBox(CustomerPage);
            // clear the phones list items
            Phones = new BindingList<string>();
            // refresh phones list
            LoadPhones();
            // display the id for the new model
            DisplayId();
        }

        private void LoadData()
        {
            // start the connection with the database
            dbManager.OpenDB();
            // fill the data set with all the tables from the database
            dbManager.FillDS();
            // add the constraints to the tables
            dbManager.AddConstraints();
            // load all the records in the data grid views
            LoadDGVData();
            // fill the combo boxes
            dbManager.FillCBXFromDB(cbxProductManufacturerName, modelTypes.Manufacturer);
            dbManager.FillCBXFromDB(cbxCustomerName, modelTypes.Customer);
            dbManager.FillCBXFromDB(cbxProductName, modelTypes.Product);
            // set the combo box selected item to be none
            cbxProductName.SelectedIndex = -1;
            cbxProductManufacturerName.SelectedIndex = -1;
            cbxCustomerName.SelectedIndex = -1;
            // display new models ids
            DisplayId();
            // load customer phone numbers
            LoadPhones();
            // load bill items to the data grid view
            LoadBillRows();
            //load all the products with the manufacturer name
            LoadManufacturerAndProduct();
        }

        /// <summary>
        /// display all the data from the database in the data grid views
        /// </summary>
        private void LoadDGVData()
        {
            dbManager.FillDGVFromDB(dgvAllProducts, modelTypes.Product);
            dbManager.FillDGVFromDB(dgvCustomer, modelTypes.Customer);
            dbManager.FillDGVFromDB(dgvManufacturer, modelTypes.Manufacturer);
            dgvManufacturer.Sort(dgvManufacturer.Columns[0], ListSortDirection.Ascending);
        }

        /// <summary>
        /// load all the products with the manufacturer name
        /// </summary>
        private void LoadManufacturerAndProduct()
        {
            cbxProductName.DataSource = dbManager.ManufacturerProducts;
            cbxProductName.DisplayMember = "FullInfo";
        }

        /// /////////// Events ****

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckFieldsForProduct())// validate inputs
                {
                    // populate the model from the input fields
                    ProductModel product = FillNewProductInfo();
                    // save the model in the database
                    dbManager.AddModelsToDataBase<ProductModel>(product);
                    // refresh the data grid views to include the new model
                    dbManager.FillDGVFromDB(dgvAllProducts, modelTypes.Product);
                    // refresh the combo box to include the new model             
                    dbManager.FillCBXFromDB(cbxProductName, modelTypes.Product);
                }
            }
            catch (ConstraintException)
            {
                MessageBox.Show("Can not add product with the same name and manufacturer id");
            }
            finally
            {
                // prepare the form to add new product
                EnableAddModeProduct();
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

            try
            {
                if (CheckFieldsForCustomer())// validate inputs
                {
                    // populate the model from the input fields
                    CustomerModel customer = FillNewCustomerInfo();
                    // save the model in the database
                    dbManager.AddModelsToDataBase<CustomerModel>(customer);
                }
            }
            catch (ConstraintException)
            {
                MessageBox.Show("Customer name must be unique");
            }
            finally
            {
                // prepare the form to add new customer
                EnableAddModeCustomer();
            }

        }

        private void btnAddManufacturer_Click(object sender, EventArgs e)
        {
            if (CheckFieldsForManufacturer())// validate inputs
            {
                try
                {
                    // populate the model from the input fields
                    ManufacturerModel manufacturer = FillNewManufacturerInfo();
                    // save the model in the database
                    dbManager.AddModelsToDataBase<ManufacturerModel>(manufacturer);
                    // refresh the combo box to include the new model
                    dbManager.FillCBXFromDB(cbxProductManufacturerName, modelTypes.Manufacturer);
                }
                catch (ConstraintException)
                {
                    MessageBox.Show("Manufacturer name must be unique...");
                }
                finally
                {
                    // prepare the form to add new manufacturer
                    EnableAddModeManufacturer();
                }
            }
        }


        private void frmMain_Load(object sender, EventArgs e)
        { 
            LoadData();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // end the connection with the data base
            dbManager.CloseDB();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // add the new phone number to the phones list
            AddPhone();
            // refresh the phone list
            LoadPhones();
        }




        private void btnDeleteManufacturer_Click(object sender, EventArgs e)
        {
            if (dgvManufacturer.SelectedRows.Count > 0)// check if the user has selected a row
            {
                DialogResult result = MessageBox.Show("All products from this manufacturer will be deleted!", "Are you sure you want to delete this?",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)// make sure the user want to delete the model
                {
                    // delete the model from the data base
                    dbManager.DeleteModelFromDB(Convert.ToInt32(dgvManufacturer.SelectedRows[0].Cells[0].Value), modelTypes.Manufacturer);
                    // clear all the input fields and prepare them to add new manufacturer
                    ClearTextBox(ManufacturerPage);
                    // display the id for the new model
                    DisplayId();
                    // refresh the data grid view 
                    dbManager.FillDGVFromDB(dgvAllProducts, modelTypes.Product);
                    // refresh the combo box
                    dbManager.FillCBXFromDB(cbxProductName, modelTypes.Product);

                }
            }
            else
            {
                MessageBox.Show("You need to select a row to delete...");
            }

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvAllProducts.SelectedRows.Count > 0)// check if the user has selected a row
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)// make sure the user want to delete the model
                {
                    // delete the model from the data base
                    dbManager.DeleteModelFromDB(Convert.ToInt32(dgvAllProducts.SelectedRows[0].Cells[0].Value), modelTypes.Product);
                    // clear all the input fields and prepare them to add new product
                    ClearTextBox(ProductPage);
                    // display the id for the new model
                    DisplayId();
                    // refresh the data grid view 
                    dbManager.FillDGVFromDB(dgvAllProducts, modelTypes.Product);
                    dbManager.FillDGVFromDB(dgvManufacturer, modelTypes.Manufacturer);
                    // refresh the combo box 
                    dbManager.FillCBXFromDB(cbxProductName, modelTypes.Product);
                }
            }
            else
            {
                MessageBox.Show("You need to select a row to delete...");
            }


        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)// check if the user has selected a row
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)// make sure the user want to delete the model
                {
                    // delete the model from the data base
                    dbManager.DeleteModelFromDB(Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells[0].Value), modelTypes.Customer);
                    // clear all the input fields and prepare them to add new customer
                    ClearTextBox(CustomerPage);
                    // display the id for the new model
                    DisplayId();
                }
            }
            else
            {
                MessageBox.Show("You need to select a row to delete...");
            }

        }

        private void btnEditManufacturer_Click(object sender, EventArgs e)
        {
            if (CheckFieldsForManufacturer())// validate inputs
            {
                try
                {
                    if (dgvManufacturer.SelectedRows.Count > 0)// check if the user has selected a row
                    {
                        // populate the model from the input fields
                        ManufacturerModel manufacturer = FillNewManufacturerInfo();
                        // edit the record in the database and save it
                        dbManager.EditModel<ManufacturerModel>(manufacturer);
                        // refresh the combo box
                        dbManager.FillCBXFromDB(cbxProductManufacturerName, modelTypes.Manufacturer);
                    }
                    // prepare the form to add new manufacturer
                    EnableAddModeManufacturer();
                }
                catch (ConstraintException)// check if this record already exist in the database
                {
                    MessageBox.Show("Manufacturer name must be unique");
                    // prepare the form to edit the selected row
                    EnableEditModeManufacturer();
                }
            }            
        }
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (CheckFieldsForProduct())// validate inputs
            {
                try
                {
                    if (dgvAllProducts.SelectedRows.Count > 0)// check if the user has selected a row
                    {
                        // populate the model from the input fields
                        ProductModel product = FillNewProductInfo();
                        // edit the record in the database and save it
                        dbManager.EditModel<ProductModel>(product);
                        //refresh the data grid view
                        dbManager.FillDGVFromDB(dgvAllProducts, modelTypes.Product);
                        // refresh the combo box
                        dbManager.FillCBXFromDB(cbxProductManufacturerName, modelTypes.Manufacturer);
                    }
                    // prepare the form to add new product
                    EnableAddModeProduct();
                }
                catch (ConstraintException)// check if this record already exist in the database
                {
                    MessageBox.Show("Can not add product with the same name and manufacturer id");
                    // prepare the form to edit the selected row
                    EnableEditModeProduct();
                }                
            }
        }
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (CheckFieldsForCustomer())// validate inputs
            {
                try
                {
                    if(dgvCustomer.SelectedRows.Count > 0)// check if the user has selected a row
                    {
                        // populate the model from the input fields
                        CustomerModel customer = FillNewCustomerInfo();
                        // edit the record in the database and save it
                        dbManager.EditModel<CustomerModel>(customer);
                    }
                    // prepare the form to add new product
                    EnableAddModeCustomer();
                }
                catch (ConstraintException)// check if this record already exist in the database
                {

                    MessageBox.Show("Customer name must be unique");
                    // prepare the form to edit the selected row
                    EnableEditModeCustomer();
                }
            }
        }

        private void dgvManufacturer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvManufacturer.SelectedRows.Count > 0)// check if the user has selected a row 
            {
                // display the selected row information in the form
                ShowSelectedManufacturerData(dgvManufacturer.SelectedRows[0]);
                // prepare the form to edit the selected row
                EnableEditModeManufacturer();
            }
            else
            {
                // prepare the form to add new manufacturer
                EnableAddModeManufacturer();
            }
        }

        private void dgvAllProducts_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvAllProducts.SelectedRows.Count > 0)// check if the user has selected a row
            {
                // display the selected row information in the form
                ShowSelectedProductData(dgvAllProducts.SelectedRows[0]);
                // prepare the form to edit the selected row
                EnableEditModeProduct();
            }
            else
            {
                // prepare the form to add new product
                EnableAddModeProduct();
            }
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvCustomer.SelectedRows.Count > 0)// check if the user has selected a row
            {
                // display the selected row information in the form
                ShowSelectedCustomer(dgvCustomer.SelectedRows[0]);
                // populate the phones list with the customer phones from the database
                Phones = dbManager.GetPhoneNumbers(Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells[0].Value));
                // refresh the phones list
                LoadPhones();
                // prepare the form to edit the selected row
                EnableEditModeCustomer();
            }
            else
            {
                // prepare the form to add new customer
                EnableAddModeCustomer();
            }
        }

        private void btnNewManufacturer_Click(object sender, EventArgs e)
        {
            // prepare the form to add new manufacturer
            EnableAddModeManufacturer();

        }
        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            // prepare the form to add new product
            EnableAddModeProduct();
        }
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            // prepare the form to add new customer
            EnableAddModeCustomer();
        }

        private void txtManufacturerName_TextChanged(object sender, EventArgs e)
        {
            // hides the require label
            ManufactuereNameReq.Visible = false;
        }

        private void txtNewProductName_TextChanged(object sender, EventArgs e)
        {
            // hides the require label
            ProductNameReq.Visible = false;
        }

        private void txtNewProductPrice_TextChanged(object sender, EventArgs e)
        {
            // hides the require label
            ProductPriceReq.Visible = false;
        }

        private void txtNewProductQTY_TextChanged(object sender, EventArgs e)
        {
            // hides the require label
            ProductQuantityReq.Visible = false;
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            // hides the require label
            CustomerNameReq.Visible = false;
        }

        private void txtCustomerAddress_TextChanged(object sender, EventArgs e)
        {
            // hides the require label
            CustomerAddressReq.Visible = false;
        }

        private void cbxCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // hides the require label
            BillCustomerNameReq.Visible = false;
        }

        private void cbxProductManufacturerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProductManufacturerName.SelectedIndex >= 0) // check if the user has selected an item
            {
                // hides the require label
                ProductManufacturerReq.Visible = false;
            }
        }

        private void txtNewProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevents the user from typing anything except numbers.
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAddNewQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevents the user from typing anything except numbers.
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevents the user from typing anything except numbers.
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnAddNewQTY_Click(object sender, EventArgs e)
        {
            // check if the user has selected a row and the new quantity text box is not empty
            if(dgvAllProducts.SelectedRows.Count > 0 && txtAddNewQTY.Text.Trim() != string.Empty)
            {
                // add the new quantity to the database
                dbManager.AddQTY(Convert.ToInt32(dgvAllProducts.SelectedRows[0].Cells[0].Value), Convert.ToInt32(txtAddNewQTY.Text));
                //refresh the data grid view
                dbManager.FillDGVFromDB(dgvAllProducts, modelTypes.Product);
                // refresh the combo box
                dbManager.FillCBXFromDB(cbxProductName, modelTypes.Product);
                // clears the new quantity text box
                txtAddNewQTY.Clear();
            }
        }

        private void cbxProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // hides the require label
            BillProductNameReq.Visible = false;
            
            ShowMaximumQuantity();
        }


        private void btnAddProductToTheBill_Click_1(object sender, EventArgs e)
        {
            if (CheckFieldsToAddProductToBill())// validate inputs
            {
                // populate the bill model
                BillRowModel row = new BillRowModel
                {
                    ProductId = Convert.ToInt32(cbxProductName.SelectedValue),
                    BillId = Convert.ToInt32(lblBillId.Text),
                    ProductName = cbxProductName.Text,
                    Quantity = Convert.ToInt32(numericBillProductQty.Value),
                    Price = dbManager.GetProductPrice(Convert.ToInt32(cbxProductName.SelectedValue))
                };
                // check if the bill does not contain this product
                if (billRows.Where(r => r.ProductId == row.ProductId).Count() == 0)
                {
                    billRows.Add(row);
                    bill.Total += row.TotalPrice;
                    lblBillTotal.Text = bill.Total.ToString();
                }
                else
                {
                    MessageBox.Show("Can not add product two times!");
                }
                cbxProductName.SelectedIndex = -1;
                numericBillProductQty.Value = 1;
            }
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            if (CheckFieldsForNewBill())// validate inputs
            {
                // clear the bill items list 
                billRows = new BindingList<BillRowModel>();
                // refresh the bill list
                LoadBillRows();
                bill = new BillModel();               
                CreateNewBill();
                btnDeleteBillRow.Enabled = true;
                btnAddProductToTheBill.Enabled = true;
                btnPrint.Enabled = false;
                cbxCustomerName.SelectedIndex = -1;
            }
        }


        private void btnDeleteBillRow_Click(object sender, EventArgs e)
        {
            if(dgvBill.SelectedRows.Count > 0)// check if the user has selected a row
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item!", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)// make sure the user want to delete this model
                {
                    lblBillTotal.Text = (Convert.ToDecimal(lblBillTotal.Text) - 
                        Convert.ToDecimal(dgvBill.CurrentRow.Cells[5].Value))
                        .ToString();// calculate the bill total 
                    billRows.RemoveAt(dgvBill.CurrentRow.Index);// remove the selected product from the bill products
                }
            }
        }

        private void dgvBill_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvBill.SelectedRows.Count > 0)// check if the user has selected a row
            {
                btnDeleteBillRow.Enabled = true;
            }
            else
            {
                btnDeleteBillRow.Enabled = false;
            }
        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            if (CheckIfBillReadyToSave())// check if the bill is valid and ready to be saved
            {
                try
                {
                    btnPrint.Enabled = true;
                    btnDeleteBillRow.Enabled = false;
                    btnAddProductToTheBill.Enabled = false;
                    // save the bill to the database
                    dbManager.AddModelsToDataBase(bill);
                    // remove the sold product from the database
                    dbManager.RemoveSoldProducts(billRows.ToList());
                    // refresh the data grid view
                    dbManager.FillDGVFromDB(dgvAllProducts, modelTypes.Product);
                    // refresh the combo box
                    dbManager.FillCBXFromDB(cbxProductName, modelTypes.Product);
                    foreach (var row in billRows)
                    {
                        // save all the bill items
                        dbManager.AddModelsToDataBase(row);
                    }

                }
                catch
                {

                } 
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        { 
            // show report form
            frmReport report = new frmReport(bill.Id);
            report.ShowDialog();
        }

        private void lblBillsHistory_Click(object sender, EventArgs e)
        {
            // show bill history form
            frmBillHistory frmBillHistory = new frmBillHistory();
            frmBillHistory.ShowDialog();
        }

        private void numericBillProductQty_Enter(object sender, EventArgs e)
        {
            // select the bill product quantity value
            numericBillProductQty.Select(0, numericBillProductQty.Text.Length);
            ShowMaximumQuantity();
        }
    }
}
