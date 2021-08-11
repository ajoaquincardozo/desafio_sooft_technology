using System;
using System.Collections.Generic;
using System.Text;

namespace SooftTechnologyChallengeEj4.Domain.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
