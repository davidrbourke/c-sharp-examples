using System;
using C_Sharp_Examples.InterviewSamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests.InterviewSamples
{
    [TestClass]
    public class DeleteNodeTests
    {
        [TestMethod]
        public void DeleteANode_MiddleNodeSupplied_NodeDeleted()
        {
            // Arrange
            var a = new LinkedListNode(1);
            var b = new LinkedListNode(2);
            var c = new LinkedListNode(3);
            a.Next = b;
            b.Next = c;

            // Act
            var nodeUtil = new DeleteNode();
            nodeUtil.DeleteANode(ref b);

            // Assert
            Assert.IsTrue(a.Next.Value == c.Value);
        }
    }
}
