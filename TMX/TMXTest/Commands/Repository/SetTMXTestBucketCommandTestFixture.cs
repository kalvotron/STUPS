﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/9/2012
 * Time: 10:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.Repository
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SetTmxTestBucketCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class SetTmxTestBucketCommandTestFixture
    {
        public SetTmxTestBucketCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The New-TmxTestDB test")]
        [Category("Slow")]
        [Category("New_TmxTestDB")]
        [Ignore("Not implemented yet")]
        public void CreateTestDB_Simple()
        {
            string fileName = @".\test.db3";
            string answer = @"True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestDB -FileName '" + 
                fileName + 
                @"'; " +
                @"Test-File '" + 
                fileName + 
                @"'; ",
                answer);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Remove-Item '" + 
                fileName +
                @"';");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
