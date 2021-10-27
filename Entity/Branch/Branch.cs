using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Branch
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
