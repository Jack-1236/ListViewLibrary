using System.Windows.Forms;


namespace ListViewLibrary.Controller;

public class ListViewColumns : BaseINotifyProperty
{
    private string text;
    private int width;
    private HorizontalAlignment textAlign;

    public string Text
    {
        get => text;
        set
        {
            text = value;
            OnPropertyChanged("Text");
        }
    }

    public int Width
    {
        get => width;
        set
        {
            width = value;
            OnPropertyChanged("Width");
        }
    }

    public HorizontalAlignment TextAlign
    {
        get => textAlign;
        set
        {
            textAlign = value;
            OnPropertyChanged("TextAlign");
        }
    }
}