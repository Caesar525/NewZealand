using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.Magicodes.Dto
{
    public class ExportActivityDto : EntityDto<Guid?>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Remark { get; set; }
    }
}
