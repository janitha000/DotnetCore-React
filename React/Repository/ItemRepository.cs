using React.Entity;
using React.Repository.Context;
using React.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.Repository
{
    public class ItemRepository : Repositorybase<Item>
    {
        public ItemRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
