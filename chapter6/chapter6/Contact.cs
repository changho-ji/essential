using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter6
{
    public class Contact : PdaItem
    {
        public string Address { get; set; }

        public string Phone { get; set; }

        void Save()
        {
            FileStream stream = File.OpenWrite(
                ObjectKey + ".dat");
        }

        void Load(PdaItem pdaItem)
        {
            // 보호 수준으로 인해 액세스 하지 못함
            // pdaItem.ObjectKey = Guid.Empty;

            Contact contact = pdaItem as Contact;
            if(contact != null)
            {
                contact.ObjectKey = Guid.Empty;
            }
        }

        /*
        private Person InternalPerson { get; set; }

        public string FirstName
        {
            get { return InternalPerson.FirstName; }
            set { InternalPerson.FirstName = value; }
        }

        public string LastName
        {
            get { return InternalPerson.LastName; }
            set { InternalPerson.LastName = value; }
        }
        */

        public override string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            set
            {
                string[] names = value.Split(' ');
                FirstName = names[0];
                LastName = names[1];
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
