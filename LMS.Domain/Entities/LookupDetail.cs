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
    public class LookupDetail : AuditableEntityBase
    {
        public int LookupId { get; set; }
        [StringLength(100)]
        public string Code { get; set; } = String.Empty;

        [StringLength(100)]
        public string Name { get; set; } = String.Empty;

        [StringLength(100)]
        public string NameBN { get; set; } = String.Empty;

        [StringLength(500)]
        public string Description { get; set; } = String.Empty;

        public int? ParentId { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = String.Empty;
    }
}
