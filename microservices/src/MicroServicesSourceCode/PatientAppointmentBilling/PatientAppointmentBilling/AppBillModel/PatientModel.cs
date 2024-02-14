using System;
using System.Collections.Generic;

namespace AppBillModel
{
    public class Patient // Code first , DB , Add migration
    {
        private List<History> _HistoryProblems { get; set; }
        public List<Address> Addresses { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorName { get; set; }
        public string Address { get; set; }
        public double BillAmount { get; set; }
        public Patient()
        {
            this._HistoryProblems = new List<History>();
        }
        public void AddHistory(string desciption)
        {
            if (desciption.Length == 0)
            {
                throw new Exception("Not allowed desc needed");
            }
            this._HistoryProblems.Add(new History() { Description=desciption } );
        }
    }
    public class History
    {
        public string Description { get; set; }
    }
    public class Address
    {
        public string Address1 { get; set; }
    }
    // value object design pattern
    public class MyMoney
    {
        public decimal Value { get; set; }
        public string Material { get; set; }
        public override bool Equals(object obj)
        {
            MyMoney m1 = (MyMoney)obj;
            if (m1.Value == Value)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(MyMoney money1, MyMoney money2)
        {
            if ((money1.Value != money2.Value))
            {
                return true;
            }
            return false;
        }
        public static bool operator ==(MyMoney money1, MyMoney money2)
        {
            if ((money1.Value == money2.Value))
            {
                return true;
            }
            return false;
        }
    }
    // Value design pattern client code
    //MyMoney m1 = new MyMoney();
    //m1.Value = 1;
    //        m1.Material = "Coin";
    //        Dictionary<MyMoney, MyMoney> diction = new Dictionary<MyMoney, MyMoney>();
    //diction.Add(m1, m1);

    //        MyMoney m2 = new MyMoney();
    //m2.Value = 1;
    //        m2.Material = "Paper";


    //        MyMoney msearch = diction[m2];


}
