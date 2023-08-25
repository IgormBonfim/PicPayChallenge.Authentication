using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Common.Producers.Interfaces
{
    public interface IProducer<T> where T : class
    {
        T sendMessage(T fact);
    }
}
