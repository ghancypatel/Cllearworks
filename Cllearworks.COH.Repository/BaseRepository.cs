using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.Repository
{
    public class BaseRepository
    {
        public COHEntities Context { get; set; }

        public BaseRepository()
        {
            Context = new COHEntities();
        }
    }
}
