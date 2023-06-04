using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Common
{
    public class AuditableEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; } = String.Empty;
    }
}
