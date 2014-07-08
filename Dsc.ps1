# RUN AS ADMIN!!

Configuration MyWebConfig
{
   Node "clarabel"
   {
      File MyFileExample
      {
         Ensure = "Present" 
         Type = "Directory“ 
         Recurse = $true
         SourcePath = "c:\tmp\wix"
         DestinationPath = "C:\inetpub\newweb"
      }
   }
} 

MyWebConfig 

# Start-DscConfiguration -Wait -Verbose -Path .\MyWebConfig