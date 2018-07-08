using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter6
{
    class Program
    {
        public class BaseClass
        {
            public void DisplayName()
            {
                Console.WriteLine("BaseClass");
            }
        }

        public class DerivedClass : BaseClass
        {
            public virtual void DisplayName()
            {
                Console.WriteLine("DerivedClass");
            }
        }

        public class SubDerivedClass : DerivedClass
        {
            public override void DisplayName()
            {
                Console.WriteLine("SubDerivedClass");
            }
        }

        public class SuperSubDerivedClass : SubDerivedClass
        {
            public new void DisplayName()
            {
                Console.WriteLine("SuperSubDerivedClass");
            }
        }

        public static void Main(string[] args)
        {
            SuperSubDerivedClass superSubDerivedClass = new SuperSubDerivedClass();

            SubDerivedClass subDerivedClass = superSubDerivedClass;
            DerivedClass derivedClass = superSubDerivedClass;
            BaseClass baseClass = superSubDerivedClass;

            superSubDerivedClass.DisplayName();
            subDerivedClass.DisplayName();
            derivedClass.DisplayName();
            baseClass.DisplayName();

            //Contact contact = new Contact();
            //contact.Name = "Inigo Montoya";

            // System.Console.WriteLine(contact.Name);

            // 보호 수준으로 인해 액세스하지 못함
            // contact.ObjectKey = Guid.NewGuid();

            /*
            Contact contact;
            PdaItem item;

            contact = new Contact();
            item = contact;

            item.Name = "Inigo Montoya";

            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            */
        }
    }
}
