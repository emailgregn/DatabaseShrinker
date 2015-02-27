/**
* Copyright (c) 2015 Greg Nicol
* This file is part of DataTransferGUI.
* 
* DataTransferGUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
* 
* DataTransferGUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License along with DataTransferGUI.  If not, see <http://www.gnu.org/licenses/>.
*
*/
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
