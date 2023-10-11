using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Seventh_Heaven
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            sep[0] = "/##/";



        }
        
        private Order ConvertLineToObject(string Line)
        {
            string[] LineOrder= Line.Split(sep,StringSplitOptions.RemoveEmptyEntries);
            return new Order(Convert.ToInt32(Line[0]), Convert.ToSingle(Line[1]), Convert.ToString(Line[2]));
          
        }
        private string ConvertObjectToLine(Order order)
        {
            
            string Line = order._NumberOfOrder.ToString() + sep[0];
            Line += order._Price.ToString() + sep[0];
            Line += order._DateTime; 
            return Line;
        }

        string[] sep = new string[1];

        
        float  MeatPrice = 0;
        float BBQPrice = 0;
        float TraysPrice = 0;
        float PastriesPrice = 0;
        float ManaqeshPrice = 0;
        float TotalPrice = 0;
        string MeatOrderDetails;
        string BBQOrderDetails;
        string TraysOrderDetails;
        string PastriesOrderDetails;
        string ManaqeshOrderDetails;
        int NumberOfOrder=0;
        Order order = new Order();
        
        private void CalculateTotalPrice()
        {
            order._Price = MeatPrice + PastriesPrice + ManaqeshPrice + TraysPrice + BBQPrice;
            lbTotalPrice.Text = order._Price.ToString();
            
              
            
           
          
           
        }
        private void TotalOrderDetails()
        {
            lbTotalOrderDetails.Text = " : تفاصيل الطلب";
            lbTotalOrderDetails.Text += BBQOrderDetails + PastriesOrderDetails + ManaqeshOrderDetails + MeatOrderDetails + TraysOrderDetails;
            
        }
        private void CalculateManaqeshPrice(MaskedTextBox tbox,string kindOfManaqesh="000")
        {

            if (tbox.Text != "")
            {
                ManaqeshPrice += Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag);
                ManaqeshOrderDetails += "\n" + "العدد : " + tbox.Text + kindOfManaqesh+ (Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag)).ToString();
                
            }
           
            lbManaqeshPrice.Text = ManaqeshPrice.ToString();

        }
        private void CalculateTraysPrice(MaskedTextBox tbox,string KindOfTrays="000")
        {

            if (tbox.Text != " .")
            {
                TraysPrice += Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag);
                TraysOrderDetails += "\n" + "الوزن : " + tbox.Text + KindOfTrays + (Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag)).ToString();
              
            }
          
            lbTraysPrice.Text = TraysPrice.ToString();

        }
        private void CalculatePastriesPrice(MaskedTextBox tbox,string KindOfPastries="000")
        {

            if (tbox.Text != "")
            {
                PastriesPrice += Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag);
                PastriesOrderDetails += "\n" + "العدد : " + tbox.Text + KindOfPastries + (Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag)).ToString();
                
            }
            
            lbPastriesPrice.Text = PastriesPrice.ToString();

        }
        private void CalculateMeatPrice(MaskedTextBox tbox,string KindOfMeat="000")
        {
           
            if (tbox.Text != " .")
            {
                MeatPrice += Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag);
                MeatOrderDetails += "\n" + "الوزن : " + tbox.Text + KindOfMeat + (Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag)).ToString();
            }

            lbMeatPrice.Text = MeatPrice.ToString();

        }
        void CalculateBBQPrice(MaskedTextBox tbox,string KindOfBBQ="000")
        {

            if (tbox.Text != " .")
            {
                BBQPrice += Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag);
                BBQOrderDetails += "\n" + "العدد : " + tbox.Text + KindOfBBQ + (Convert.ToSingle(tbox.Text) * Convert.ToSingle(tbox.Tag)).ToString();

               
            }
            
            lbBBQPrice.Text = BBQPrice.ToString();

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            
            CalculateMeatPrice(tbLocalMeat, " لحم بلدي : ");
            CalculateMeatPrice(tbLocalMeatWithBond, " لحم بلدي بعضمه : ");
            CalculateMeatPrice(tbLocalBurgerMeat, " برجر لحم بلدي : ");
            CalculateMeatPrice(tbImportedBeef, " لحم عجل مستورد : ");
            CalculateMeatPrice(tbChickenGurger, " برجر دجاج : ");
            lbTotalOrderDetails.Text += MeatOrderDetails;
            btnAddMeatOrder.Enabled = false;
            CalculateTotalPrice();
           


        }

        private void tbLocalBurgerMeat_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MeatOrderDetails = "";
            MeatPrice = 0;
            lbMeatPrice.Text =  MeatPrice.ToString();
            tbChickenGurger.Text = " .";
            tbImportedBeef.Text = " .";
            tbLocalBurgerMeat.Text = " .";
            tbLocalMeat.Text = " .";
            tbLocalMeatWithBond.Text = " .";
            CalculateMeatPrice(tbLocalMeat);
            CalculateMeatPrice(tbLocalMeatWithBond);
            CalculateMeatPrice(tbLocalBurgerMeat);
            CalculateMeatPrice(tbImportedBeef);
            CalculateMeatPrice(tbChickenGurger);
            TotalOrderDetails();
            CalculateTotalPrice();
            btnAddMeatOrder.Enabled = true;
        }

       
        

        private void button4_Click(object sender, EventArgs e)
        {
            CalculateBBQPrice(tbBBQCheckenSheesh, " مشاوي شيش : ");
            CalculateBBQPrice(tbBBQChickenBBQ, " مشاوي دجاج عالفحم : ");
            CalculateBBQPrice(tbBBQmixBBQ, " مشاوي مشكل : ");
            CalculateBBQPrice(tbBBQribs, " مشاوي ريش : ");
            CalculateBBQPrice(tbBBQCubeLocalMeat, " مشاوي شقف : ");
            CalculateBBQPrice(tbBBQKabab, " مشاوي كباب : ");
            lbTotalOrderDetails.Text += BBQOrderDetails;
            btnAddBBQOrder.Enabled = false;
            CalculateTotalPrice();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbBBQCheckenSheesh.Text = " .";
            tbBBQChickenBBQ.Text = " .";
            tbBBQCubeLocalMeat.Text = " .";
            tbBBQKabab.Text = " .";
            tbBBQmixBBQ.Text = " .";
            tbBBQribs.Text = " .";
            lbBBQPrice.Text = "0";
            BBQPrice = 0;
            btnAddBBQOrder.Enabled = true;
            CalculateBBQPrice(tbBBQCheckenSheesh);
            CalculateBBQPrice(tbBBQChickenBBQ);
            CalculateBBQPrice(tbBBQmixBBQ);
            CalculateBBQPrice(tbBBQribs);
            CalculateBBQPrice(tbBBQCubeLocalMeat);
            CalculateBBQPrice(tbBBQKabab);
            BBQOrderDetails = "";
            TotalOrderDetails();
            CalculateTotalPrice();
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
       
        private void button4_Click_1(object sender, EventArgs e)
        {
            CalculateTraysPrice(tbTrayMeatInTray, " صينية قلاية لحمة : ");
            CalculateTraysPrice(tbTraysIndianKabab, " صينية كباب هندي : ");
            CalculateTraysPrice(tbTraysKoftahThenih, " صينية كفتة بطحينية : ");
            CalculateTraysPrice(tbTraysKoftaWithTomato, " صينية كفتة ببندورة : ");
            CalculateTraysPrice(tbTraysLambSpleen, " صينية معلاق : ");
            CalculateTraysPrice(tbTraysSheesh, " صينية شيش : ");
            CalculateTraysPrice(tbTraysSteakWithMashrom, " صينية شرحات مطفاي : ");
            lbTotalOrderDetails.Text += TraysOrderDetails;
            btnAddTraysOrder.Enabled = false;
            CalculateTotalPrice();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btnAddTraysOrder.Enabled = true;
            lbTraysPrice.Text = "0";
            TraysPrice = 0;
            tbTrayMeatInTray.Text= " ."; 
            tbTraysIndianKabab.Text= " .";
            tbTraysKoftahThenih.Text= " .";
            tbTraysKoftaWithTomato.Text= " .";
            tbTraysLambSpleen.Text= " ."; 
            tbTraysSheesh.Text= " .";
            tbTraysSteakWithMashrom.Text= " .";
            CalculateTraysPrice(tbTrayMeatInTray);
            CalculateTraysPrice(tbTraysIndianKabab);
            CalculateTraysPrice(tbTraysKoftahThenih);
            CalculateTraysPrice(tbTraysKoftaWithTomato);
            CalculateTraysPrice(tbTraysLambSpleen);
            CalculateTraysPrice(tbTraysSheesh);
            CalculateTraysPrice(tbTraysSteakWithMashrom);
            TraysOrderDetails = "";
            TotalOrderDetails();
            CalculateTotalPrice();
        }

        private void maskedTextBox6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CalculatePastriesPrice(tbPastriesHotdog," نقانق : ");
            CalculatePastriesPrice(tbPastriesMinPizaa," بيتزا : ");
            CalculatePastriesPrice(tbPastriesPotato," معجنات بطاطا : ");
            CalculatePastriesPrice(tbPastriesSaniorWithCheese," معجنات سنيورة مع جبنة :  ");
            CalculatePastriesPrice(tbPastriesSausage," معجنات سجق : ");
            CalculatePastriesPrice(tbPastriesSpinach," معجنات سبانخ : ");
            CalculatePastriesPrice(tbPastriesYellowCheese," معجنات جبنة صفرا : ");

            lbTotalOrderDetails.Text += PastriesOrderDetails;
            btnAddPastriesOrder.Enabled = false;
            CalculateTotalPrice();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            lbPastriesPrice.Text = "0";
            PastriesPrice = 0;
            tbPastriesHotdog.Text = "";
            tbPastriesMinPizaa.Text = "";
            tbPastriesPotato.Text = ""; ;
            tbPastriesSaniorWithCheese.Text = ""; ;
            tbPastriesSausage.Text = "";
            tbPastriesSpinach.Text = "";
            tbPastriesYellowCheese.Text = "";
            btnAddPastriesOrder.Enabled = true;
            CalculatePastriesPrice(tbPastriesHotdog);
            CalculatePastriesPrice(tbPastriesMinPizaa);
            CalculatePastriesPrice(tbPastriesPotato);
            CalculatePastriesPrice(tbPastriesSaniorWithCheese );
            CalculatePastriesPrice(tbPastriesSausage);
            CalculatePastriesPrice(tbPastriesSpinach);
            CalculatePastriesPrice(tbPastriesYellowCheese);
            PastriesOrderDetails = "";
            TotalOrderDetails();
            CalculateTotalPrice();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CalculateManaqeshPrice(tbManaqeshArais,"عرايس : ");
            CalculateManaqeshPrice(tbManaqeshEgs," مناقيش بيض : ");
            CalculateManaqeshPrice(tbManaqeshMuhammara," مناقيش محمرة : ");
            CalculateManaqeshPrice(tbManaqeshSalamiWirhChesse," سلامي مع قشقوان : ");
            CalculateManaqeshPrice(tbManaqeshSaousageWithCheese," توشكا  : ");
            CalculateManaqeshPrice(tbManaqeshSausage," سجق : ");
            CalculateManaqeshPrice(tbManaqeshSenioraWithChese," مناقيش سنيورة وجبنة : ");
            CalculateManaqeshPrice(tbManaqeshSheeshWithCheese," مناقيش شيش مع جبنة : ");
            CalculateManaqeshPrice(tbManaqeshThyme," مناقيش زعتر : ");
            CalculateManaqeshPrice(tbManaqeshThymeWithChesse," مناقيش جبنة وزعتر : ");
            CalculateManaqeshPrice(tbManaqeshTurkeyWithChesse," مناقيشت يركي مع جبنة : ");
            CalculateManaqeshPrice(tbManaqeshWhiteCheese," مناقيش جبنة بيضاء : ");
            CalculateManaqeshPrice(tbMAnaqeshSheesh," مناقيش شيش ساده : ");
            lbTotalOrderDetails.Text += ManaqeshOrderDetails;
            btnAddManaqeshOrder.Enabled = false;
            CalculateTotalPrice();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            lbManaqeshPrice.Text = "0";
            ManaqeshPrice = 0;
            btnAddManaqeshOrder.Enabled=true;

            tbManaqeshArais.Text = "";
            tbManaqeshEgs.Text = "";
            tbManaqeshMuhammara.Text = "";
            tbManaqeshSalamiWirhChesse.Text = "";
            tbManaqeshSaousageWithCheese.Text = "";
            tbManaqeshSausage.Text = "";
            tbManaqeshSenioraWithChese.Text = "";
            tbManaqeshSheeshWithCheese.Text = "";
            tbManaqeshThyme.Text = "";
            tbManaqeshThymeWithChesse.Text = "";
            tbManaqeshTurkeyWithChesse.Text = "";
            tbManaqeshWhiteCheese.Text = "";
            CalculateManaqeshPrice(tbManaqeshArais);
            CalculateManaqeshPrice(tbManaqeshEgs);
            CalculateManaqeshPrice(tbManaqeshMuhammara);
            CalculateManaqeshPrice(tbManaqeshSalamiWirhChesse);
            CalculateManaqeshPrice(tbManaqeshSaousageWithCheese);
            CalculateManaqeshPrice(tbManaqeshSausage);
            CalculateManaqeshPrice(tbManaqeshSenioraWithChese);
            CalculateManaqeshPrice(tbManaqeshSheeshWithCheese);
            CalculateManaqeshPrice(tbManaqeshThyme);
            CalculateManaqeshPrice(tbManaqeshThymeWithChesse);
            CalculateManaqeshPrice(tbManaqeshTurkeyWithChesse);
            CalculateManaqeshPrice(tbManaqeshWhiteCheese);
            CalculateManaqeshPrice(tbMAnaqeshSheesh);
            ManaqeshOrderDetails = "";
            TotalOrderDetails();
            CalculateTotalPrice();

        }
       
        private void AddOrder()
        {
            StreamWriter OrdersByDetails = new StreamWriter("C:\\Users\\User\\OneDrive\\المستندات\\OrdersByDetails.txt", true);
            order._NumberOfOrder = ++NumberOfOrder;
            DateTime date = DateTime.Now;
            order._DateTime = DateTime.Now.ToString();
            string Line = ConvertObjectToLine(order);
            if (!order.IsEmpty())
            {


                OrdersByDetails.WriteLine(Line);



                OrdersByDetails.Close();


            }
            OrdersByDetails.Close();
        }
        private void button6_Click_1(object sender, EventArgs e)
        {

            AddOrder();
        Form1 form=new Form1();
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OrdersMenuForm OrdersListView = new OrdersMenuForm();
            OrdersListView.Show();
        }
    }
}
