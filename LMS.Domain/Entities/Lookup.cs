using LMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Lookup : AuditableEntityBase
    {
        [StringLength(100)]
        public string Code { get; set; } = String.Empty;
        [StringLength(100)]
        public string Name { get; set; } = String.Empty;
        [StringLength(100)]
        public string NameBN { get; set; } = String.Empty;

        public int? ParentId { get; set; }
        [StringLength(10)]
        public string Status { get; set; } = String.Empty;
        public int DevCode { get; set; }
    }
}
