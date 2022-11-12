using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListViewLibrary.Controller;

namespace ListViewLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var created = new ListViewCreated(listView1);

            created.AddColumns(new List<ListViewColumns>()
            {
                new ListViewColumns() { Text = "测试", Width = 110, TextAlign = HorizontalAlignment.Center },
                new ListViewColumns() { Text = "Test", Width = 110, TextAlign = HorizontalAlignment.Center },
                new ListViewColumns() { Text = "sdad", Width = 45, TextAlign = HorizontalAlignment.Center }
            });
            created.AddItem(new ListViewItem("88")
            {
                SubItems = { "56565", "789+7897", "2123123123" }
            }); 
            created.ListView_ItemChecked += delegate(object o, int i)
            {
                MessageBox.Show("测试" + i);
            };
            
            created.Created();
            created.Attributes.CheckBoxes = true;
            
          created.ListView_SelectIndexClick+= delegate(object o, int i)
          {
              MessageBox.Show("选中成功");
              

          }; 
        }
    }
}