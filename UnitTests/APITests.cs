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
            writer = resolver.ResolveWriter(2);
            Assert.IsInstanceOfType(writer, typeof(DatabaseWriter));
            writer = resolver.ResolveWriter(0);
            Assert.IsInstanceOfType(writer, typeof(ConsoleWriter));
        }

        [TestMethod]
        public void TestWriteDefault()
        {
            MockRepository mocks = new MockRepository();
            IResolver resolverMock = mocks.Stub<IResolver>();
            IWriter consoleWriterMock = mocks.Stub<IWriter>();
            IConfigurationReader configReaderMock = mocks.Stub<IConfigurationReader>();

            configReaderMock.Stub(s => s.WriterTypeId).Return(1);
            configReaderMock.Stub(s => s.DefaultMessage).Return("Hello World");
            Expect.Call(resolverMock.ResolveWriter(1)).Return(consoleWriterMock);
            Expect.Call(consoleWriterMock.Write("Hello World")).Return(true);
            mocks.ReplayAll();
            var api = new WriterAPI();
            api.ConfigurationReader = configReaderMock;
            api.Resolver = resolverMock;
            var result = api.WriteDefaultMessage();
            Assert.IsTrue(result);
            mocks.VerifyAll();
        }

        [TestMethod]
        public void TestWriteCustomMessage()
        {
            MockRepository mocks = new MockRepository();
            IResolver resolverMock = mocks.StrictMock<IResolver>();
            IWriter consoleWriterMock = mocks.StrictMock<IWriter>();
            IConfigurationReader configReaderMock = mocks.StrictMock<IConfigurationReader>();

            configReaderMock.Stub(s => s.WriterTypeId).Return(1);
            configReaderMock.Stub(s => s.DefaultMessage).Return("Hello World");
            Expect.Call(resolverMock.ResolveWriter(1)).Return(consoleWriterMock);
            Expect.Call(consoleWriterMock.Write("custom message")).Return(true);
            mocks.ReplayAll();
            var api = new WriterAPI();
            api.ConfigurationReader = configReaderMock;
            api.Resolver = resolverMock;
            var result = api.WriteCustomMessage("custom message");
            Assert.IsTrue(result);
            mocks.VerifyAll();
        }
    }
}
