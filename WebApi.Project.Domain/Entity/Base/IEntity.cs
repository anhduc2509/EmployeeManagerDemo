using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Domain
{
    public interface IEntity<TKey>
    {
        TKey GetId();

        void SetId(TKey id);
    }
}
