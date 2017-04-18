# TimedTrigger Sample application. 
A sample windows service for running on the Apprenda platform which will trigger a RESTful request on a schedule. 

## Basic usage
Modify TriggerService.cs
1. Adjust the target url
1. Modify the Timing of the trigger
1. Package and deploy on an Apprenda platform
1. Promote to Sandbox or Published
1. Be sure the operations team has enabled windows services for the platform

# Enable Windows Services for the platform
* KB article
  * https://support.apprenda.com/hc/en-us/articles/203118384-Enable-Windows-Services-on-the-Platform-
* Apprenda documentation for enabling windows services
  * http://docs.apprenda.com/current/winservices

# TriggerService.cs
A windows service for running scheduled triggers on the Apprenda platform.
* This component is designed to be pulled out of the project 
  * use it as a standalone application
  * or include it with an existing RESTful api archive

# TriggerMonitor.cs
* A sample API for the TimedTrigger to target
* A web page to visualize the activity of the scheduled calls
* Based off of the microsoft tutorial:
* https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api

