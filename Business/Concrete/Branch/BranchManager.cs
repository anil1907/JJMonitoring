using Business.Abstract.Branch;
using DataAccess.Abstract.Branch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Branch
{
    public class BranchManager : IBranchService
    {
        private IBranchDal _branchDal;
        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }
        public List<Entity.Branch.Branch> GetBranches()
        {
            return _branchDal.GetList();
        }
    }
}
