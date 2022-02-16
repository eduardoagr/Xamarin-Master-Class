
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

        [OnChangedMethod(nameof(Changed))]
        public string Name { get; set; }

        [OnChangedMethod(nameof(Changed))]
        public float Ammount { get; set; }

        [OnChangedMethod(nameof(Changed))]
        [MaxLength(25)]
        public string Description { get; set; }

        [OnChangedMethod(nameof(Changed))]
        public DateTime Date { get; set; }

        [OnChangedMethod(nameof(Changed))]
        public string Catergory { get; set; }

        public Exenpse() { }

        public Action OnChanged { get; set; }

        private void Changed() {
            OnChanged.Invoke();
        }
    }
}
