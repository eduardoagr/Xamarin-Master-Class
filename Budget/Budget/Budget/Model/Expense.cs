
using PropertyChanged;

using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Model {

    [AddINotifyPropertyChangedInterface]
    public class Exenpse {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public float Ammount { get; set; }

        [MaxLength(25)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Catergory { get; set; }

        public Exenpse() { }

        public static int InsertExpense(Exenpse exenpse) {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatbasePath)) {

                conn.CreateTable<Exenpse>();
                return conn.Insert(exenpse);
            }
        }

        public static List<Exenpse> GetExpenses() {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatbasePath)) {

                conn.CreateTable<Exenpse>();
                return conn.Table<Exenpse>().ToList();
            }
        }

        public static float TotalExpenseAmmount() {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatbasePath)) {

                conn.CreateTable<Exenpse>();
                return conn.Table<Exenpse>().ToList().Sum(e => e.Ammount);
            }
        }


        public static List<Exenpse> GetExpenses(string Category) {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatbasePath)) {

                conn.CreateTable<Exenpse>();
                return conn.Table<Exenpse>().Where(e => e.Catergory == Category).ToList();
            }
        }
    }
}
