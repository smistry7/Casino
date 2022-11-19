﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Core.Models
{
    public record User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }
        public DateTimeOffset DateJoined { get; set; }
        public decimal LuckCoefficient { get; set; }
        public ICollection<GameRecord> GameRecords { get; set; } = null!;
    } 
}
