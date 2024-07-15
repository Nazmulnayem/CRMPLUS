using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTL.Entity.Auth
{
    public class EUserLoginInformation
    {
        public class UserInfo
        {
            public string comcod { get; set; }
            public string usrid { get; set; }
            public string usrsname { get; set; }
            public string usrname { get; set; }
            public string usrdesig { get; set; }
            public string usrpass { get; set; }
            public string moduleid2 { get; set; }
            public string modulename { get; set; }
            public string compsms { get; set; }
            public string logstatus { get; set; }
            public string ssl { get; set; }
            public string deptcode { get; set; }
            public string userrole { get; set; }
            public string eventspanel { get; set; }
            public string opndate { get; set; }
            public string usrrmrk { get; set; }
            public string empid { get; set; }
            public string teamid { get; set; }
            public string permission { get; set; }
            public string compmail { get; set; }
            public string IMGURL { get; set; }
            public string ddldesc { get; set; }
            public string dptdesc { get; set; }
            public string comunpost { get; set; }
            public string homeurl { get; set; }
            public string portnum { get; set; }
            public string invtype { get; set; }
            public string mrfname { get; set; }
            public string iscalpv { get; set; }
            public string nsheetpv { get; set; }
            public string nsheetfy { get; set; }
            public string ty_jantodec { get; set; }
            public string isnsheetsfrmbking { get; set; }
            public string iscrmtdwise { get; set; }
            public string isnotific { get; set; }
            public string isdepdet { get; set; }
            public string issynwithfup { get; set; }
        }

        public class UserPagePerm
        {
            public string rowid { get; set; }
            public string comcod { get; set; }
            public string usrid { get; set; }
            public string frmid { get; set; }
            public string frmname { get; set; }
            public string qrytype { get; set; }
            public string entry { get; set; }
            public string printable { get; set; }
            public string delete { get; set; }
            public string dscrption { get; set; }
            public string urlinf { get; set; }
            public string @interface { get; set; }
            public string floc { get; set; }
            public string qrytype1 { get; set; }
        }

        public class UserImg
        {
            public string usrimg { get; set; }
        }

        public class UserMenuList
        {
            public string comcod { get; set; }
            public string usrid { get; set; }
            public string formid { get; set; }
        }

        public class UserUrl
        {
            public string url { get; set; }
            public string parea { get; set; }
            public string pcont { get; set; }
            public string paction { get; set; }
        }

        public class UserSisterCompany
        {
            public string comcod { get; set; }
            public string mcomcod { get; set; }
            public string scomcod { get; set; }
        }

        public class UserMenuPerm
        {
            public string rowid { get; set; }
            public string menuid { get; set; }
            public string frmid { get; set; }
            public string title { get; set; }
            public string url { get; set; }
            public string urlinf { get; set; }
            public string floc { get; set; }
            public string frmname { get; set; }
            public string qrytype { get; set; }
            public string qrytype1 { get; set; }
            public string parentmenuid { get; set; }
            public string description { get; set; }
            public string cssfont { get; set; }
            public string usrid { get; set; }
            public string ordeby { get; set; }
            public string menustatus { get; set; }
            public string perorder { get; set; }
            public string entry { get; set; }
            public string printable { get; set; }
            public string perdelete { get; set; }
            public string moduleid { get; set; }
            public string @interface { get; set; }
            public string sidebar { get; set; }
            public string menutype { get; set; }
        }

    }
}