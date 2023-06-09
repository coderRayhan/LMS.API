using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.LookupDetails.Queries
{
    public class GetLookupDetailResponse
    {
        public int Id { get; set; }
        public int LookupId { get; set; }
        public string Code { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string NameBN { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int? ParentId { get; set; }
        public string Status { get; set; } = String.Empty;
    }
}
