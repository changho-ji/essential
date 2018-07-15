using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter7
{
    public abstract class PdaItem
    {
        public PdaItem(string name)
        {
            Name = name;
        }

        public virtual string Name { get; set; }
    }

    class Contact : PdaItem, IListable
    {
        public Contact(string firstName, string lastName, string address, string phone) : base(null)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string[] ColumnValues
        {
            get
            {
                return new string[]
                {
                    FirstName,
                    LastName,
                    Phone,
                    Address
                };
            }
        }

        public static string[] Headers
        {
            get
            {
                return new string[]
                {
                    "First Name",
                    "Last Name       ",
                    "Phone         ",
                    "Address                   "
                };
            }
        }
    }

    class Publication : IListable
    {
        public Publication(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public string[] ColumnValues
        {
            get
            {
                return new string[]
                {
                    Title,
                    Author,
                    Year.ToString()
                };
            }
        }

        public static string[] Headers
        {
            get
            {
                return new string[]
                {
                    "Title                     ",
                    "Author        ",
                    "Year"
                };
            }
        }
    }

    class ConsoleListControl
    {
        public static void List(string[] headers, IListable[] items)
        {
            int[] columnWidths = DisplayHeaders(headers);

            for(int count = 0; count < items.Length; count++)
            {
                string[] values = items[count].ColumnValues;
                DisplayItemRow(columnWidths, values);
                System.Console.WriteLine();
            }
        }

        private static int[] DisplayHeaders(string[] headers)
        {
            int[] rtnWidths = new int[headers.Length];

            for (int count = 0; count < headers.Length; count++)
            {
                System.Console.Write(headers[count] + " ");
                rtnWidths[count] = headers[count].Length * 20;                
            }

            System.Console.WriteLine();

            return rtnWidths;
        }

        private static void DisplayItemRow(int[] columnWidths, string[] values)
        {
            for(int count = 0; count < values.Length; count++)
            {
                System.Console.Write(values[count] + " ");
            }            
        }
    }
}
