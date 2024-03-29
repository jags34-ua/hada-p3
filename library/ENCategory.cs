using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
            set { this._id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }

        // Constructor
        public ENCategory(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
