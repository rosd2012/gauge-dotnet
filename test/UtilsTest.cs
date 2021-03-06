﻿// Copyright 2015 ThoughtWorks, Inc.
//
// This file is part of Gauge-CSharp.
//
// Gauge-CSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Gauge-CSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Gauge-CSharp.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
using Gauge.CSharp.Core;
using NUnit.Framework;

namespace Gauge.Dotnet.UnitTests
{
    [TestFixture]
    internal class UtilsTest
    {
        [Test]
        public void ShouldGetCustomBuildPathFromEnvWhenLowerCase()
        {
            Environment.SetEnvironmentVariable("gauge_project_root", @"C:\Blah");

            var imaginaryPath = string.Format("Foo{0}Bar", Path.DirectorySeparatorChar);
            Environment.SetEnvironmentVariable("gauge_custom_build_path", imaginaryPath);
            var gaugeBinDir = Utils.GetGaugeBinDir();
            Assert.AreEqual(string.Format(@"C:\Blah{0}Foo{0}Bar", Path.DirectorySeparatorChar), gaugeBinDir);

            Environment.SetEnvironmentVariable("GAUGE_PROJECT_ROOT", string.Empty);
            Environment.SetEnvironmentVariable("GAUGE_CUSTOM_BUILD_PATH", string.Empty);
        }

        [Test]
        public void ShouldGetCustomBuildPathFromEnvWhenUpperCase()
        {
            var driveRoot = Path.GetPathRoot(Directory.GetCurrentDirectory());
            Environment.SetEnvironmentVariable("GAUGE_PROJECT_ROOT", Path.Combine(driveRoot, "Blah"));

            var imaginaryPath = Path.Combine("Foo", "Bar");
            ;
            Environment.SetEnvironmentVariable("gauge_custom_build_path", imaginaryPath);
            var gaugeBinDir = Utils.GetGaugeBinDir();
            Assert.AreEqual(Path.Combine(driveRoot, "Blah", "Foo", "Bar"), gaugeBinDir);

            Environment.SetEnvironmentVariable("GAUGE_PROJECT_ROOT", string.Empty);
            Environment.SetEnvironmentVariable("GAUGE_CUSTOM_BUILD_PATH", string.Empty);
        }
    }
}