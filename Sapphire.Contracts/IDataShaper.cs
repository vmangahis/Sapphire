using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Contracts
{
    public interface IDataShaper<T>
    {
        IEnumerable<Entity> ShapeData(IEnumerable<T> entity, string fieldsString);
        Entity ShapeData(T entity, string fieldsString);
    }
}
