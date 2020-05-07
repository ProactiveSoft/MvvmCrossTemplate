using System;
using System.Reflection;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test.Helpers
{
    public class UsingReflection
    {
        public UsingReflection(ITestOutputHelper output) => _output = output;



        /// <summary>Calls the private method of the given object using reflection.</summary>
        /// <typeparam name="TInstance">The type of the instance in which private method is present.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="instance">Type's instance in which the private method is present.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Result of the method.</returns>
        /// <exception cref="TargetException">Method {methodName} is not present in type {typeof(TInstance)}.</exception>
        public TResult CallPrivateMethod<TInstance, TResult>(TInstance instance, string methodName, object[] parameters) where TInstance : class
        {
            try
            {
                BindingFlags methodType = BindingFlags.NonPublic | BindingFlags.Instance;
                MethodInfo? methodInfo = typeof(TInstance).GetMethod(methodName, methodType);
                if (methodInfo != null) return (TResult)methodInfo.Invoke(instance, parameters);

                throw new TargetException($"Method {methodName} is not present in type {typeof(TInstance)}.");
            }
            catch (TargetException targetException)
            {
                _output.WriteLine($"{targetException.StackTrace}");
                throw;
            }
            catch (ArgumentException)
            {
                _output.WriteLine($"Method {methodName} parameter's signature doesn't match.");
                throw;
            }
            catch (TargetInvocationException)
            {
                _output.WriteLine($"Target method {methodName} threw an exception.");
                throw;
            }
            catch (TargetParameterCountException)
            {
                _output.WriteLine($"No.of parameters of method {methodName} doesn't match.");
                throw;
            }
        }


        private readonly ITestOutputHelper _output;
    }
}