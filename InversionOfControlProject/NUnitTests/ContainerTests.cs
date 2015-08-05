using System;

using InversionOfControlProject.Containers;
using InversionOfControlProject.Containers.Exceptions;

using DummyObjects;

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
            container.Register<IComparable, DummyComparable>();
        }

        [Test]
        public void TestAlreadyRegistered()
        {
            Container container = new Container();
            container.Register<IComparable, DummyComparable>();
            Assert.Throws(
                typeof(TypeAlreadyRegisteredException),
                () => container.Register<IComparable, DummyComparable>()
            );
        }

        [Test]
        public void TestRegisteredResolve()
        {
            Container container = new Container();
            container.Register<IComparable, DummyComparable>();
            DummyComparable ret = container.Resolve<IComparable>() as DummyComparable;
            Assert.NotNull(ret);
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
