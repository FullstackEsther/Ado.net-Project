using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Model;

namespace AdoProject.Service.Interface
{
    public interface IManagerService
    {
        public ManagerDto Get(int Id); 
    }
}