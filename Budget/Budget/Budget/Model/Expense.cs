
using PropertyChanged;

using SQLite;

using System;

namespace Budget.Model {

    [AddINotifyPropertyChangedInterface]
    public class Expense {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public float Ammount { get; set; }

        [MaxLength(25)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Catergory { get; set; }

        public Expense() { }
    }
}
