using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proWeb;
using library;

namespace proWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgToShow.Text = "Welcome to the Products Management main page.";
            LoadCategories();
        }

        protected void toCreate(object sender, EventArgs e)
        {
            if(codeProduct.Text != "" && nameProduct.Text != "" && amountProduct.Text != ""
                && priceProduct.Text != "" && cdateProduct.Text != "")
            {
                // Verificar restricciones para Code.
                if (codeProduct.Text.Length < 1 || codeProduct.Text.Length > 16)
                {
                    msgToShow.Text = "Code must be between 1 and 16 characters.";
                    return;
                }
                // Verificar si el código del producto ya existe en la base de datos.
                ENProduct existingProduct = new ENProduct();
                existingProduct.Code = codeProduct.Text;
                if (existingProduct.Read())
                {
                    msgToShow.Text = "A product with the same code already exists in the database.";
                    return;
                }
                // Verificar restricciones para Name.
                if (nameProduct.Text.Length > 32)
                {
                    msgToShow.Text = "Product name must have a maximum of 32 characters.";
                    return;
                }
                // Verificar restricciones para Amount.
                int amount;
                if (!int.TryParse(amountProduct.Text, out amount) || amount < 0 || amount > 9999)
                {
                    msgToShow.Text = "Amount must be an integer between 0 and 9999.";
                    return;
                }
                // Verificar restricciones para Price.
                decimal price;
                if (!decimal.TryParse(priceProduct.Text, out price) || price < 0 || price > 9999.99m)
                {
                    msgToShow.Text = "Price must be a real value between 0 and 9999.99.";
                    return;
                }
                // Verificar restricciones para Creation Date.
                DateTime creationDate;
                if (!DateTime.TryParseExact(cdateProduct.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out creationDate))
                {
                    msgToShow.Text = "Invalid creation date format. Please use dd/mm/yyyy hh:mm:ss.";
                    return;
                }
                // Verificar si se seleccionó una categoría válida.
                int category;
                if (!int.TryParse(categoryListProduct.SelectedValue, out category) || category < 0 || category > 3)
                {
                    msgToShow.Text = "Please select a valid category.";
                    return;
                }
                // Si todas las restricciones se cumplen, entonces los datos son válidos.
                ENProduct newProduct = new ENProduct();
                newProduct.Code = codeProduct.Text;
                newProduct.Name = nameProduct.Text;
                newProduct.Price = float.Parse(priceProduct.Text);
                newProduct.Amount = int.Parse(amountProduct.Text);
                newProduct.Category = int.Parse(categoryListProduct.SelectedValue) + 1;
                //newProduct.CreationDate = DateTime.Parse(cdateProduct.Text);
                newProduct.CreationDate = DateTime.ParseExact(cdateProduct.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);



                if (newProduct.Create())
                {
                    msgToShow.Text = "Product with code: " + newProduct.Code + " and name: " + newProduct.Name + " was inserted.";
                }
                else
                {
                    msgToShow.Text = "Product was not inserted.";
                }
            }
            else
            {
                msgToShow.Text = "Some of the fields have not been specified,please fill them before trying to insert a product.";
            }
        }
        protected void toUpdate(object sender, EventArgs e)
        {
            if (codeProduct.Text != "" && nameProduct.Text != "" && amountProduct.Text != ""
                && priceProduct.Text != "" && cdateProduct.Text != "")
            {
                // Verificar restricciones para Code.
                if (codeProduct.Text.Length < 1 || codeProduct.Text.Length > 16)
                {
                    msgToShow.Text = "Code must be between 1 and 16 characters.";
                    return;
                }
                // Verificar restricciones para Name.
                if (nameProduct.Text.Length > 32)
                {
                    msgToShow.Text = "Product name must have a maximum of 32 characters.";
                    return;
                }
                // Verificar restricciones para Amount.
                int amount;
                if (!int.TryParse(amountProduct.Text, out amount) || amount < 0 || amount > 9999)
                {
                    msgToShow.Text = "Amount must be an integer between 0 and 9999.";
                    return;
                }
                // Verificar restricciones para Price.
                decimal price;
                if (!decimal.TryParse(priceProduct.Text, out price) || price < 0 || price > 9999.99m)
                {
                    msgToShow.Text = "Price must be a real value between 0 and 9999.99.";
                    return;
                }
                // Verificar restricciones para Creation Date.
                DateTime creationDate;
                if (!DateTime.TryParseExact(cdateProduct.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out creationDate))
                {
                    msgToShow.Text = "Invalid creation date format. Please use dd/mm/yyyy hh:mm:ss.";
                    return;
                }
                // Verificar si se seleccionó una categoría válida.
                int category;
                if (!int.TryParse(categoryListProduct.SelectedValue, out category) || category < 0 || category > 3)
                {
                    msgToShow.Text = "Please select a valid category.";
                    return;
                }
                // Si todas las restricciones se cumplen, entonces los datos son válidos.
                ENProduct newProduct = new ENProduct();
                newProduct.Code = codeProduct.Text;
                newProduct.Name = nameProduct.Text;
                newProduct.Price = float.Parse(priceProduct.Text);
                newProduct.Amount = int.Parse(amountProduct.Text);
                newProduct.Category = int.Parse(categoryListProduct.SelectedValue) + 1;
                newProduct.CreationDate = DateTime.Parse(cdateProduct.Text);

                if (newProduct.Update())
                {
                    msgToShow.Text = "Product with code: " + newProduct.Code + " was updated.";
                }
                else
                {
                    msgToShow.Text = "Product was not updated.";
                }
            }
            else
            {
                msgToShow.Text = "Some of the fields have not been specified,please fill them before trying an update.";
            }
        }

        protected void toDelete(object sender, EventArgs e)
        {
            if (codeProduct.Text == "")
            {
                msgToShow.Text = "Insert a product code before trying to delete it.";
            }
            else
            {
                ENProduct deleteProduct = new ENProduct();
                deleteProduct.Code = codeProduct.Text;
                if (deleteProduct.Read())
                {
                    if (deleteProduct.Delete())
                    {
                        msgToShow.Text = "Product with code: " + deleteProduct.Code + " correctly deleted.";
                    }
                    else
                    {
                        msgToShow.Text = "Product with code: " + deleteProduct.Code + " could not be deleted.";
                    }
                }
                else
                {
                    msgToShow.Text = "Product was not found in the data base.";
                }
            }
        }


        protected void toRead(object sender, EventArgs e)
        {
            if(codeProduct.Text == "")
            {
                msgToShow.Text = "Insert a product code before trying to read the information.";
            }
            else
            {
                ENProduct readProduct = new ENProduct();
                readProduct.Code = codeProduct.Text;
                if (readProduct.Read())
                {
                    codeProduct.Text = readProduct.Code;
                    nameProduct.Text = readProduct.Name;
                    amountProduct.Text = readProduct.Amount.ToString();
                    categoryListProduct.SelectedIndex = readProduct.Category - 1;
                    priceProduct.Text = readProduct.Price.ToString();
                    cdateProduct.Text = readProduct.CreationDate.ToString();

                    msgToShow.Text = "Product with code: " + readProduct.Code + " correctly shown.";
                }
                else
                {
                    msgToShow.Text = "Product was not found in the data base.";
                }
            }
        }
        // For this 3 methods we have to retrieve every product from the database and then show only the product that has to be shown.
        // (according to the statement)
        protected void toReadFirst(object sender, EventArgs e)
        {
            ENProduct readFirstProduct = new ENProduct();
            if (readFirstProduct.ReadFirst())
            {
                codeProduct.Text = readFirstProduct.Code;
                nameProduct.Text = readFirstProduct.Name;
                amountProduct.Text = readFirstProduct.Amount.ToString();
                categoryListProduct.SelectedIndex = readFirstProduct.Category - 1;
                priceProduct.Text = readFirstProduct.Price.ToString();
                cdateProduct.Text = readFirstProduct.CreationDate.ToString();

                msgToShow.Text = "First product with code: " + readFirstProduct.Code + " correctly shown.";
            }
            else
            {
                msgToShow.Text = "No product could be shown because the database does not contain none.";
            }
        }
  
        protected void toReadNext(object sender, EventArgs e)
        {
            if (codeProduct.Text != "")
            {
                ENProduct readNextProduct = new ENProduct();
                readNextProduct.Code = codeProduct.Text;
                if (readNextProduct.ReadNext())
                {
                    codeProduct.Text = readNextProduct.Code;
                    nameProduct.Text = readNextProduct.Name;
                    amountProduct.Text = readNextProduct.Amount.ToString();
                    categoryListProduct.SelectedIndex = readNextProduct.Category - 1;
                    priceProduct.Text = readNextProduct.Price.ToString();
                    cdateProduct.Text = readNextProduct.CreationDate.ToString();

                    msgToShow.Text = "Next product with code: " + readNextProduct.Code + " correctly shown.";
                }
                else
                {
                    msgToShow.Text = "There are not more products to show.";
                }
            }
            else
            {
                msgToShow.Text = "Insert a product before trying to get its next.";
            }
        }

        protected void toReadPrev(object sender, EventArgs e)
        {
            if (codeProduct.Text != "")
            {
                ENProduct readPrevProduct = new ENProduct();
                readPrevProduct.Code = codeProduct.Text;
                if (readPrevProduct.ReadPrev())
                {
                    codeProduct.Text = readPrevProduct.Code;
                    nameProduct.Text = readPrevProduct.Name;
                    amountProduct.Text = readPrevProduct.Amount.ToString();
                    categoryListProduct.SelectedIndex = readPrevProduct.Category - 1;
                    priceProduct.Text = readPrevProduct.Price.ToString();
                    cdateProduct.Text = readPrevProduct.CreationDate.ToString();

                    msgToShow.Text = "Previous product with code: " + readPrevProduct.Code + " correctly shown.";
                }
                else
                {
                    msgToShow.Text = "There are not more previous products to show.";
                }
            }
            else
            {
                msgToShow.Text = "Insert a product before trying to get its previous.";
            }
        }
        private void LoadCategories()
        {
            CADCategory cadCategory = new CADCategory();
            List<ENCategory> categories = cadCategory.ReadAll();

            categoryListProduct.DataSource = categories;
            categoryListProduct.DataTextField = "Name"; 
            categoryListProduct.DataValueField = "Id"; 
            categoryListProduct.DataBind();
        }
    }
}