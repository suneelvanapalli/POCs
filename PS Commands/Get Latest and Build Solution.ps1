$portalClientSolutionPath = "D:\GIT\NumericSequenceCalculator\NumericSequenceCalculator\"
$portalClientSolutionName = "NumericSequenceCalculator.sln"

Set-Location $portalClientSolutionPath

getlatest("master")

#C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe $portalClientSolutionName /t:Build /p:Configuration=Release

function getlatest($branchName){

  #  ECHO Discard changes
  #  git reset --hard

    ECHO GIT CHECKOUT MASTER
    git checkout $branchName

    git pull

    ECHO 'GIT STATUS'
    git status    

}

