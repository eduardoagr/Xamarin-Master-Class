
using SQLite;

using System;
using System.Collections.Generic;

namespace Budget.Model {

    public class Exenpse {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public float Ammount { get; set; }

        [MaxLength(25)]
        public string Descriion { get; set; }

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
    }
}
