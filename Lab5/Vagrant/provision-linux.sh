#!/bin/bash

# Оновлення системи
sudo apt-get update -y
sudo apt-get upgrade -y

# Встановлення необхідних інструментів
sudo apt-get install -y wget curl git

# Встановлення .NET SDK
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update -y
sudo apt-get install -y dotnet-sdk-6.0

# Перехід у папку застосунку
cd /home/vagrant/app/Lab5WebApp

# Встановлення залежностей
dotnet restore

# Запуск застосунку
dotnet run --urls "http://0.0.0.0:7214"
