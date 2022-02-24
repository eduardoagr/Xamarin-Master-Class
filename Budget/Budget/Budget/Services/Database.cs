using Budget.Model;

using SQLite;

using System.Collections.Generic;
using System.Linq;

namespace Budget.Services {

    public class Database {

        public static int InsertExpense(Expense exenpse) {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatbasePath)) {

                conn.CreateTable<Expense>();
                return conn.Insert(exenpse);
            }
        }

        public static List<Expense> GetExpenses() {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatbasePath)) {

                conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList();
            }
        }

        public static float TotalExpenseAmmount() {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatbasePath)) {

                conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList().Sum(e => e.Ammount);
            }
        }

        public static List<Expense> GetExpenses(string Category) {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatbasePath)) {

                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Where(e => e.Catergory == Category).ToList();
            }
        }
    }
}
