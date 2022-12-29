using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CTS.BAL.Services;
using CTS.Models;
using CTS.DAL;
using CTS.DAL.Repositories;

namespace CTS.BAL.Services
{
    public class DepartmentService
    {
          
        private DepartmentRepository  _iDepartmentRepository;

        public DepartmentService()
        {
            _iDepartmentRepository = new DepartmentRepository();
        }

        public IEnumerable<Dept_Master> GetAll()
        {
            return _iDepartmentRepository.GetAll();
        }
    }
}
