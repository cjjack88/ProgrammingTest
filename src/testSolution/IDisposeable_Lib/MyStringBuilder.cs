using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDisposeable_Lib
{
    public class MyStringBuilder : IDisposable
    {
        private StringBuilder _stringBuilder;

        public MyStringBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        public void Dispose()
        {
            _stringBuilder = null;
        }

        public string GetHelloWorld()
        {
            _stringBuilder.Append("Hello World");
            return _stringBuilder.ToString();
        }
    }
}
