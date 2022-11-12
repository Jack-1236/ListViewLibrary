using System.Windows.Forms;


namespace ListViewLibrary.Controller
{
    public class ListViewAttributes : BaseINotifyProperty
    {
        
        private View _view = View.Details;
        private bool labelEdit = false;
        private bool fullColoumnReorder = true;
        private bool allowColumnReorder = true;
        private bool checkBoxes = false;
        private bool fullRowSelect = true;
        private bool gridLines = true;
        private SortOrder sorting = SortOrder.None;
       
        
        public View View
        {
            get => _view;
            set
            {
                if (value == _view) return;
                _view = value;
                OnPropertyChanged("View");
            }
        }

        public bool LabelEdit
        {
            get => labelEdit;
            set
            {
                if (value == labelEdit) return;
                labelEdit = value;
                OnPropertyChanged("LabelEdit");
            }
        }

        public bool FullColoumnReorder
        {
            get => fullColoumnReorder;
            set
            {
                if (value == fullColoumnReorder) return;
                fullColoumnReorder = value;
                OnPropertyChanged("FullColoumnReorder");
            }
        }

        public bool AllowColumnReorder
        {
            get => allowColumnReorder;
            set
            {
                if (value == allowColumnReorder) return;
                allowColumnReorder = value;
                OnPropertyChanged("AllowColumnReorder");
            }
        }

        public bool CheckBoxes
        {
            get => checkBoxes;
            set
            {
                if (value == checkBoxes) return;
                checkBoxes = value;
                OnPropertyChanged("CheckBoxes");
            }
        }

        public bool FullRowSelect
        {
            get => fullRowSelect;
            set
            {
                if (value == fullRowSelect) return;
                fullRowSelect = value;
                OnPropertyChanged("FullRowSelect");
            }
        }

        public bool GridLines
        {
            get => gridLines;
            set
            {
                if (value == gridLines) return;
                gridLines = value;
                OnPropertyChanged("GridLines");
            }
        }

        public SortOrder Sorting
        {
            get => sorting;
            set
            {
                if (value == sorting) return;
                sorting = value;
                OnPropertyChanged("Sorting");
            }
        }

       
        

    }
}