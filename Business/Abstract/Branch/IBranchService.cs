using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract.Branch
{
    public interface IBranchService
    {
        List<Entity.Branch.Branch> GetBranches();
    }
}
