﻿using System;

namespace SGU_C2CStore.Services.Models
{
    public class AutionByTimeProduct : AutionProduct
    {
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
    }
}