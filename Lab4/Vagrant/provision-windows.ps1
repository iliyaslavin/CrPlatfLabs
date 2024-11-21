# Завантаження та встановлення .NET SDK
Invoke-WebRequest -Uri "https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.ps1" -OutFile "dotnet-install.ps1"
.\dotnet-install.ps1 -Channel 7.0

# Додавання змінної середовища
[Environment]::SetEnvironmentVariable("PATH", "$Env:PATH;C:\Program Files\dotnet\", [System.EnvironmentVariableTarget]::Machine)

# Налаштування NuGet-репозиторію
New-Item -Path "$env:USERPROFILE\.nuget\NuGet" -ItemType Directory -Force
Set-Content -Path "$env:USERPROFILE\.nuget\NuGet\NuGet.Config" -Value @"
<configuration>
<packageSources>
    <add key="PrivateRepo" value="http://localhost:5000/v3/index.json" />
</packageSources>
</configuration>
"@

# Встановлення NuGet-пакету
dotnet tool install --global ISlavin --version 1.0.0