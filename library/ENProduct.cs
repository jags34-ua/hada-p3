using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }
        public string Code
        {
            get { return _code; }
            set { this._code = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { this._amount = value; }
        }

        public float Price
        {
            get { return _price; }
            set { this._price = value; }
        }

        public int Category
        {
            get { return _category; }
            set { this._category = value; }
        }

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { this._creationDate = value; }
        }

        public ENProduct()
        {
            this.Name = "";
            this.Code = "";
            this.Amount = 0;
            this.Price = 0;
            this.Category = 0;
            //this.CreationDate = 1 / 01 / 2000 00:00:00;
        }

        public ENProduct(string code,string name,int amount,float price,DateTime creationDate)
        {
            this.Code = code;
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.CreationDate = creationDate;
        }

        public bool Create()
        {
            bool confirmation = false;
            CADProduct newCadProduct = new CADProduct();
            if (!newCadProduct.Read(this))
            {
                confirmation = newCadProduct.Create(this);
            }
            return confirmation;

        }

        public bool Update()
        {
            ENProduct pivote = new ENProduct();
            CADProduct updateProduct = new CADProduct();
            bool confirmation = false;
            pivote.Code = this.Code;
            pivote.Amount = this.Amount;
            pivote.Category = this.Category;
            pivote.CreationDate = this.CreationDate;
            pivote.Price = this.Price;
            pivote.Name = this.Name;

            if (updateProduct.Read(this))
            {
                this.Code = pivote.Code;
                this.Amount = pivote.Amount;
                this.Category = pivote.Category;
                this.CreationDate = pivote.CreationDate;
                this.Price = pivote.Price;
                this.Name = pivote.Name;
                confirmation = updateProduct.Update(this);
            }
            return confirmation;
        }

        public bool Delete()
        {

        }

        public bool Read()
        {
            CADProduct readProduct = new CADProduct();
            bool confirm = readProduct.Read(this);
            return confirm;
        }

        public bool ReadFirst()
        {

        }

        public bool ReadNext()
        {

        }

        public bool ReadPrev()
        {

        }
    }
}
