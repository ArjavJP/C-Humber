using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10
{
    public class InventoryDB
    {
        private const string Path = @"D:\Humber\grocery_inventory_items.txt";
        private const string Delimiter = "|";

        public static List<Inventroy> GetItems()
        {
            List<Inventroy> items = new List<Inventroy>();


            using (StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                string row;
                while ((row = textIn.ReadLine()) != null)
                {
                    string[] columns = row.Split(Delimiter);


                    if (columns.Length == 3)
                    {
                        Inventroy item = new Inventroy
                        {
                            ItemNo = Convert.ToInt32(columns[0]),
                            Description = columns[1],
                            Price = Convert.ToDecimal(columns[2])
                        };
                        items.Add(item);
                    }
                }
            }
            return items;
        }
        public static void SaveItems(List<Inventroy> items)
        {
            using (StreamWriter textOut = new StreamWriter(new FileStream(Path, FileMode.Create, FileAccess.Write)))
            {
                foreach (Inventroy item in items)
                {
                    textOut.Write(item.ItemNo + Delimiter);
                    textOut.Write(item.Description + Delimiter);
                    textOut.WriteLine(item.Price);
                }
            }
        }
    }
}
