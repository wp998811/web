using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DocumentInfo
    {

        private int docID;
        private string docName;
        private string docVersion;
        private string docDescription;        
        private string docKey;
        private int departID;       
        private int docCategoryID;
        private string docState;    
        private string docUrl;
        private int docPermission;
        private int uploadUserID;
        private string uploadTime;


         public DocumentInfo()
        {
        }

        public DocumentInfo(int docID, string docName, string docVersion, string docDescription, string docKey, int departID, int docCategoryID, string docState, string docUrl, int docPermission, int uploadUserID, string uploadTime)
        {
            this.docID = docID;
            this.docName = docName;
            this.docVersion = docVersion;
            this.docDescription = docDescription;
            this.docKey = docKey;
            this.departID = departID;
            this.docCategoryID = docCategoryID;
            this.docState = docState;
            this.docUrl = docUrl;
            this.docPermission = docPermission;
            this.uploadUserID = uploadUserID;
            this.uploadTime = uploadTime;
        }

        public int DocID
        {
            get { return docID; }
            set { docID = value; }
        }
      
        public string DocName
        {
            get { return docName; }
            set { docName = value; }
        }
        
        public string DocVersion
        {
            get { return docVersion; }
            set { docVersion = value; }
        }
       
        public string DocDescription
        {
            get { return docDescription; }
            set { docDescription = value; }
        }
        

        public string DocKey
        {
            get { return docKey; }
            set { docKey = value; }
        }
       

        public int DepartID
        {
            get { return departID; }
            set { departID = value; }
        }
       

        public int DocCategoryID
        {
            get { return docCategoryID; }
            set { docCategoryID = value; }
        }
      

        public string DocState
        {
            get { return docState; }
            set { docState = value; }
        }
     

        public string DocUrl
        {
            get { return docUrl; }
            set { docUrl = value; }
        }
        

        public int DocPermission
        {
            get { return docPermission; }
            set { docPermission = value; }
        }

        public int UploadUserID
        {
            get { return uploadUserID; }
            set { uploadUserID = value; }
        }
    

        public string UploadTime
        {
            get { return uploadTime; }
            set { uploadTime = value; }
        }

       

       
    }
}
