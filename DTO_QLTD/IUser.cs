using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    // Interface chung cho các đối tượng liên quan đến người dùng (User)
    public interface IUser
    {
        string Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
    }
}
