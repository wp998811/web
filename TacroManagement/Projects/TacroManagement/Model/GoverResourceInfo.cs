using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GoverResourceInfo
    {
        private int goverID;
        private int userID;
        private string goverCity;
        private string organName;
        private string organIntro;

        public GoverResourceInfo()
        {
        }

        public GoverResourceInfo(int goverID, int userID, string goverCity, string organName, string organIntro)
        {
            this.goverID = goverID;
            this.userID = userID;
            this.goverCity = goverCity;
            this.organName = organName;
            this.organIntro = organIntro;
        }

        public string OrganIntro
        {
            get { return organIntro; }
            set { organIntro = value; }
        }

        public string OrganName
        {
            get { return organName; }
            set { organName = value; }
        }


        public string GoverCity
        {
            get { return goverCity; }
            set { goverCity = value; }
        }


        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }


        public int GoverID
        {
            get { return goverID; }
            set { goverID = value; }
        }

    }
}
