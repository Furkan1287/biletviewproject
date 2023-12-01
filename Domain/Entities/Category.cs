﻿using Shared.Entities;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public IEnumerable<Event>? Events { get; set; }
    }
}
