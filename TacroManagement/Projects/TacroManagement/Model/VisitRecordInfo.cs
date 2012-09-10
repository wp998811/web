using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class VisitRecordInfo
    {
        private int id;
        private int contactID;
        private int userID;
        private string visitDetail;
        private string recordTime;

        public VisitRecordInfo()
        {
        }

        public VisitRecordInfo(int contactID, string visitDetail, string recordTime, int userID)
        {
            this.contactID = contactID;
            this.userID = userID;
            this.visitDetail = visitDetail;
            this.recordTime = recordTime;
        }

        public VisitRecordInfo(int id, int contactID, string visitDetail, string recordTime, int userID)
        {
            this.id = id;
            this.contactID = contactID;
            this.userID = userID;
            this.visitDetail = visitDetail;
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

        public string VisitDetail
        {
            get { return visitDetail; }
            set { visitDetail = value; }
        }

        public string RecordTime
        {
            get { return recordTime; }
            set { recordTime = value; }
        }

    }
}