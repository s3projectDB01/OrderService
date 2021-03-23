node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    def msbuildHome = tool 'net5sdk'
    def scannerHome = tool 'sonarscanner'
    withSonarQubeEnv() {
      sh "${scannerHome}/bin/sonar-scanner begin /k:\"s3projectDB01_OrderService\""
      bat "${msbuildHome}/dotnet /t:Rebuild"
      bat "${scannerHome}/bin/sonar-scanner end"
    }
  }
}