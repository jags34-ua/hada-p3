using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;
using proWeb;

namespace proWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgToShow.Text = "Welcome to the Products Management main page.";
            // Aquí hay que añadir lo que pone en la última diapositiva.
        }

        protected void createButton_Click(object sender, EventArgs e)
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
                newProduct.Category = int.Parse(categoryListProduct.SelectedValue);
                newProduct.CreationDate = DateTime.Parse(cdateProduct.Text);

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
                msgToShow.Text = "Some of the fields have not been specified,please fill them before making an operation.";
            }
        }
        protected void updateButton_Click(object sender, EventArgs e)
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
                newProduct.Category = int.Parse(categoryListProduct.SelectedValue);
                newProduct.CreationDate = DateTime.Parse(cdateProduct.Text);

                if (newProduct.Update())
                {
                    msgToShow.Text = "Product with code: " + newProduct.Code + " and name: " + newProduct.Name + " was updated.";
                }
                else
                {
                    msgToShow.Text = "Product was not updated.";
                }
            }
            else
            {
                msgToShow.Text = "Some of the fields have not been specified,please fill them before making an operation.";
            }
        }
        protected void deleteButton_Click(object sender, EventArgs e)
        {

        }
        protected void readButton_Click(object sender, EventArgs e)
        {

        }
        protected void readfirstButton_Click(object sender, EventArgs e)
        {

        }
        protected void readprevButton_Click(object sender, EventArgs e)
        {

        }
        protected void readnextButton_Click(object sender, EventArgs e)
        {

        }

    }
}