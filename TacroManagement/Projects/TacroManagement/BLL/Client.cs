using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Client
    {
        private static readonly IClient dal = DALFactory.DataAccess.CreateClient();
    }

}
