$portalClientSolutionPath = "D:\GIT\NumericSequenceCalculator\NumericSequenceCalculator\"
$portalClientSolutionName = "NumericSequenceCalculator.sln"

Set-Location $portalClientSolutionPath
#git checkout develop
 
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe $portalClientSolutionName /t:Build /p:Configuration=Release
