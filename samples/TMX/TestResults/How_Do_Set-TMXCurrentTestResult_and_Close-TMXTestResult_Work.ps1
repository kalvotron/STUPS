ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll


function Test-Last
{
	param(
	      [string]$Comment
	      )
	"===============================================================" >> C:\1\tmx_test.txt
	"The last: ($($Comment))" >> C:\1\tmx_test.txt
	[TMX.TestData]::CurrentTestScenario.TestResults[[TMX.TestData]::CurrentTestScenario.TestResults.Count - 1].Name >> C:\1\tmx_test.txt
	[TMX.TestData]::CurrentTestScenario.TestResults[[TMX.TestData]::CurrentTestScenario.TestResults.Count - 1].Id >> C:\1\tmx_test.txt
	[TMX.TestData]::CurrentTestScenario.TestResults[[TMX.TestData]::CurrentTestScenario.TestResults.Count - 1].Status >> C:\1\tmx_test.txt
	[TMX.TestData]::CurrentTestScenario.TestResults[[TMX.TestData]::CurrentTestScenario.TestResults.Count - 1].Origin >> C:\1\tmx_test.txt
}

function Test-Current
{
	param(
	      [string]$TestResultName,
	      [string]$Comment
	      )
	"===============================================================" >> C:\1\tmx_test.txt
	"Current $($TestResultName) ($($Comment))" >> C:\1\tmx_test.txt
	[TMX.TestData]::CurrentTestResult.Name >> C:\1\tmx_test.txt
	[TMX.TestData]::CurrentTestResult.Id >> C:\1\tmx_test.txt
	[TMX.TestData]::CurrentTestResult.Status >> C:\1\tmx_test.txt
	[TMX.TestData]::CurrentTestResult.Origin >> C:\1\tmx_test.txt
}

New-TMXTestSuite -Name s1 -Id 1
Add-TMXTestScenario -Name sc1 -Id 11
Add-TMXTestScenario -Name sc2 -Id 22
Add-TMXTestScenario -Name sc3 -Id 33

Set-TMXCurrentTestResult -TestResultName tr1 -Id 1111
	Test-Current tr1 'after Set-TMXCurrentTestResult -TestResultName tr1 -Id 1111'
Set-TMXCurrentTestResult -TestResultName tr2 -Id 2222
	Test-Current tr2 'after Set-TMXCurrentTestResult -TestResultName tr2 -Id 2222'
	Test-Last 'after Set-TMXCurrentTestResult -TestResultName tr2 -Id 2222'
Add-TMXTestResultDetail "detail 02"
	Test-Current tr2 'after Set-TMXCurrentTestResult -TestResultName tr2 -Id 2222 and detail'
	Test-Last 'after Set-TMXCurrentTestResult -TestResultName tr2 -Id 2222 and detail'
Set-TMXCurrentTestResult -TestResultName tr3 -Id 3333
	Test-Current tr3 'after Set-TMXCurrentTestResult -TestResultName tr3 -Id 3333'
	Test-Last 'after Set-TMXCurrentTestResult -TestResultName tr3 -Id 3333'
Add-TMXTestResultDetail "detail 03-1"
Add-TMXTestResultDetail "detail 03-2"
	Test-Current tr3 'after Set-TMXCurrentTestResult -TestResultName tr3 -Id 3333 and details'
	Test-Last 'after Set-TMXCurrentTestResult -TestResultName tr3 -Id 3333 and details'
Set-TMXCurrentTestResult -TestResultName tr4 -Id 4444
	Test-Current tr4 'after Set-TMXCurrentTestResult -TestResultName tr4 -Id 4444'
	Test-Last 'after Set-TMXCurrentTestResult -TestResultName tr4 -Id 4444'
Close-TMXTestResult -TestPassed
	Test-Current tr4 'after Set-TMXCurrentTestResult -TestResultName tr4 -Id 4444 and closing'
	Test-Last 'after Set-TMXCurrentTestResult -TestResultName tr4 -Id 4444 and closing'
Set-TMXCurrentTestResult -TestResultName tr5 -Id 5555
	Test-Current tr5 'after Set-TMXCurrentTestResult -TestResultName tr5 -Id 5555'
	Test-Last 'after Set-TMXCurrentTestResult -TestResultName tr5 -Id 5555'
Add-TMXTestResultDetail "detail 05"
	Test-Current tr5 'after Set-TMXCurrentTestResult -TestResultName tr5 -Id 5555 and detail'
	Test-Last 'after Set-TMXCurrentTestResult -TestResultName tr5 -Id 5555 and detail'
Close-TMXTestResult -TestPassed
	Test-Current tr5 'after Set-TMXCurrentTestResult -TestResultName tr5 -Id 5555 and detail, and closing'
	Test-Last 'after Set-TMXCurrentTestResult -TestResultName tr5 -Id 5555 and detail, and closing'
