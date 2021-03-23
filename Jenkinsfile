node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    def msbuildHome = tool 'net5sdk'
    def scannerHome = tool 'sonarscanner'
    withSonarQubeEnv() {
      sh '${scannerHome}/sonar-scanner-4.4.0.2170/bin/sonar-scanner begin /k:"s3projectDB01_OrderService"'
      sh '${msbuildHome}/dotnet /t:Rebuild'
      sh '${scannerHome}/sonar-scanner-4.4.0.2170/bin/sonar-scanner end'
    }
  }
}