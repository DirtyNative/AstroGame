using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Factories
{
    public class ApiFactory<TInput, TOutput> : IFactory<TInput, TOutput>
    {
        public TOutput Create(TInput param)
        {
            throw new NotImplementedException();
        }
    }
}