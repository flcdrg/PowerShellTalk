Set-Location c:\dev\PowerShellTalk

$configData = @{
    AllNodes = @(
        @{
            NodeName = "*"
            PSDscAllowPlainTextPassword = $true
        }
        @{
            NodeName = "169.254.58.142";
        }
#        @{
#            NodeName = "169.254.223.157";
#        }
    )
}

Configuration Win8b
{
    param ([PSCredential] $credential)

    Node $AllNodes.NodeName
    {
        LocalConfigurationManager
        {
            Credential = $credential
            RebootNodeIfNeeded = $true
            AllowModuleOverwrite = $false
        }

        File CustomDirectory
        {
            Ensure = "Present" 
            Type = "Directory“ 
            DestinationPath = "C:\tmp"
        }

        Service MSDTC
        {
            Name = "MSDTC"
            StartupType = "Manual"
            State = "Running"
        }

        File CopyFile
        {
            Type = "File"
            SourcePath = "\\169.254.5.36\c$\Downloads\7z920-x64.msi"
            DestinationPath = "c:\tmp\7z920-x64.msi"
            Credential = $credential
            DependsOn = "[File]CustomDirectory"
        }

        Package 7Zip
        {
            Name = "7Zip"
            Path = "c:\tmp\7z920-x64.msi"
            ProductID = "{23170F69-40C1-2702-0920-000001000000}"
            DependsOn = "[File]CopyFile"
        }
    }
}

Win8b -ConfigurationData $ConfigData -credential (Get-credential)

# winrm set winrm/config/client '@{TrustedHosts="169.254.58.142,169.254.223.157"}'

# Start-DscConfiguration .\Win8 -Wait -Verbose -Credential (Get-Credential)