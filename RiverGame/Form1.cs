using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiverGame
{
    public partial class Form1 : Form
    {
        private List<String> _rightList;
        private List<String> _leftList;
        bool farmer = true;
        public Form1()
        {
            InitializeComponent();
            CreateList();
            SetListBoxDataSource();
            ChangeData();
            listBox1.BackColor = Color.Red;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (farmer)
            {
               if (listBox1.SelectedItem != null)
               {
                    string item = (string)listBox1.SelectedItem;
                    _leftList.Remove(item);
                    _rightList.Add(item);
                    ChangeData();
                    listBox2.BackColor = Color.Red;
                    listBox1.BackColor = Color.White;
                    farmer = false;
                    WinLose();
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
               else
                {
                    listBox2.BackColor = Color.Red;
                    listBox1.BackColor = Color.White;
                    farmer = false;
                    WinLose();
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
            }
            else
            {
                   MessageBox.Show("farmer is not here");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!farmer)
            {
                if (listBox2.SelectedItem != null)
                {
                    string item = (string)listBox2.SelectedItem;
                    _leftList.Add(item);
                    _rightList.Remove(item);
                    ChangeData();
                    listBox1.BackColor = Color.Red;
                    listBox2.BackColor = Color.White;
                    farmer = true;
                    WinLose();
                    button1.Enabled = true;
                    button2.Enabled = false;
                }
                else
                {
                    listBox1.BackColor = Color.Red;
                    listBox2.BackColor = Color.White;
                    farmer = true;
                    WinLose();
                    button1.Enabled = true;
                    button2.Enabled = false;
                }    
            }
            else
            {
                MessageBox.Show("farmer is not here");
            } 
        }
        private void CreateList()
        {
            _leftList = new List<string> { "狼", "羊", "菜"};
            _rightList = new List<string>();
            
        }
        private void SetListBoxDataSource()
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
        }
        private void ChangeData()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
            listBox1.SelectedItem = null;
            listBox2.SelectedItem = null;
        }
        private void WinLose()
        {
            if ((_leftList.Contains("狼") && _leftList.Contains("羊"))&&!farmer || (_leftList.Contains("菜") && _leftList.Contains("羊"))&&!farmer)
            {
                MessageBox.Show("game over");
            }
            else if ((_rightList.Contains("狼") && _rightList.Contains("羊"))&&farmer || (_rightList.Contains("菜") && _rightList.Contains("羊"))&& farmer)
            {
                MessageBox.Show("game over");
            }
            else if (_rightList.Contains("狼")&& _rightList.Contains("羊")&& _rightList.Contains("菜"))
            {
                MessageBox.Show("Win");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Farmer Color is Red");
        }
    }
}
