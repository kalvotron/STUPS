﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 11:45 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of ReadUiaControlClassCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Read-UiaControlClassCommand test")]
    public class ReadUiaControlClassCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ReadUiaControlClass_TestPipelineInput()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsTrue(
                @"if ( ($null | Read-UiaControlClass) ) { 1; } else { 0; }",
                "0");
        }
        
        [Test] //[Test(Description="ProcessRecord test Null via parameter")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ReadUiaControlClass_TestParameterInputNull()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Read-UiaControlClass -InputObject $null)) { 1; }else{ 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Read-UiaControlClass -InputObject $null)) { 1; } else { 0; }",
                "ParameterBindingValidationException",
                @"Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.");
            
//            UIAutomationTest.Commands.Common.ReadUiaControlClassCommandTestFixture.TestParameterInputNull:
//System.Management.Automation.ParameterBindingValidationException : Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
//  ----> System.Management.Automation.ValidationMetadataException : The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
        }
        
        [Test] //[Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ReadUiaControlClass_TestParameterInputOtherType()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Read-UiaControlClass -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }");
            
                CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Read-UiaControlClass -InputObject (New-Object System.Windows.forms.Label))) { 1; } else { 0; }",
                "ParameterBindingException",
                //@"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""System.Windows.Automation.AutomationElement"".");
                @"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""UIAutomation.IMySuperWrapper"".");
            
//            UIAutomationTest.Commands.Common.ReadUiaControlClassCommandTestFixture.TestParameterInputOtherType:
//System.Management.Automation.ParameterBindingException : Cannot bind parameter 'InputObject'. Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
//  ----> System.Management.Automation.PSInvalidCastException : Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
        }
        
// [Test] //[Test(Description="ProcessRecord test Is AutomationElement")]
// [Category("Slow")][Category("NUnit")]
// [Ignore("Unstable being run on various operationg systems")]
// public void TestParameterInputFormWithClass()
// {
// string codeSnippet = 
// @"Get-UiaWindow -Name '" + 
// CmdletUnitTest.TestRunspace.NUnitTitle + 
// "' | Read-UiaControlClass";
// System.Collections.ObjectModel.Collection<PSObject> coll =
// CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
// Assert.AreEqual(CmdletUnitTest.TestRunspace.NUnitClass, coll[0].ToString());
// }

        [Test] //[Test(Description="ProcessRecord test Is Class")]
        //[Category("Slow")][Category("NUnit")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void ReadUiaControlClass_TestParameterInputControlWithAutomationId()
        {
            string className = "Button";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ControlType.Button,
                "btnName",
                "auid",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ((Get-UiaWindow -n " +
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaButton -name btnName | Read-UiaControlClass)) { '" + 
                className + 
                "'; } else { ''; }",
                className);
        }

        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
}
