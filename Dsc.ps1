# RUN AS ADMIN!!

Configuration MyWebConfig
{
   Node "Server001"
   {
      File MyFileExample
      {
         Ensure = "Present" 
         Type = "Directory“ 
         Recurse = $true
         SourcePath = "c:\windows\temp"
         DestinationPath = "C:\inetpub\newweb"
      }
   }
} 

MyWebConfig 

# Start-DscConfiguration -Wait -Verbose -Path .\MyWebConfig