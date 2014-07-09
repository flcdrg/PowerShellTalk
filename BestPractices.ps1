# Best Practices

# Before
function DestroyZombies($name, $force)
{
    if ($force -eq $true)
    {
        Get-Process $name | Stop-Process -force
    } 
    else 
    {
        Get-Process $name | Stop-Process
    }
}



Set-StrictMode -Version 4

# After
<#
.SYNOPSIS 
Stop zombie processes

.DESCRIPTION
Search for named processes to stop, or stop all processes

.PARAMETER Name
Specifies one or more process names

.PARAMETER All
Specifies the extension. "Txt" is the default.

#>
function Stop-Zombies
{
[CmdletBinding(SupportsShouldProcess = $true)]
    param(
        
        [Parameter(Mandatory=$true, ParameterSetName = "Named", HelpMessage="Enter name of zombie process")]
        [ValidateNotNullOrEmpty()]
        [string] $Name,

        [Parameter(ParameterSetName = "All")]
        [switch] $All,

        [switch] $Force = $false
    )

    Begin
    {
        $count = 0
    }

    Process
    {
        $candidates = @(Get-Process | Where { $All.IsPresent -or $_.Name -eq $Name })        
        
        $candidates | Where-Object { $PSCmdlet.ShouldProcess($_.Name, "Stop-Process") } | ForEach-Object { 
            Write-Host "$_ $Force" 
            $count++
            Write-Progress -Activity "Stopping" -PercentComplete ($count / $candidates.Count * 100)
            sleep 1
        }
    }
    
    End
    {
        Write-Output "Stopped $count zombies"
    }   
}

Stop-Zombies -WhatIf -All
