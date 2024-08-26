using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
	public sealed class UserNotFoundException : NotFoundException
	{
		public UserNotFoundException(string message) : base(message)
		{
		}
	}
}
