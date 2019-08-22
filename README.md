# All things .Net

## Technologies
C#, VB.Net, ASP.Net, .NET Core

# Workflow
1. Whilst at work - work of developWork branch
2. Whilst at home - work of developHome branch
3. Once projects are completed pull from either 1 or 2 into develop branch
4. Once testing is completed on project in develop branch, pull into master branch

#Projects
1. TraceListenerLogger_CS
	* Log the results of traces to a file. 
	* Includes Exception logging, etc. 
2.	ThreadSafeApplication1_CS
	* Multithreading (THREADSAFE) Application using the AUTORESETEVENT listener
3. threadedApplication [C#]
	* Multithreading (THREADSAFE) Application using Invoke and Delegate and BackgroundWorker
	* Thread safe calls to WindowsForm Controls
4. windowsService [C#]
	* This project implements a basic WindowsService which, one started via the Services Settings, logs a timestamp every 5 seconds. 
	
5. TelegramMessengerClient_RequestAuthCode [C#]
	* This GUI is used to request an Authentication Code for a specific Telegram User Cell Number.
	* The Authentication Code can be used as input to the TelegramMessengerClient in it's AppConfig File. 
	