using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seventh_Heaven
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            
        }
        private Order ConvertLineToObject(string Line)
        {
            string[] LineOrder = Line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            return new Order(Convert.ToInt32(LineOrder[0]),Convert.ToSingle(LineOrder[1]), LineOrder[2]);

        }
       
        string[] sep = new string[1];
        private void UserControl1_Load(object sender, EventArgs e)
        {
            Order order = new Order();  
            sep[0] = "/##/";
            StreamReader reader = new StreamReader("C:\\Users\\User\\OneDrive\\المستندات\\OrdersByDetails.txt");
            string line;
           
            while( (line =reader.ReadLine())!=null)
                    {
                order=ConvertLineToObject(line);
                ListViewItem Item = new ListViewItem(order._NumberOfOrder.ToString());
                Item.SubItems.Add(order._Price.ToString());
                Item.SubItems.Add(order._DateTime.ToString());
                listView1.Items.Add(Item);

            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
