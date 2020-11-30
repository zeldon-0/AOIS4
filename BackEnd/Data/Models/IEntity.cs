using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public interface IEntity
    {
        double Value { get; }
        int Identifier { get; }
    }
}
