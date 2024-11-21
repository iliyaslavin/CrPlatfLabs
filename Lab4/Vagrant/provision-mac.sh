#!/bin/bash
# Встановлення .NET SDK
brew install --cask dotnet-sdk

# Налаштування NuGet-репозиторію
mkdir -p ~/.nuget/NuGet
echo '<configuration>
<packageSources>
    <add key="PrivateRepo" value="http://localhost:5000/v3/index.json" />
</packageSources>
</configuration>' > ~/.nuget/NuGet/NuGet.Config

# Встановлення NuGet-пакету
dotnet tool install --global ISlavin --version 1.0.0
