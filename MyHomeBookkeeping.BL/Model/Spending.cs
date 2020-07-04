using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomeBookkeeping.BL.Model
{
    [Serializable]
    public class Spending : Action
    {
        public Spending(string name,
                        double amount,
                        string category,
                        string comment) :
        base(name, amount, category, comment)
        {
        }
    }
}
