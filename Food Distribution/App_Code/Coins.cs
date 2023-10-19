using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Coins
/// </summary>
public class Coins
{
        public double num;
        public string name;


        public Coins()
        {
            this.num = 0;
            this.name = "ILS";
        }
        public Coins(double num, string name)
        {
            this.num = num;
            this.name = name;
        }

        public double getNum()
        {
            return num;
        }

        public string getName()
        {
            return name;
        }

        public void setNum(double num)
        {
            this.num = num;
        }

        public void setName(string name)
        {
            this.name = name;
        }

    
}