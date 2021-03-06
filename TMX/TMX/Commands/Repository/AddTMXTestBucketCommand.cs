﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    using Interfaces;
    
    /// <summary>
    /// Description of AddTmxTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TmxTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class AddTmxTestBucketCommand : TestBucketCmdletBase
    {
        protected override void ProcessRecord()
        {
            checkDatabaseInput(InputObject);
            
            // blocked due to the need to remove dependency on SQLite
//            SQLiteHelper.CreateBucket(this, BucketName, Tag, Description);
        }
    }
}
