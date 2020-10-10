﻿using System;

namespace PocketPharmacy.Core.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Medicine Medicine { get; set; }
        public DateTime RecordingDate { get; set; }
        public int Quantity { get; set; }
    }
}
