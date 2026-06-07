# 📋 دليل إعداد بيئة التطوير على Ubuntu

هذا الدليل يساعدك على إعداد بيئة البرمجة على **Ubuntu** لمشروع **Analog Prayer Timer**.

## ماذا تحتاج
- نظام **Ubuntu 20.04** أو أحدث
- **Git**
- **Visual Studio Code**
- **.NET 10 SDK**
- **Terminal**

## 1. تحديث النظام

```bash
sudo apt update
sudo apt upgrade -y
```

## 2. تثبيت الأدوات الأساسية

```bash
sudo apt install -y git curl wget code
```

## 3. تثبيت .NET 10 SDK

استخدم سكريبت التثبيت الرسمي:

```bash
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 10.0
```

ثم أضف .NET إلى المسار:

```bash
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc
```

تحقق من التثبيت:

```bash
dotnet --version
```

## 4. تثبيت إضافات VS Code

افتح VS Code وثبّت هذه الإضافات:
- **C# Dev Kit**
- **.NET Install Tool**
- **C#**
- **C# Extensions**
- **IntelliCode**

أو من الطرفية:

```bash
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.dotnet-interactive-vscode
code --install-extension ms-dotnettools.vscode-dotnet-runtime
code --install-extension jchannon.csharpextensions
code --install-extension ms-vscode.IntelliCode
```

## 5. استنساخ المشروع وفتحه

```bash
git clone https://github.com/habitakatrennada/analog-prayer-timer.git
cd analog-prayer-timer
code .
```

## 6. تشغيل المشروع

استخدم الطرفية داخل VS Code:

```bash
dotnet run
```

## ما يجب التركيز عليه
- تعلم **المنطق البرمجي** في C#.
- افتح `PrayerCalculations/PrayerTimeCalculator.cs`.
- افتح `UI/MainWindow.xaml`.
- غيّر قيمة وشاهد النتيجة.

## هيكل المشروع البسيط

```
analog-prayer-timer/
├── PrayerCalculations/
├── UI/
├── Models/
└── Program.cs
```

## ملاحظة
هذا الدليل يركز على إعداد بيئة Ubuntu والبرمجة المباشرة. لا يشمل Docker أو تفاصيل الأداء المتقدمة.
