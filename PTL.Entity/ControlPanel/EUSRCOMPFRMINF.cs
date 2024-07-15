using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTL.Entity.ControlPanel
{
    public class EUSRCOMPFRMINF
    {
        public string COMCOD { get; set; }
        public string FRMGRP { get; set; }
        public string FRMID { get; set; }
        public string FRMNAME { get; set; }
        public string PAREA { get; set; }
        public string PCONTROLLER { get; set; }
        public string PACTION { get; set; }
        public string QRYTYPE { get; set; }
        public bool CHKPER { get; set; } = false;
        public bool DEFAULTPER { get; set; } = false;
    }
}
