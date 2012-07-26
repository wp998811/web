using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class ProjectDocInfo
    {
        private int projDocId;
        private int taskId;
        private int projDocCate;
        private string docName;
        private string docKey;
        private string docDescription;
        private string docUrl;
        private int docPermission;
        private string uploadTime;
        private int uploadUserId;

        public ProjectDocInfo()
        {

        }

        public ProjectDocInfo(int taskId, int projDocCate, string docName, string docKey, string docDescription
            , string docUrl, int docPermission, string uploadTime, string uploadUserId)
        {
            this.taskId = taskId;
            this.projDocCate = projDocCate;
            this.docName = docName;
            this.docKey = docKey;
            this.docDescription = docDescription;
            this.docUrl = docUrl;
            this.docPermission = docPermission;
            this.uploadTime = uploadTime;
            this.uploadUserId = uploadUserId;
        }

        public ProjectDocInfo(int projDocId, int taskId, int projDocCate, string docName, string docKey, string docDescription
            , string docUrl, int docPermission, string uploadTime, string uploadUserId)
        {
            this.projDocId = projDocId;
            this.taskId = taskId;
            this.projDocCate = projDocCate;
            this.docName = docName;
            this.docKey = docKey;
            this.docDescription = docDescription;
            this.docUrl = docUrl;
            this.docPermission = docPermission;
            this.uploadTime = uploadTime;
            this.uploadUserId = uploadUserId;
        }

        public int UploadUserId
        {
            get { return uploadUserId; }
            set { uploadUserId = value; }
        }

        public string UploadTime
        {
            get { return uploadTime; }
            set { uploadTime = value; }
        }

        public int DocPermission
        {
            get { return docPermission; }
            set { docPermission = value; }
        }

        public string DocUrl
        {
            get { return docUrl; }
            set { docUrl = value; }
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

        public string DocName
        {
            get { return docName; }
            set { docName = value; }
        }

        public int ProjDocCate
        {
            get { return projDocCate; }
            set { projDocCate = value; }
        }

        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        public int ProjDocId
        {
            get { return projDocId; }
            set { projDocId = value; }
        }
    }
}
