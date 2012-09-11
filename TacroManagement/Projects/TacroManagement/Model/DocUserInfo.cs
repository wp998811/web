using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DocUserInfo
    {
        private int id;
        private int docID;
        private int userID;

        public DocUserInfo()
        {
        }
        public DocUserInfo(int id, int docID, int UserID)
        {
            this.id = id;
            this.docID = docID;
            this.UserID = UserID;
        }
        public DocUserInfo(int docID, int UserID)
        {
            this.docID = docID;
            this.UserID = UserID;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
        public int DocID
        {
            get { return docID; }
            set { docID = value; }
        }
        
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}
