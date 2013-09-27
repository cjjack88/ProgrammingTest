using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDisposeable_Lib
{
    public class CallStringBuilder : IDisposable
    {
        private MyStringBuilder _myStringBuilder;

        public CallStringBuilder()
        {
            _myStringBuilder = new MyStringBuilder();
        }

        public void Dispose()
        {
            _myStringBuilder.Dispose();
        }

        public string GetHelloWorld()
        {
            using (_myStringBuilder)
            {
                return _myStringBuilder.GetHelloWorld();
            }
        }
    }
}
