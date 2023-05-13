using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RoomService
    {
        private readonly UnitOfWork unitOfWork;

        public RoomService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
