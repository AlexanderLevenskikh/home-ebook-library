﻿using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Upload : Entity
    {
        public string Name { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public long Size { get; set; } = default!;
        public DateTimeOffset CreatedAt { get; set; }
    }
}