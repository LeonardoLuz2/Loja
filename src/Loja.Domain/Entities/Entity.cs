﻿using System;

namespace Loja.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}
