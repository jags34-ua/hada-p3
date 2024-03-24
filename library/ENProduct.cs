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

        }

        public ENProduct(string code,string name,int amount,float price,DateTime creationDate)
        {

        }

        public bool Create()
        {

        }

        public bool Update()
        {

        }

        public bool Delete()
        {

        }

        public bool Read()
        {

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
