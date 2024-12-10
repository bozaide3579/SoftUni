using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
	public class Application : IApplication
	{
		public IRepository<IProduct> Products { get; }
		public IRepository<IUser> Users { get; }

        public Application()
        {
			Products = new ProductRepository();
			Users = new UserRepository();
		}
    }
}
