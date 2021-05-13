node {
stage('SCM') {
    checkout scm
}
stage('SonarQube Analysis') {
    def msbuildHome = tool 'net5sdk'
    def scannerHome = tool 'sonarscannermsbuild'
    withSonarQubeEnv() {
        bat "dotnet \"${scannerHome}\\SonarScanner.MSBuild.dll\" begin /k:\"s3projectDB01_OrderService\""
        bat "dotnet build MenuApp.OrderService.sln"
        bat "dotnet \"${scannerHome}\\SonarScanner.MSBuild.dll\" end"
    }
}