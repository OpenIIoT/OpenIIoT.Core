namespace OpenIIoT.SDK.Common.OperationResult.Tests
{
    using Xunit;

    /// <summary>
    ///     Tests the <see cref="Message"/> class.
    /// </summary>
    public class MessageTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests the constructor of <see cref="Message"/>.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Message testblank = new Message();

            Assert.Equal(MessageType.Info, testblank.Type);
            Assert.Equal(string.Empty, testblank.Text);

            Message testtype = new Message(MessageType.Warning);

            Assert.Equal(MessageType.Warning, testtype.Type);
            Assert.Equal(string.Empty, testtype.Text);

            Message test = new Message(MessageType.Error, "test!");

            Assert.Equal(MessageType.Error, test.Type);
            Assert.Equal("test!", test.Text);
        }

        /// <summary>
        ///     Tests <see cref="Message.ToString"/>.
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Message test = new Message(MessageType.Info, "Test");

            Assert.Equal("[INFO] Test", test.ToString());
        }

        #endregion Public Methods
    }
}