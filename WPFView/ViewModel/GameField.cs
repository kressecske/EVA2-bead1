using Labyrinth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFView.ViewModel
{
    public class GameField : ViewModelBase
    {
        private FieldType _type;
        private Boolean _visibility;


        public Boolean Visibile
        {
            get { return _visibility; }
            set
            {
                if (_visibility != value)
                {
                    _visibility = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Felirat lekérdezése, vagy beállítása.
        /// </summary>
        public FieldType Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Vízszintes koordináta lekérdezése, vagy beállítása.
        /// </summary>
        public Int32 X { get; set; }

        /// <summary>
        /// Függőleges koordináta lekérdezése, vagy beállítása.
        /// </summary>
        public Int32 Y { get; set; }

        /// <summary>
        /// Sorszám lekérdezése.
        /// </summary>
        //public Int32 Number { get; set; }

    }
}
