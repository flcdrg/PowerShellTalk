Set-StrictMode -Version 4

# Best Practices

# Before
function DestroyZombies($name)
{
    Get-Process $name | Stop-Process
}


# After
function Stop-Zombies
{
[CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [string] $name
    )

    if ($ConfirmPreference)
    {
    }

    $ConfirmPreference

    if ($WhatIfPreference)
    {

    }

    $WhatIfPreference.IsPresent
}