using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true)]
    public class TestAttribute:Attribute
    {
        public string Name { get; set; } = "Test";
    }
}
