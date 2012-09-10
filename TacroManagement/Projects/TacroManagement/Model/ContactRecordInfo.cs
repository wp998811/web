using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ContactRecordInfo
    {
        private int id;
        private int contactID;
        private int userID;
        private string recordDetail;
        private string recordTime;

        public ContactRecordInfo()
        {
        }

        public ContactRecordInfo(int contactID, string recordDetail, string recordTime, int userID)
        {
            this.contactID = contactID;
            this.userID = userID;
            this.recordDetail = recordDetail;
            this.recordTime = recordTime;
        }

        public ContactRecordInfo(int id, int contactID, string recordDetail, string recordTime, int userID)
        {
            this.id = id;
            this.contactID = contactID;
            this.userID = userID;
            this.recordDetail = recordDetail;
            this.recordTime = recordTime;
        }

        public int ID
        {
            get { return id; }
        }

        public int ContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string RecordDetail
        {
            get { return recordDetail; }
            set { recordDetail = value; }
        }

        public string RecordTime
        {
            get { return recordTime; }
            set { recordTime = value; }
        }

    }
}