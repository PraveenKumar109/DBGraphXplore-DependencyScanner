using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGraphXplore.Core.EventHandlers
{
    public class GenericEventHandler<T>
    {
        private readonly T value;
        public GenericEventHandler(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get { return value; }
        }
    }
}
