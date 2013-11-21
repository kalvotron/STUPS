﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/16/2012
 * Time: 12:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUiaMenuClosedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaMenuClosedEvent")]
    public class RegisterUiaMenuClosedEventCommand : EventCmdletBase
    {
        public RegisterUiaMenuClosedEventCommand()
        {
            this.AutomationEventType = AutomationElement.MenuClosedEvent;
            this.AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
