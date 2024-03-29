using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
<<<<<<< HEAD
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
=======
        // Private fields
        private string code;
        private string name;
        private int amount;
        private float price;
        private DateTime creationDate;

        // Public properties
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public int Amount
        {
<<<<<<< HEAD
            get { return _amount; }
            set { this._amount = value; }
=======
            get { return amount; }
            set { amount = value; }
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public float Price
        {
<<<<<<< HEAD
            get { return _price; }
            set { this._price = value; }
        }

        public int Category
        {
            get { return _category; }
            set { this._category = value; }
=======
            get { return price; }
            set { price = value; }
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public DateTime CreationDate
        {
<<<<<<< HEAD
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

=======
            get { return creationDate; }
            set { creationDate = value; }
        }

        // Default constructor
        public ENProduct() { }

        // Parameterized constructor
        public ENProduct(string code, string name, int amount, float price, DateTime creationDate)
        {
            this.code = code;
            this.name = name;
            this.amount = amount;
            this.price = price;
            this.creationDate = creationDate;
        }

        // Methods
        public bool Create()
        {
            CADProduct cadProduct = new CADProduct();
            return cadProduct.Create(this);
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool Update()
        {
<<<<<<< HEAD
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
=======
            CADProduct cadProduct = new CADProduct();
            return cadProduct.Update(this);
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool Delete()
        {
<<<<<<< HEAD
            CADProduct deleteProduct = new CADProduct();
            bool confirmation = false;
            confirmation = deleteProduct.Delete(this);
            return confirmation;
=======
            CADProduct cadProduct = new CADProduct();
            return cadProduct.Delete(this);
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool Read()
        {
<<<<<<< HEAD
            CADProduct readProduct = new CADProduct();
            bool confirmation = readProduct.Read(this);
            return confirmation;
=======
            CADProduct cadProduct = new CADProduct();
            return cadProduct.Read(this);
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool ReadFirst()
        {
<<<<<<< HEAD
            CADProduct readFirstProduct = new CADProduct();
            bool confirmation = readFirstProduct.ReadFirst(this);
            return confirmation;
=======
            CADProduct cadProduct = new CADProduct();
            return cadProduct.ReadFirst(this);
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool ReadNext()
        {
<<<<<<< HEAD
            CADProduct readNextProduct = new CADProduct();
            bool confirmation = false;
            if (readNextProduct.Read(this))
                confirmation = readNextProduct.ReadNext(this);
            return confirmation;
=======
            CADProduct cadProduct = new CADProduct();
            return cadProduct.ReadNext(this);
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool ReadPrev()
        {
<<<<<<< HEAD
            ENProduct pivote = new ENProduct(this.Code,this.Name,this.Amount,this.Price,this.CreationDate);
            CADProduct readPrevProduct = new CADProduct();
            bool confirmation = false;
            if(readPrevProduct.ReadFirst(pivote) && this.Code != pivote.Code)
            {
                confirmation = readPrevProduct.ReadPrev(this);
            }
            return confirmation;
=======
            CADProduct cadProduct = new CADProduct();
            return cadProduct.ReadPrev(this);
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }
    }
}