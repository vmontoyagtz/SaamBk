using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SaamApp.Maui.Client
{
    public class SfChipGroupViewModel : INotifyPropertyChanged
    {
        private string result = "";
        public Command ActionCommand { get; set; }

        public string Result { get { return result; } set { result = value; OnPropertyChanged(nameof(Result)); }  }

        void Display(object obj)
        {
            if (obj is SfChipGroupModel chip)
            {
                this.Result = chip.Name;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<SfChipGroupModel> students;

        public ObservableCollection<SfChipGroupModel> Students

        {

            get
            {
                return students;
            }

            set
            {
                students = value;
                OnPropertyChanged();

            }

        }



        public SfChipGroupViewModel()
        {

            Students = new ObservableCollection<SfChipGroupModel>();



            Students.Add(new SfChipGroupModel() { Name = "Linda", Image = "avatar1.png" });

            Students.Add(new SfChipGroupModel() { Name = "Rose", Image = "avatar2.png" });

            Students.Add(new SfChipGroupModel() { Name = "Mark", Image = "avatar3.png" });

             ActionCommand = new Command(Display);

        }



        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
