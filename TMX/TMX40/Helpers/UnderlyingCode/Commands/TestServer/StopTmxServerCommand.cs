﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using Server.Library.ObjectModel.ServerControl;
    using Tmx.Server;
    
    /// <summary>
    /// Description of StopTmxServerCommand.
    /// </summary>
    class StopServerCommand : TmxCommand
    {
        internal StopServerCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            ServerControl.Stop();
        }
    }
}
