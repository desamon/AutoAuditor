using AutoAuditor.Impl;
using AutoAuditor.Impl.Context;
using System;

namespace AutoAuditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test()
        {
            var filePath = "E:/Work/Visual Studio Projects/AutoAuditor/testXml.xml";
            var service = new Service(null, filePath);
            service.Start();
        }
    }
}
