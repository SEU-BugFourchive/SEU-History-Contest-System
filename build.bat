@echo off

set i=1
set n=3

echo (%i%/%n%)Restoring Git submodules...
if not exist .git git init
call git submodule init
call git submodule update
set /a i=i+1

:: echo (%i%/%n%)Restoring Client-side NPM packages & build webpack...
:: call npm install
:: call node node_modules/webpack/bin/webpack.js --config webpack.config.vendor.js --env.prod
:: call node node_modules/webpack/bin/webpack.js --env.prod
:: if %ERRORLEVEL% NEQ 0 pause
:: set /a i=i+1
:: cd ../

echo (%i%/%n%)Restoring Server-side Nuget packages...
call dotnet restore "./HistoryContest.sln"
if %ERRORLEVEL% NEQ 0 pause
set /a i=i+1

echo (%i%/%n%)Building Server...
cd ./HistoryContest.Server
call dotnet build -c Debug  
set /a i=i+1

:: echo.
:: echo (%i%/%n%)Restoring MDWiki renderer html...
:: cd ./HistoryContest.Docs/Wiki
:: if not exist ./index.html call powershell if(!(Test-Path ./index.html)) { cURL -Uri 'http://dynalon.github.io/mdwiki/index.html' -OutFile './index.html'; Unblock-File './index.html' }

echo Build process finished.
pause
