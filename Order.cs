using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seventh_Heaven
{
    internal class Order
    {
        
       public enum enOrderMode { Empty=1,NotEmpty=2};
        public int _NumberOfOrder { get; set; }
        public float _Price { get; set; }
        public string _DateTime { get; set; }  
        public string GetFormatedDateTime()
        {
            return DateTime.Now.ToString();
        }
        public Order(int NumberOfOrder,float Price,string dateTime)
        {
           _NumberOfOrder=NumberOfOrder;
            _Price = Price;
            
            _DateTime = dateTime;
        }
        public Order()
        {
            _NumberOfOrder = 0;
            _Price = 0;
        }
        public bool IsEmpty()
        {
            return ( _Price == 0);
        }

       

        

    }
}
