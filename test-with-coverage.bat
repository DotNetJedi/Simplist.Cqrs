@echo off
setlocal

if "%BUILD_CONFIGURATION%" == "" set BUILD_CONFIGURATION=Debug
set BUILD_TARGET=%BUILD_CONFIGURATION%
set PATH=%~dp0\.node;%PATH%
set NUNIT=packages\NUnit.ConsoleRunner.3.4.1\tools\nunit3-console.exe
set OPENCOVER=packages\OpenCover.4.6.519\tools\OpenCover.Console.exe
set REPORT_GEN=packages\ReportGenerator.2.4.5.0\tools\ReportGenerator.exe
set TOCOBERTURA=packages\OpenCoverToCoberturaConverter.0.2.4.0\tools\OpenCoverToCoberturaConverter.exe
set TEST_TARGETS=Core.Tests\bin\%BUILD_TARGET%\Simplist.Core.Tests.dll
set NAMESPACE_FILTERS=+[*]* -[FluentAssertions*]*
set ATTRIBUTE_FILTERS=*GeneratedCode*
set

mkdir Reports\Coverage
del /Q /S Reports

@echo ================================================================================
@echo call %OPENCOVER% -register:user "-target:%NUNIT%" "-targetargs:%TEST_TARGETS% --result:Reports\TestResults.xml;format=nunit2" -output:Reports\OpenCover.xml -filter:"%NAMESPACE_FILTERS%" -excludebyattribute:"%ATTRIBUTE_FILTERS%"
@echo --------------------------------------------------------------------------------
call %OPENCOVER% -register:user "-target:%NUNIT%" "-targetargs:%TEST_TARGETS% --result:Reports\TestResults.xml;format=nunit2" -output:Reports\OpenCover.xml -filter:"%NAMESPACE_FILTERS%" -excludebyattribute:"%ATTRIBUTE_FILTERS%"

rem to enable code coverage uncomment the two following lines
@echo ================================================================================
@echo call %TOCOBERTURA% -input:Reports\OpenCover.xml -output:Reports\cobertura.xml -sources:%~dp0
@echo --------------------------------------------------------------------------------
call %TOCOBERTURA% -input:Reports\OpenCover.xml -output:Reports\cobertura.xml -sources:%~dp0

@echo ================================================================================
@echo call %REPORT_GEN% -reports:Reports\OpenCover.xml -targetdir:Reports\Coverage\Server
@echo --------------------------------------------------------------------------------
call %REPORT_GEN% -reports:Reports\OpenCover.xml -targetdir:Reports\Coverage\Server

rem call .\node_modules\.bin\karma.cmd start karma-jenkins.conf.js

endlocal