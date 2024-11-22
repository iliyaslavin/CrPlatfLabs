#!/bin/bash

echo "Updating system packages..."
sudo apt-get update -y && sudo apt-get upgrade -y

echo "Installing dependencies..."
sudo apt-get install -y curl git unzip apt-transport-https

echo "Installing .NET SDK..."
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update && sudo apt-get install -y dotnet-sdk-8.0

echo "Building the Lab6 project..."
cd /home/vagrant/Lab6
dotnet build

echo "Environment setup complete!"
