using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ProjDocUserInfo
    {
        private int id;
        private int projDocId;
        private int userId;

        public ProjDocUserInfo()
        {

        }

        public ProjDocUserInfo(int projDocId, int userId)
        {
            this.projDocId = projDocId;
            this.userId = userId;
        }

        public ProjDocUserInfo(int id, int projDocId, int userId)
        {
            this.id = id;
            this.projDocId = projDocId;
            this.userId = userId;
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public int ProjDocId
        {
            get { return projDocId; }
            set { projDocId = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
