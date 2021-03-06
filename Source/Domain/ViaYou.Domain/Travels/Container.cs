﻿using System;
using System.ComponentModel.DataAnnotations;
using ViaYou.Domain.Enums;

namespace ViaYou.Domain.Travels
{
    public class Container
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public Measure Measure { get; set; }

        public void Update(string name, int min, int max, Measure measure)
        {
            Name = name;
            Min = min;
            Max = max;
            Measure = measure;
        }
    }
}
