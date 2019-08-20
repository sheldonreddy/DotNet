These are BAT files created to install, start, stop and uninstall the service I created.






RightClick the Install Bat file and edit the fields accordingly.

Service path: Debug folder where the <serviceName>.exe is located. (Typically the bin\debug folder)
Service Name: The name of the service application you created. eg. myWindowsService.exe


eg. of bat file format for install:
InstallUtil.exe C:\....\MyFirstService\bin\Debug\MyFirstService.exe

eg. of bat file format for un-install:
InstallUtil.exe -u C:\....\MyFirstService\bin\Debug\MyFirstService.exe