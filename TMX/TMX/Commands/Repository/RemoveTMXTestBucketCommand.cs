﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of RemoveTmxTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "TmxTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class RemoveTmxTestBucketCommand: TestBucketCmdletBase
    {
    }
}
