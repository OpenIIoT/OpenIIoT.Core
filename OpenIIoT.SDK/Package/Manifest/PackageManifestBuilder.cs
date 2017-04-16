using System;
using System.Collections.Generic;

namespace OpenIIoT.SDK.Package.Manifest
{
    public class PackageManifestBuilder : IPackageManifestBuilder
    {
        #region Public Constructors

        public PackageManifestBuilder(PackageManifest manifest = default(PackageManifest))
        {
            if (manifest == default(PackageManifest))
            {
                Manifest = new PackageManifest();
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public PackageManifest Manifest { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public PackageManifestBuilder BuildDefault(IList<IPackageManifestFile> files = default(IList<IPackageManifestFile>))
        {
            this.Title("DefaultPlugin")
                .Version("1.0.0")
                .Namespace("OpenIIoT.Plugin")
                .Description("Default plugin.")
                .Publisher("OpenIIoT Team")
                .Copyright("Copyright (c) " + DateTime.Now.Year + " OpenIIoT")
                .License("AGPLv3")
                .Url("http://github.com/openiiot");

            if (files != default(IList<IPackageManifestFile>))
            {
                foreach (IPackageManifestFile file in files)
                {
                    this.AddFile(file);
                }
            }

            return this;
        }

        public PackageManifestBuilder AddFile(IPackageManifestFile file)
        {
            if (Manifest.Files == default(IList<IPackageManifestFile>))
            {
                Manifest.Files = new List<IPackageManifestFile>();
            }

            Manifest.Files.Add(file);

            return this;
        }

        public PackageManifestBuilder RemoveFile(IPackageManifestFile file)
        {
            if (Manifest.Files != default(IList<IPackageManifestFile>) && Manifest.Files.Contains(file))
            {
                Manifest.Files.Remove(file);
            }

            return this;
        }

        public PackageManifestBuilder ClearFiles()
        {
            if (Manifest.Files != default(IList<IPackageManifestFile>))
            {
                Manifest.Files.Clear();
            }

            return this;
        }

        public PackageManifestBuilder Copyright(string copyright)
        {
            Manifest.Copyright = copyright;
            return this;
        }

        public PackageManifestBuilder Description(string description)
        {
            Manifest.Description = description;
            return this;
        }

        public PackageManifestBuilder Files(List<IPackageManifestFile> files)
        {
            Manifest.Files = files;
            return this;
        }

        public PackageManifestBuilder License(string license)
        {
            Manifest.License = license;
            return this;
        }

        public PackageManifestBuilder Namespace(string ns)
        {
            Manifest.Namespace = ns;
            return this;
        }

        public PackageManifestBuilder Publisher(string publisher)
        {
            Manifest.Publisher = publisher;
            return this;
        }

        public PackageManifestBuilder Signature(IPackageManifestSignature signature)
        {
            Manifest.Signature = signature;
            return this;
        }

        public PackageManifestBuilder Title(string title)
        {
            Manifest.Title = title;
            return this;
        }

        public PackageManifestBuilder Url(string url)
        {
            Manifest.Url = url;
            return this;
        }

        public PackageManifestBuilder Version(string version)
        {
            Manifest.Version = version;
            return this;
        }

        #endregion Public Methods
    }
}