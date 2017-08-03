using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces;
using API;
using Classes;
using Rhino;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace CoolWriterUnitTests
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void TestResolver()
        {
            IResolver resolver = new Resolver();
            var writer = resolver.ResolveWriter(1);
            Assert.IsInstanceOfType(writer, typeof(ConsoleWriter));
        }

        [TestMethod]
        public void TestWriteDefault()
        {
            MockRepository mocks = new MockRepository();
            IResolver resolverMock = mocks.Stub<IResolver>();
            IWriter consoleWriterMock = mocks.Stub<IWriter>();
            IConfigurationReader configReaderMock = mocks.Stub<IConfigurationReader>();

            resolverMock.Stub(s => s.ResolveWriter(1)).Return(consoleWriterMock);
            consoleWriterMock.Stub(s => s.Write("Hello World")).Return(true);

        }
    }
}
