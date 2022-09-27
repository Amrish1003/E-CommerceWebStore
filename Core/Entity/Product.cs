﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }

    }
}
