namespace Smelt.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Fixie;

    public class TestingConvention : Discovery, Execution
    {
        public TestingConvention()
        {
            Classes.Where(x => x.Name.StartsWith("When"));
            Parameters.Add<InputParameterSource>();
        }

        public void Execute(TestClass testClass)
        {
            TestRoms.Clear();
            var instance = testClass.Construct();

            testClass.RunCases(@case =>
                               {
                                   @case.Execute(instance);
                               });

            instance.Dispose();
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class Input : Attribute
    {
        public Input(params object[] parameters)
        {
            Parameters = parameters;
        }

        public object[] Parameters { get; }
    }

    public class InputParameterSource : ParameterSource
    {
        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            var inputAttributes = method.GetCustomAttributes<Input>().ToArray();

            foreach (var input in inputAttributes)
                yield return input.Parameters;
        }
    }
}
