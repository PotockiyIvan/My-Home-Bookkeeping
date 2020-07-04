using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomeBookkeeping.BL.Model
{
    [Serializable]
    public class Income : Action
    {
        public Income(string name,
                      double amount,
                      string category,
                      string comment) :
        base(name, amount, category, comment)
        {
        }
       
    }
}
