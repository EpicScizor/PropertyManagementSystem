using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Room
    {
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
    }
}
