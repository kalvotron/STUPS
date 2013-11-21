﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/20/2012
 * Time: 12:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of WaitUiaControlIsVisibleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaControlIsVisible")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaControlIsVisibleCommand : WaitCmdletBase
    {
//        public WaitUiaControlIsVisibleCommand()
//        {
//        }
        
        #region Constructor
        public WaitUiaControlIsVisibleCommand()
        {
            this.ControlType = null;
        }
        #endregion Constructor
        
        #region Parameters
        #endregion Parameters
        
        protected ControlType ControlType { get; set; }
        
        // copy paste from the IsEnabled cmdlet
        protected override void BeginProcessing() {
//            WriteVerbose(this, "Timeout " + Timeout.ToString());
//            try {
//                this.ControlType =
//                    this.InputObject.Current.ControlType;
//            } catch { }
//            
//            if (this.InputObject != null && 
//                (int)this.InputObject.Current.ProcessId > 0 &&
//                this.InputObject.Current.ControlType != null) {
//                WriteVerbose(this, "ControlType " + 
//                             this.ControlType.ProgrammaticName);
//            }
            StartDate = System.DateTime.Now;
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord() {
            if (!this.CheckAndPrepareInput(this)) { return; }
            
            // 20120823
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (IMySuperWrapper inputObject in this.InputObject) {
            
            //System.Windows.Automation.AutomationElement _control = null;
            
            // 20120823
            //if (this.ControlType != this.InputObject.Current.ControlType) {
            if (!Equals(this.ControlType, inputObject.Current.ControlType)) {
                
                this.WriteError(
                    this,
                    "Control is not of " +
                    this.ControlType.ProgrammaticName +
                    " type",
                    "WrongControlType",
                    ErrorCategory.InvalidArgument,
                    true);
            }

            /*
            if (this.ControlType != inputObject.Current.ControlType) {
                
                this.WriteError(
                    this,
                    "Control is not of " +
                    this.ControlType.ProgrammaticName +
                    " type",
                    "WrongControlType",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            */

            //this.WaitIfCondition(_control, false);
            // 20120823
            //this.WaitIfCondition(this.InputObject, false);
            this.WaitIfCondition(inputObject, false);
           
            //WriteObject(this, _control);
            // 20130105
            //WriteObject(this, this.InputObject);
            WriteObject(this, inputObject);
            
            } // 20120823
            
        }
        
//        protected override void StopProcessing()
//        {
//            // 20120620
//            WriteVerbose(this, "User interrupted");
//            this.Wait = false;
//        }
    }
    
    
    /// <summary>
    /// Description of WaitUiaButtonIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaButtonIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaButtonIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaButtonIsVisibleCommand() { this.ControlType = ControlType.Button; } }

    /// <summary>
    /// Description of WaitUiaCalendarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCalendarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaCalendarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaCalendarIsVisibleCommand() { this.ControlType = ControlType.Calendar; } }
    
    /// <summary>
    /// Description of WaitUiaCheckBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCheckBoxIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaCheckBoxIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaCheckBoxIsVisibleCommand() { this.ControlType = ControlType.CheckBox; } }
    
    /// <summary>
    /// Description of WaitUiaComboBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaComboBoxIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaComboBoxIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaComboBoxIsVisibleCommand() { this.ControlType = ControlType.ComboBox; } }
    
    /// <summary>
    /// Description of WaitUiaCustomIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCustomIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaCustomIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaCustomIsVisibleCommand() { this.ControlType = ControlType.Custom; } }
    
    /// <summary>
    /// Description of WaitUiaDataGridIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDataGridIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaDataGridIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaDataGridIsVisibleCommand() { this.ControlType = ControlType.DataGrid; } }
    
    /// <summary>
    /// Description of WaitUiaDataItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDataItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaDataItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaDataItemIsVisibleCommand() { this.ControlType = ControlType.DataItem; } }
    
    /// <summary>
    /// Description of WaitUiaDocumentIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDocumentIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaDocumentIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaDocumentIsVisibleCommand() { this.ControlType = ControlType.Document; } }

    /// <summary>
    /// Description of WaitUiaEditIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaEditIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaEditIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaEditIsVisibleCommand() { this.ControlType = ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUiaTextBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTextBoxIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTextBoxIsVisibleCommand : WaitUiaEditIsVisibleCommand
    { public WaitUiaTextBoxIsVisibleCommand() { this.ControlType = ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUiaGroupIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaGroupIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaGroupIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaGroupIsVisibleCommand() { this.ControlType = ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUiaGroupBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaGroupBoxIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaGroupBoxIsVisibleCommand : WaitUiaGroupIsVisibleCommand
    { public WaitUiaGroupBoxIsVisibleCommand() { this.ControlType = ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUiaHeaderIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHeaderIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaHeaderIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaHeaderIsVisibleCommand() { this.ControlType = ControlType.Header; } }
    
    /// <summary>
    /// Description of WaitUiaHeaderItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHeaderItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaHeaderItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaHeaderItemIsVisibleCommand() { this.ControlType = ControlType.HeaderItem; } }
    
    /// <summary>
    /// Description of WaitUiaHyperlinkIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHyperlinkIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaHyperlinkIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaHyperlinkIsVisibleCommand() { this.ControlType = ControlType.Hyperlink; } }
    
    /// <summary>
    /// Description of WaitUiaLinkLabelIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaLinkLabelIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaLinkLabelIsVisibleCommand : WaitUiaHyperlinkIsVisibleCommand
    { public WaitUiaLinkLabelIsVisibleCommand() { this.ControlType = ControlType.Hyperlink; } }

    /// <summary>
    /// Description of WaitUiaImageIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaImageIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaImageIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaImageIsVisibleCommand() { this.ControlType = ControlType.Image; } }
    
    /// <summary>
    /// Description of WaitUiaListIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaListIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaListIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaListIsVisibleCommand() { this.ControlType = ControlType.List; } }
    
    /// <summary>
    /// Description of WaitUiaListItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaListItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaListItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaListItemIsVisibleCommand() { this.ControlType = ControlType.ListItem; } }
    
    /// <summary>
    /// Description of WaitUiaMenuIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaMenuIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaMenuIsVisibleCommand() { this.ControlType = ControlType.Menu; } }
    
    /// <summary>
    /// Description of WaitUiaMenuBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaMenuBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaMenuBarIsVisibleCommand() { this.ControlType = ControlType.MenuBar; } }

    /// <summary>
    /// Description of WaitUiaMenuItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaMenuItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaMenuItemIsVisibleCommand() { this.ControlType = ControlType.MenuItem; } }
    
    /// <summary>
    /// Description of WaitUiaPaneIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaPaneIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaPaneIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaPaneIsVisibleCommand() { this.ControlType = ControlType.Pane; } }
    
    /// <summary>
    /// Description of WaitUiaProgressBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaProgressBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaProgressBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaProgressBarIsVisibleCommand() { this.ControlType = ControlType.ProgressBar; } }
    
    /// <summary>
    /// Description of WaitUiaRadioButtonIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaRadioButtonIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaRadioButtonIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaRadioButtonIsVisibleCommand() { this.ControlType = ControlType.RadioButton; } }
    
    /// <summary>
    /// Description of WaitUiaScrollBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaScrollBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaScrollBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaScrollBarIsVisibleCommand() { this.ControlType = ControlType.ScrollBar; } }

    /// <summary>
    /// Description of WaitUiaSeparatorIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSeparatorIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaSeparatorIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaSeparatorIsVisibleCommand() { this.ControlType = ControlType.Separator; } }
    
    /// <summary>
    /// Description of WaitUiaSliderIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSliderIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaSliderIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaSliderIsVisibleCommand() { this.ControlType = ControlType.Slider; } }
    
    /// <summary>
    /// Description of WaitUiaSpinnerIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSpinnerIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaSpinnerIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaSpinnerIsVisibleCommand() { this.ControlType = ControlType.Spinner; } }
    
    /// <summary>
    /// Description of WaitUiaSplitButtonIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSplitButtonIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaSplitButtonIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaSplitButtonIsVisibleCommand() { this.ControlType = ControlType.SplitButton; } }
    
    /// <summary>
    /// Description of WaitUiaStatusBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaStatusBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaStatusBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaStatusBarIsVisibleCommand() { this.ControlType = ControlType.StatusBar; } }

    /// <summary>
    /// Description of WaitUiaTabIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTabIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTabIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTabIsVisibleCommand() { this.ControlType = ControlType.Tab; } }
    
    /// <summary>
    /// Description of WaitUiaTabItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTabItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTabItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTabItemIsVisibleCommand() { this.ControlType = ControlType.TabItem; } }
    
    /// <summary>
    /// Description of WaitUiaTableIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTableIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTableIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTableIsVisibleCommand() { this.ControlType = ControlType.Table; } }
    
    /// <summary>
    /// Description of WaitUiaTextIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTextIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTextIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTextIsVisibleCommand() { this.ControlType = ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUiaLabelIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaLabelIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaLabelIsVisibleCommand : WaitUiaTextIsVisibleCommand
    { public WaitUiaLabelIsVisibleCommand() { this.ControlType = ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUiaThumbIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaThumbIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaThumbIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaThumbIsVisibleCommand() { this.ControlType = ControlType.Thumb; } }

    /// <summary>
    /// Description of WaitUiaTitleBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTitleBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTitleBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTitleBarIsVisibleCommand() { this.ControlType = ControlType.TitleBar; } }
    
    /// <summary>
    /// Description of WaitUiaToolBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaToolBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaToolBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaToolBarIsVisibleCommand() { this.ControlType = ControlType.ToolBar; } }
    
    /// <summary>
    /// Description of WaitUiaToolTipIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaToolTipIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaToolTipIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaToolTipIsVisibleCommand() { this.ControlType = ControlType.ToolTip; } }
    
    /// <summary>
    /// Description of WaitUiaTreeIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTreeIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTreeIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTreeIsVisibleCommand() { this.ControlType = ControlType.Tree; } }
    
    /// <summary>
    /// Description of WaitUiaTreeItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTreeItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTreeItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTreeItemIsVisibleCommand() { this.ControlType = ControlType.TreeItem; } }
    
    /// <summary>
    /// Description of WaitUiaChildWindowIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaChildWindowIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaChildWindowIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaChildWindowIsVisibleCommand() { this.ControlType = ControlType.Window; } }
}
