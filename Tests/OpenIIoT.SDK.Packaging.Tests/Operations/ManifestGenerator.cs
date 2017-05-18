using System;
using Xunit;

namespace OpenIIoT.SDK.Packaging.Tests.Operations
{
    public class ManifestGenerator
    {
        #region Public Constructors

        public ManifestGenerator()
        {
            generator = new Packaging.Operations.ManifestGenerator();
        }

        #endregion Public Constructors

        #region Public Properties

        public Packaging.Operations.ManifestGenerator generator { get; set; }

        #endregion Public Properties

        #region Public Methods

        [Fact]
        public void GenerateBlankDirectory()
        {
            Exception ex = Record.Exception(() => generator.GenerateManifest(string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void GenerateNullDirectory()
        {
            Exception ex = Record.Exception(() => generator.GenerateManifest(null));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        #endregion Public Methods
    }
}