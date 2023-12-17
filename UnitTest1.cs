using MyServer;
using System.Net;

namespace ServerTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMessageMethod()
        {
            // Arrange
            var messageSource = new Mock<IMessageSource>();
            var server = new Server(messageSource.Object);
            server.Clients.Add("User1", new IPEndPoint(IPAddress.Parse("192.168.1.1"), 1234));
            var testMessage = new NetMessage { NickNameFrom = "User2", NickNameTo = "User1", Text = "Test Message" };

            // Act
            server.RelyMessage(testMessage).Wait();

            // Assert
            messageSource.Verify(mock => mock.SendAsync(testMessage, It.IsAny<IPEndPoint>()), Times.Once);
        }


    }
}