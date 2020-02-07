pipeline {
    agent {
        node {
            label "Windows && Unity"
        }
    }

    environment {
        UNITY_VERSION = "2019.3.0f6"
    }

    stages {
        stage("Build") {
            steps {
                dir("Builds") {
                    deleteDir()
                }

                BuildOnUnity("Builds/Build.exe")

                zip zipFile: "Build_Windows.zip", archive: true, dir: 'Builds/'
            }

            post {
                always {
                    cleanWs()
                }
            }
        }
    }

    post {
        always {
            slackSend message: "Build Completed with *${currentBuild.result}* - ${env.JOB_NAME} ${env.BUILD_NUMBER} (<${env.BUILD_URL}|Detail>)"
        }
    }
}

def BuildOnUnity(String path) {
    bat """
    "%UNITY_ROOT%\\%UNITY_VERSION%\\Editor\\Unity.exe" ^
    -projectPath "%WORKSPACE%" ^
    -buildWindows64Player "${path}"^
    -batchmode ^
    -logFile - ^
    -quit
    """
}