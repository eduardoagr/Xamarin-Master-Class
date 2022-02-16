using Budget.Model;

using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Services {
    public class Dataabase {

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
