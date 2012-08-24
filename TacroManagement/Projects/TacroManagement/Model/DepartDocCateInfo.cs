using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DepartDocCateInfo
    {
        private int id;
        private int departID;
        private int visibility;
        private string categoryName;

        public DepartDocCateInfo()
        {
        }

        public DepartDocCateInfo(int id, int departID, int visibility, string categoryName)
        {
            this.id = id;
            this.departID = departID;
            this.visibility = visibility;
            this.categoryName = categoryName;

        }
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }


        public int Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }


        public int DepartID
        {
            get { return departID; }
            set { departID = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
