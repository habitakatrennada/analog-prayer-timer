# 📋 Setup Guide for Ubuntu Environment

Complete guide to prepare your development environment for the **Analog Prayer Timer** project on **Ubuntu**.

---

## 📑 Table of Contents

1. [System Requirements](#system-requirements)
2. [System Update](#system-update)
3. [Install .NET 10 SDK](#install-net-10-sdk)
4. [Install VS Code](#install-vs-code)
5. [Install Required Extensions](#install-required-extensions)
6. [Install Additional Tools](#install-additional-tools)
7. [Clone Project and Get Started](#clone-project-and-get-started)
8. [Verify Installation](#verify-installation)
9. [Troubleshooting](#troubleshooting)

---

## System Requirements

### Minimum Requirements:
- **Ubuntu 20.04 LTS** or newer
- **4 GB RAM** (recommended: 8 GB)
- **10 GB Disk Space** (for all tools)
- **Stable Internet Connection**

### Essential Tools Needed:
- Terminal/Console
- Git
- curl or wget
- Text Editor or IDE

---

## System Update

Before starting, update your system:

```bash
# Update package list
sudo apt update

# Upgrade installed packages
sudo apt upgrade -y

# Install essential tools
sudo apt install -y build-essential curl wget git
```

**Explanation:**
- `build-essential`: Contains basic build and compilation tools
- `curl` and `wget`: For downloading files from the internet
- `git`: For cloning and version control

---

## Install .NET 10 SDK

### Recommended Method: Using Microsoft Repository

```bash
# 1. Import Microsoft signing key
wget https://packages.microsoft.com/keys/microsoft.asc -O microsoft.asc
sudo apt-key add microsoft.asc

# 2. Add Microsoft Repository
sudo apt-add-repository https://packages.microsoft.com/ubuntu/$(lsb_release -cs)/prod

# 3. Update package list
sudo apt update

# 4. Install .NET 10 SDK
sudo apt install -y dotnet-sdk-10.0

# 5. Verify installation
dotnet --version
# Should display: 10.0.x
```

### Alternative Method: Using dotnet-install.sh

If the first method doesn't work:

```bash
# 1. Download installation script
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh

# 2. Install .NET 10
./dotnet-install.sh --channel 10.0 --install-dir $HOME/.dotnet

# 3. Add .NET to PATH
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc

# 4. Update current environment
source ~/.bashrc

# 5. Verify installation
dotnet --version
```

### Install ASP.NET Core Runtime (Optional):

```bash
# If you want to develop web applications too
sudo apt install -y aspnetcore-runtime-10.0
```

---

## Install VS Code

### Recommended Method: From Microsoft Repository

```bash
# 1. Import signing key
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > packages.microsoft.gpg
sudo install -o root -g root -m 644 packages.microsoft.gpg /etc/apt/trusted.gpg.d/

# 2. Add VS Code Repository
echo "deb [arch=amd64,arm64,armhf signed-by=/etc/apt/trusted.gpg.d/packages.microsoft.gpg] https://packages.microsoft.com/repos/code stable main" | sudo tee /etc/apt/sources.list.d/vscode.list > /dev/null

# 3. Update package list
sudo apt update

# 4. Install VS Code
sudo apt install -y code

# 5. Verify installation
code --version
```

### Alternative Method: From Ubuntu Repository

```bash
# Install VS Code from Ubuntu repo
sudo apt install -y code

# Or from Snap
sudo snap install code --classic
```

### Open VS Code from Terminal

```bash
# Open VS Code in current directory
code .

# Open specific file
code filename.cs

# Open specific folder
code /path/to/folder
```

---

## Install Required Extensions

After installing VS Code, install the following extensions:

### Method 1: From VS Code GUI

1. Open VS Code
2. Press `Ctrl + Shift + X` to open Extensions Marketplace
3. Search for and install these extensions:

#### Essential Extensions (Required):
- **C# Dev Kit** - Microsoft (Official)
- **.NET Install Tool** - Microsoft
- **C#** - Microsoft

#### Recommended Extensions (Optional but helpful):
- **C# Extensions** - jchannon
- **IntelliCode** - Microsoft
- **REST Client** - Huachao Mao
- **GitLens** - GitLens
- **Prettier** - Prettier
- **Markdown Preview Enhanced** - Yiyi Wang
- **Thunder Client** - Thunder Client
- **Docker** - Microsoft (if using Docker)

### Method 2: From Terminal

```bash
# Install extensions from command line
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.dotnet-interactive-vscode
code --install-extension ms-dotnettools.vscode-dotnet-runtime
code --install-extension jchannon.csharpextensions
code --install-extension ms-vscode.IntelliCode
code --install-extension humao.rest-client
code --install-extension eamodio.gitlens
```

### Verify Installed Extensions

```bash
# List all installed extensions
code --list-extensions
```

---

## Install Additional Tools

### 1. Git (If Not Already Installed)

```bash
# Check if Git is installed
git --version

# Install Git if needed
sudo apt install -y git

# Configure Git
git config --global user.name "Your Full Name"
git config --global user.email "your.email@example.com"
git config --global core.editor "nano"

# Verify configuration
git config --global --list
```

### 2. Docker (Optional - For Deployment)

```bash
# Install Docker
sudo apt install -y docker.io docker-compose

# Add current user to docker group
sudo usermod -aG docker $USER

# Apply group change
newgrp docker

# Verify installation
docker --version
docker-compose --version
```

### 3. Performance Monitoring Tools

```bash
# Install htop (resource monitor)
sudo apt install -y htop

# top comes pre-installed with Linux

# Use htop:
htop
```

### 4. Node.js and npm (Optional - For Additional Tools)

```bash
# Install Node.js and npm
sudo apt install -y nodejs npm

# Verify installation
node --version
npm --version

# Update npm
sudo npm install -g npm@latest
```

### 5. JetBrains Rider (Optional - Professional IDE)

```bash
# Install via snap (easiest way)
sudo snap install rider --classic

# Or download from official website
https://www.jetbrains.com/rider/
```

---

## Clone Project and Get Started

### Step 1: Clone the Repository

```bash
# Navigate to desired directory
cd ~
mkdir -p Projects
cd Projects

# Clone the project
git clone https://github.com/habitakatrennada/analog-prayer-timer.git

# Enter project directory
cd analog-prayer-timer

# View project structure
ls -la
```

### Step 2: Open Project in VS Code

```bash
# Open the project
code .
```

Or manually open VS Code, select `File > Open Folder`, and choose the project folder.

### Step 3: Restore Dependencies

```bash
# Restore all required NuGet packages
dotnet restore

# Build the project
dotnet build
```

### Step 4: Run the Project

```bash
# Basic run
dotnet run

# Run with file watcher (Hot Reload)
dotnet watch run

# Run without building (if already built)
dotnet run --no-build
```

### Step 5: Create Release Build (Optional)

```bash
# Create Release build
dotnet publish -c Release -o ./publish

# Run Release build
./publish/AnalogPrayerTimer
```

---

## Verify Installation

### Check Each Component:

```bash
# Check Ubuntu version
lsb_release -a

# Check Git
git --version

# Check .NET SDK
dotnet --version

# Check VS Code
code --version

# Check Node.js (optional)
node --version
npm --version

# Check Docker (optional)
docker --version
```

### Test .NET with Simple Project

```bash
# Create test project
dotnet new console -n test-app
cd test-app

# Run project
dotnet run

# Should display "Hello, World!"
```

---

## Troubleshooting

### Issue 1: .NET SDK Not Found

**Symptoms:** Running `dotnet --version` shows "command not found"

**Solution:**

```bash
# Check PATH
echo $PATH

# Add .NET to PATH (if using dotnet-install.sh)
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc

# Or use full path
$HOME/.dotnet/dotnet --version
```

### Issue 2: VS Code Doesn't Recognize C#

**Symptoms:** No IntelliSense or code suggestions

**Solution:**

```bash
# Reopen VS Code
code .

# Press Ctrl + Shift + P and search for:
# "Developer: Reload Window"

# Or reinstall C# Dev Kit
code --install-extension ms-dotnettools.csharp
```

### Issue 3: Permission Denied During Installation

**Symptoms:** Error messages related to permissions

**Solution:**

```bash
# Use sudo when needed
sudo apt install -y package-name

# Or use sudo interactive mode
sudo -i
```

### Issue 4: GitHub Connection Issues

**Symptoms:** Failed to clone repository

**Solution:**

```bash
# Check connection
ping github.com

# Retry cloning with HTTPS
git clone https://github.com/habitakatrennada/analog-prayer-timer.git

# Or setup SSH (if previously used)
ssh-keygen -t ed25519 -C "your.email@example.com"
cat ~/.ssh/id_ed25519.pub
# Add this key to GitHub Settings
```

### Issue 5: High Resource Consumption

**Symptoms:** VS Code running very slowly

**Solution:**

```bash
# Disable unnecessary extensions
# Press Ctrl + Shift + X in VS Code and disable unused extensions

# Monitor resources
htop

# Use Terminal instead of VS Code UI
dotnet run
dotnet watch run
```

### Issue 6: File Permission Issues

**Symptoms:** Error messages when writing to files

**Solution:**

```bash
# Fix folder permissions
chmod -R 755 ~/Projects/analog-prayer-timer

# Or fix file ownership
chown -R $USER:$USER ~/Projects/analog-prayer-timer
```

---

## Effective Working Tips

### 1. Use Git Properly

```bash
# Create new branch for features
git checkout -b feature/my-feature

# Check status
git status

# Stage changes
git add .

# Create commit
git commit -m "Add new feature"

# Push changes
git push origin feature/my-feature
```

### 2. Use .gitignore

```bash
# Check gitignore file
cat .gitignore

# Ignore important files (bin, obj, etc.)
echo "bin/" >> .gitignore
echo "obj/" >> .gitignore
echo ".vs/" >> .gitignore
```

### 3. Use Helpful VS Code Shortcuts

| Shortcut | Function |
|----------|----------|
| `Ctrl + Shift + P` | Open Command Palette |
| `Ctrl + K Ctrl + S` | Show Keyboard Shortcuts |
| `F5` | Start Debugging |
| `Ctrl + Shift + B` | Build Project |
| `Ctrl + Shift + D` | Go to Debug View |
| `Ctrl + `` | Open Terminal |
| `Ctrl + L` | Select Entire Line |

### 4. Use Debugging

```csharp
// Click on line number to set breakpoint
// Or press F9

// Press F5 to start debugging
```

### 5. Read Logs and Errors

```bash
# View build logs
dotnet build 2>&1 | tee build.log

# Search for errors
grep -i "error" build.log
```

---

## Next Steps

After completing setup:

1. ✅ Read [README.md](./README.md) for more information
2. ✅ Explore project structure
3. ✅ Run the project: `dotnet run`
4. ✅ Try modifying code and running again
5. ✅ Read code comments to understand how it works

---

## Useful Resources

### Official Resources:
- [Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [VS Code Documentation](https://code.visualstudio.com/docs)
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)

### Learning Platforms:
- [Microsoft Learn](https://learn.microsoft.com/)
- [tutorialspoint C#](https://www.tutorialspoint.com/csharp/index.htm)
- [w3schools C#](https://www.w3schools.com/cs/)

### Communities:
- [GitHub Discussions](https://github.com/habitakatrennada/analog-prayer-timer/discussions)
- [GitHub Issues](https://github.com/habitakatrennada/analog-prayer-timer/issues)

---

## Feedback and Suggestions

If you encounter issues or have suggestions:

- 📝 Open an [Issue](https://github.com/habitakatrennada/analog-prayer-timer/issues)
- 💬 Join [Discussions](https://github.com/habitakatrennada/analog-prayer-timer/discussions)
- 🔀 Submit a [Pull Request](https://github.com/habitakatrennada/analog-prayer-timer/pulls)

---

**Last Updated:** June 2026
**Environment:** Ubuntu 22.04 LTS + .NET 10 + VS Code

🎉 Welcome to Ubuntu development!
