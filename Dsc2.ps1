Set-Location c:\dev\PowerShellTalk

$dtc = $false

Configuration Win8
{
    Node "169.254.58.142"
    {
        LocalConfigurationManager
        {
            # Credential = $cred
            RebootNodeIfNeeded = $true
            AllowModuleOverwrite = $false
        }

        File CustomDirectory
        {
            Ensure = "Present" 
            Type = "Directory“ 
            DestinationPath = "C:\tmp"
        }

        if ($dtc)
        {
            Service MSDTC
            {
                Name = "MSDTC"
                StartupType = "Manual"
                State = "Running"
            }
        }
    }
}

Win8

# Go to Win8a and run Get-DscLocalConfigurationManager
# Show Windows Explorer 

# Set-DscLocalConfigurationManager .\Win8

# winrm get winrm/config/client
# winrm set winrm/config/client '@{TrustedHosts="169.254.58.142"}'

# Set-DscLocalConfigurationManager .\Win8 -Credential (Get-Credential)

# Start-DscConfiguration .\Win8 -Wait -Verbose -Credential (Get-Credential)