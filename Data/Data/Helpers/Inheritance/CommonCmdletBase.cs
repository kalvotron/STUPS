﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 6:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System.Management.Automation;
    using PSTestLib;
    using System.Collections;
    
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    public class CommonCmdletBase : PSCmdletBase
    {
        public CommonCmdletBase()
        {
            if (UnitTestMode || ModuleAlreadyLoaded) return;
            DataFactory.AutofacModule = new DataModule();

            DataFactory.Init();

            ModuleAlreadyLoaded = true;
            /*
            if (!UnitTestMode && !ModuleAlreadyLoaded)
            {

                DataFactory.AutofacModule = new DataModule();

                DataFactory.Init();

                ModuleAlreadyLoaded = true;
            }
            */

            //CurrentData.Init();
        }
        
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
        }
        
        internal static bool ModuleAlreadyLoaded { get; set; }
        
        protected override void WriteLog(LogLevels logLevel, string logRecord)
        {
            if (Preferences.AutoLog) {
                
                // 20140317
                // turning off the logger
//                switch (logLevel) {
//                    case LogLevels.Fatal:
//                        Tmx.Logger.Fatal(logRecord);
//                        break;
//                    case LogLevels.Error:
//                        Tmx.Logger.Error(logRecord);
//                        break;
//                    case LogLevels.Warn:
//                        Tmx.Logger.Warn(logRecord);
//                        break;
//                    case LogLevels.Info:
//                        Tmx.Logger.Info(logRecord);
//                        break;
//                    case LogLevels.Debug:
//                        Tmx.Logger.Debug(logRecord);
//                        break;
//                    case LogLevels.Trace:
//                        Tmx.Logger.Trace(logRecord);
//                        break;
//                }
            }
        }
        
        protected void WriteLog(LogLevels logLevel, ErrorRecord errorRecord)
        {
            if (!Preferences.AutoLog) return;
            WriteLog(logLevel, errorRecord.Exception.Message);
            // 20131102
            //this.WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line.ToString());
            WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line);
            /*
            if (Preferences.AutoLog)
            {

                this.WriteLog(logLevel, errorRecord.Exception.Message);
                // 20131102
                //this.WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line.ToString());
                this.WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line);
            }
            */
        }
        
        protected override bool CheckSingleObject(PSCmdletBase cmdlet, object outputObject) { return true; }
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection) {}
        protected override void BeforeWriteSingleObject(PSCmdletBase cmdlet, object outputObject) {}
        
        protected override void WriteSingleObject(PSCmdletBase cmdlet, object outputObject)
        {
            try {
                base.WriteObject(outputObject);
            }
            catch {}
        }
        
        protected override void AfterWriteSingleObject(PSCmdletBase cmdlet, object outputObject) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection) {}
        
        // 20131114
        protected override void WriteSingleError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            WriteErrorMethod010RunScriptBlocks(cmdlet);
            
            WriteErrorMethod020SetTestResult(cmdlet, errorRecord);
            
            WriteErrorMethod030ChangeTimeoutSettings(cmdlet, terminating);
            
            WriteErrorMethod040AddErrorToErrorList(cmdlet, errorRecord);
            
            WriteErrorMethod045OnErrorScreenshot(cmdlet);
            
            WriteErrorMethod050OnErrorDelay(cmdlet);
            
            WriteErrorMethod060OutputError(cmdlet, errorRecord, terminating);
            
            WriteErrorMethod070Report(cmdlet);
        }
        
        protected override void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, " Data");
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            WriteVerbose(this, " Data");
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            WriteVerbose(this, " Data");
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            WriteVerbose(this, " Data");
        }

        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, "WriteErrorMethod045OnErrorScreenshot Data");
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, " Data");
        }

        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            if (terminating) {
                WriteVerbose(this, "terminating error !!!");
                try {
                    ThrowTerminatingError(errorRecord);
                }
                catch {}
            } else {
                WriteVerbose(this, "regular error !!!");
                try {
                    WriteError(errorRecord);
                }
                catch {}
            }
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, " Data");
        }
    }
}
