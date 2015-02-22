using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;

namespace DataTransferGUI
{
    public abstract class CopyPortion
    {
        protected uint number;

        public CopyPortion(uint number)
        {
           this.number = number;
        }
        public abstract uint AsNumRows(long rowcount);
        public abstract uint AsPercentage();

    }



    public class CopyPortionPercentage : CopyPortion
    {
        public CopyPortionPercentage(uint number)
            : base((number > 100 ? 100 : number))
        { 
        }

        public override uint AsNumRows(long rowcount)
        {
            return (uint)(rowcount * this.number / 100 );
        }
        public override uint AsPercentage()
        {
            return this.number;
        }
    }

    // ToDo:
    //public class CopyPortionLog : CopyPortion {
    //    public CopyPortionLog(uint number) :
    //        base(number) { }
    //}
}
