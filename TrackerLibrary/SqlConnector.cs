using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class SqlConnector : IDataConnection
    {
        public Prize CreatePrize(Prize model)
        {
            model.Id = 1;
            return model;
        }
    }
}
