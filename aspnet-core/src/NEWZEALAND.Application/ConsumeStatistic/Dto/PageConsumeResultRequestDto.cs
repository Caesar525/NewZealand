﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.ConsumeStatistic.Dto
{
    public class PageConsumeResultRequestDto: PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
