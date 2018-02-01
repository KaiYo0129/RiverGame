using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListSample
{
    public partial class Form1 : Form
    {
        private List<MyRectangle> _list;
        public Form1()
        {
            InitializeComponent();
            CreateList();
            SetCombobox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ComboBox theComboBox = (ComboBox)sender;
            int index = theComboBox.SelectedIndex;
            MyRectangle item = _list[index];
            MessageBox.Show("取得索引 " + index.ToString() + " 的面積為: " + item.Area.ToString());
        }

        private void CreateList()
        {
            _list = new List<MyRectangle>();
            _list.Add(new MyRectangle { Name = "A", Width = 5, Height = 5 });
            _list.Add(new MyRectangle { Name = "B", Width = 10, Height = 10 });
            _list.Add(new MyRectangle { Name = "C", Width = 20, Height = 20 });
            _list.Add(new MyRectangle { Name = "D", Width = 100, Height = 100 });
        }
        private void SetCombobox()
        {
            comboBox1.DataSource = _list;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Area";
        }
    }
}
