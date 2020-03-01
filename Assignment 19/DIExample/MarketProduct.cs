using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIExample
{
  

    class MarketProduct
    {
        private IData _data;

        public MarketProduct(IData _injectedData)
        {
            _data = _injectedData;
        }

        public void GetPersonalCode()
        {
            _data.GetCode();
        }

        public void GetDescription()
        {
            _data.GetDescription();
        }

    }
}
