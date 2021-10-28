using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.Branch;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Branch
{
    public class EfBranchDal : EfEntityRepositoryBase<Entity.Branch.Branch, Context>, IBranchDal
    {
    }
}
