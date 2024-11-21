#!/bin/bash
# Встановлення .NET SDK
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
bash dotnet-install.sh --channel 7.0
export PATH=$PATH:/home/vagrant/.dotnet

# Встановлення NuGet-репозиторію
mkdir -p ~/.nuget/NuGet
echo '<configuration>
<packageSources>
    <add key="PrivateRepo" value="http://localhost:5000/v3/index.json" />
</packageSources>
</configuration>' > ~/.nuget/NuGet/NuGet.Config

# Встановлення NuGet-пакету
dotnet tool install --global ISlavin --version 1.0.0