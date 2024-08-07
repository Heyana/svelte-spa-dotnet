function Invoke-CustomCommand {
    param (
        [string]$Command
    )
    try {
        $output = Invoke-Expression $Command
        Write-Output $output
    }
    catch {
        Write-Error "Error executing command: $_"
        throw
    }
}

function Clear-Dir {
    param (
        [string]$Dir
    )
    if (Test-Path $Dir) {
        try {
            Remove-Item "$Dir\*" -Recurse -Force
            Write-Output "Emptied directory: $Dir"
        }
        catch {
            Write-Error "Failed to empty directory: $_"
            throw
        }
    }
    else {
        Write-Output "Directory $Dir does not exist or is already empty."
    }
}

try {
    # Run bun build:svelte
    Write-Output 'Running bun build:svelte...'
    Invoke-CustomCommand 'bun build:svelte'

    # Copy ./build/index.html to ./csharp-src/wwwroot
    $srcPath = Join-Path -Path (Get-Location) -ChildPath 'build\index.html'
    $destDir = Join-Path -Path (Get-Location) -ChildPath 'csharp-src\wwwroot'
    $destPath = Join-Path -Path $destDir -ChildPath 'index.html'
    Write-Output "Copying $srcPath to $destPath..."
    if (-not (Test-Path $destDir)) {
        New-Item -ItemType Directory -Path $destDir -Force | Out-Null
    }
    Copy-Item -Path $srcPath -Destination $destPath -Force

    # Remove all "./csharp-src/publish/" folder content
    $publishPath = Join-Path -Path (Get-Location) -ChildPath 'csharp-src\publish'
    Write-Output "Removing content from $publishPath..."
    Clear-Dir $publishPath

    Write-Output 'Running bun build:dontnet...'
    Invoke-CustomCommand 'bun build:dotnet'
}
catch {
    Write-Error "Build process failed: $_"
    exit 1
}