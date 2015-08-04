using System;

using InversionOfControlProject.Containers;
using InversionOfControlProject.Containers.Exceptions;

using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void TestNewTypeRegister()
        {
            Container container = new Container();
            container.Register<IComparable, string>();
        }

        [Test]
        public void TestAlreadyRegistered()
        {
            Container container = new Container();
            container.Register<IComparable, string>();
            Assert.Throws(
                typeof(TypeAlreadyRegisteredException), 
                () => container.Register<IComparable, string>()
            );
        }

        [Test]
        public void TestRegisteredResolve()
        {
            Container container = new Container();
            container.Register<IComparable, string>();
            string ret = container.Resolve<IComparable>();

        }

        [Test]
        public void TestNonRegisteredTypeResolve()
        {
            Container container = new Container();
            Assert.Throws(
                typeof(TypeNotRegisteredException),
                () => container.Resolve<IComparable>());
        }
    }
}
