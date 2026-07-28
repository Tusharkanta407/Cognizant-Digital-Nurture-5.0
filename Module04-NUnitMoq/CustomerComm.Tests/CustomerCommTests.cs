using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;

        [OneTimeSetUp]
        public void Init()
        {
            // Initialize the mock engine container
            _mockMailSender = new Mock<IMailSender>();

            // Configure the mock framework setup: 
            // When SendMail is called with ANY two strings, intercept it and immediately return true
            _mockMailSender
                .Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);
        }

        [Test]
        [TestCase] 
        public void SendMailToCustomer_WhenInvoked_ReturnsTrueWithoutHittingMailServer()
        {
            CustomerCommLib.CustomerComm customerComm = new CustomerCommLib.CustomerComm(_mockMailSender.Object);
            bool actualResult = customerComm.SendMailToCustomer();
            Assert.That(actualResult, Is.True);
            _mockMailSender.Verify(x => x.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}