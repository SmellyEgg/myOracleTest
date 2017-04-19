using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForOracle.model
{
    class user
    {
        private string name = string.Empty;
        private string id = string.Empty;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
