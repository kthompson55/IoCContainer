using System;

using InversionOfControlProject;
using InversionOfControlProject.Containers;
using InversionOfControlProject.Containers.Exceptions;
using InversionOfControlProject.Lifestyle;

using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void TestAlreadyRegisteredTransient()
        {
            Container container = new Container();
            container.Register<IComparable, DummyComparable>();
            Assert.Throws(
                typeof(TypeAlreadyRegisteredException),
                () => container.Register<IComparable, DummyComparable>()
            );
        }

        [Test]
        public void TestDifferentObjectTransient()
        {
            Container container = new Container();
            container.Register<IComparable, DummyComparable>();
            DummyComparable instance1 = container.Resolve<IComparable>() as DummyComparable;
            DummyComparable instance2 = container.Resolve<IComparable>() as DummyComparable;

            Assert.AreNotSame(instance1, instance2);
        }

        [Test]
        public void TestNewTypeRegisterStatic()
        {
            Container container = new Container();
            container.Register<IComparable, DummyComparable>(LifestyleType.Static);
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
        public void TestNonregisteredTypeResolve()
        {
            Container container = new Container();
            Assert.Throws(
                typeof(TypeNotRegisteredException),
                () => container.Resolve<IComparable>());
        }

        [Test]
        public void TestRegisteredResolveStatic()
        {
            Container container = new Container();
            container.Register<IComparable, DummyComparable>(LifestyleType.Static);
            DummyComparable ret = container.Resolve<IComparable>() as DummyComparable;
            Assert.NotNull(ret);
        }

        [Test]
        public void TestSameObjectStatic()
        {
            Container container = new Container();
            container.Register<IComparable, DummyComparable>(LifestyleType.Static);
            DummyComparable instance1 = container.Resolve<IComparable>() as DummyComparable;
            DummyComparable instance2 = container.Resolve<IComparable>() as DummyComparable;

            Assert.AreSame(instance1, instance2);
        }
    }
}
