# 📋 Setup Guide for Ubuntu

This guide is for setting up the development environment on **Ubuntu** for the `Analog Prayer Timer` learning project.

## What you need
- Ubuntu 20.04 or newer
- Git
- Visual Studio Code
- .NET 10 SDK
- Terminal

## 1. Update Ubuntu

```bash
sudo apt update
sudo apt upgrade -y
```

## 2. Install required tools

```bash
sudo apt install -y git curl wget code
```

## 3. Install .NET 10 SDK

Use the official install script for a simple Ubuntu setup.

```bash
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 10.0
```

Add .NET to your shell path:

```bash
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc
```

Check that .NET works:

```bash
dotnet --version
```

## 4. Install VS Code extensions

Open VS Code and install these extensions:
- C# Dev Kit
- .NET Install Tool
- C#
- C# Extensions
- IntelliCode

Or install from the terminal:

```bash
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.dotnet-interactive-vscode
code --install-extension ms-dotnettools.vscode-dotnet-runtime
code --install-extension jchannon.csharpextensions
code --install-extension ms-vscode.IntelliCode
```

## 5. Clone the project

```bash
git clone https://github.com/habitakatrennada/analog-prayer-timer.git
cd analog-prayer-timer
code .
```

## 6. Run the project

Use the terminal inside VS Code:

```bash
dotnet run
```

## What to focus on
- Learn C# logic and structure.
- Open `PrayerCalculations/PrayerTimeCalculator.cs`.
- Open `UI/MainWindow.xaml`.
- Change a value and see the result.

## Simple project structure

```
analog-prayer-timer/
├── PrayerCalculations/
├── UI/
├── Models/
└── Program.cs
```

## Notes
This guide stays focused on Ubuntu setup, C# programming, and direct development tasks. It avoids advanced deployment, Docker, and performance tuning.
