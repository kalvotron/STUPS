﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 08:40 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewSuiteCmdletBase.
    /// </summary>
    public class NewSuiteCmdletBase : CommonCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Overrides the Name parameters at the CommonCmdletBase class level.
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] BeforeScenario { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] AfterScenario { get; set; }
        #endregion Parameters
    }
}
