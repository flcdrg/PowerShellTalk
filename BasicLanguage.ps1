Set-StrictMode -Version 4

# Variables
$s = "x"
$i = 3
$a = "a", "b"
$d = @{a = 1; b = 2}

# Conditionals
1 -lt 2
5 -eq 5
"abcdefg" -like "*d*"
"abcd9efg" -match "\d"
"a", "b", "c" -contains "b"
"a", "b", "c" -notcontains "d"

if (1 -lt 2)
{
    Write-Output "Yes"
}

switch (4, 2) 
{
    1 {"It is one." }
    2 {"It is two." }
    3 {"It is three." }
    4 {"It is four." }
    3 {"Three again."}
}  

# Loops
for ($i = 0; $i -lt 10; $i++)
{
    Write-Output $i
}

foreach ($i in 1..4)
{
    Write-Output $i
}

while ($i -gt 0)
{
    $i
    $i --
}

# Pipeline
1..10 | Write-Output
10..1 | Sort-Object

Get-ChildItem C:\Windows | Where-Object -Property CreationTime -gt -Value "2014-01-01" | Select-Object -First 10

Get-ChildItem C:\Windows | Select-Object -First 10 -Property Name #-ExpandProperty Name

# functions
function One
{
    Write-Output "One"
}

One

function Two($a, $b)
{
    Write-Output "Two $a, $b"
}

Two "x", 5

function Three
{
    Param($a)
    Begin
    {
        $i = 0
    }

    Process
    {
        $i++
        Write-Output "Three $_, $a"
    }

    End
    {
        Write-Output "Processed $i things"
    }
}

Three "x", 5, 4.9

Get-ChildItem C:\Windows | Select-Object -First 10 -ExpandProperty Name | Three -a "x"

# Scripts
Get-ExecutionPolicy
# Set-ExecutionPolicy RemoteSigned

. .\DotSource.ps1

#