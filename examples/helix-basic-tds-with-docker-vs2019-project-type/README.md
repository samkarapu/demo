# Welcome to the Sitecore Helix Examples - TDS with Docker and vs2019 project type

In order to start:
1. Clone/copy the whole Helix Example repo.
2. Locate Helix.Examples/examples/helix-basic-tds-with-docker-vs2019-project-type/BasicCompany.sln and open it in VS2019 :-)
3. Build solution
4. In order to get the TDS syncing to work, you need to have HedgehogDevelopment.SitecoreProject.Service.dll in your bin folder(in Helix.Examples/examples/helix-basic-tds-with-docker-vs2019-project-type/Docker/data/cm/wwwroot)  
   Select one of the TDS project's, say BasicCompany.Foundation.Multisite.Master. Select properties => Build and set the "Sitecore Deploy Folder" to your wwwroot folder(C:\Projects\Helix.Examples\examples\helix-basic-tds-with-docker-vs2019-project-type\Docker\data\cm\wwwroot):
   Now, right click on the TDS project and select "Install Sitecore Connector". That should install the dll in your bin filder.
5. Execute Set-LicenseEnvironmentVariable.ps1 script in our Docker folder(C:\Projects\Helix.Examples\examples\helix-basic-tds-with-docker-vs2019-project-type\Docker):
   .\Set-LicenseEnvironmentVariable.ps1  -Path C:\license\license.xml -PersistForCurrentUser
6.  Set the Docker Compose project as StartUp Project and hit Docker Compose button :-)
7. Run whales-names and update your host file, by adding basic-company to your cm instance. Don't forget to cancel whales-names ;)
