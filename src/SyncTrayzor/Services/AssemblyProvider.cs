﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SyncTrayzor.Services
{
    public interface IAssemblyProvider
    {
        Version Version { get; }
        string Location { get; }
        ProcessorArchitecture ProcessorArchitecture { get; }
        Stream GetManifestResourceStream(string path);
    }

    public class AssemblyProvider : IAssemblyProvider
    {
        private readonly Assembly assembly;

        public AssemblyProvider()
        {
            this.assembly = Assembly.GetExecutingAssembly();
        }

        public Version Version
        {
            get { return this.assembly.GetName().Version; }
        }

        public string Location
        {
            get { return this.assembly.Location; }
        }

        public ProcessorArchitecture ProcessorArchitecture
        {
            get { return this.assembly.GetName().ProcessorArchitecture; }
        }

        public Stream GetManifestResourceStream(string path)
        {
            return this.assembly.GetManifestResourceStream(path);
        }
    }
}
