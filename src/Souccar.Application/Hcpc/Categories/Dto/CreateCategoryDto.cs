﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Categories.Dto
{
    public class CreateCategoryDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}
