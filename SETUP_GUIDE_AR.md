# 📋 دليل تحضير البيئة والنظام - Setup Guide for Ubuntu

هذا الدليل الشامل يساعدك على تحضير بيئة التطوير الكاملة للعمل على مشروع **Analog Prayer Timer** على نظام **Ubuntu**.

---

## 📑 جدول المحتويات

1. [المتطلبات الأساسية](#المتطلبات-الأساسية)
2. [تحديث النظام](#تحديث-النظام)
3. [تثبيت .NET 10 SDK](#تثبيت-net-10-sdk)
4. [تثبيت VS Code](#تثبيت-vs-code)
5. [تثبيت الإضافات المطلوبة](#تثبيت-الإضافات-المطلوبة)
6. [تثبيت أدوات إضافية](#تثبيت-أدوات-إضافية)
7. [استنساخ المشروع والبدء](#استنساخ-المشروع-والبدء)
8. [التحقق من التثبيت](#التحقق-من-التثبيت)
9. [استكشاف الأخطاء والمشاكل الشائعة](#استكشاف-الأخطاء-والمشاكل-الشائعة)

---

## المتطلبات الأساسية

### المتطلبات الدنيا:
- **Ubuntu 20.04 LTS** أو أحدث
- **4 GB RAM** (موصى به: 8 GB)
- **10 GB مساحة القرص** (لتثبيت كل الأدوات)
- **اتصال إنترنت مستقر**

### الأدوات الأساسية المطلوبة:
- Terminal/Console
- Git
- curl أو wget
- محرر نصوص أو IDE

---

## تحديث النظام

قبل البدء، من المهم تحديث نظامك:

```bash
# تحديث قائمة الحزم
sudo apt update

# ترقية الحزم المثبتة
sudo apt upgrade -y

# تثبيت الأدوات الأساسية
sudo apt install -y build-essential curl wget git
```

**التوضيح:**
- `build-essential`: يحتوي على أدوات البناء والتجميع الأساسية
- `curl` و `wget`: لتحميل الملفات من الإنترنت
- `git`: لنسخ والتحكم في إصدارات المشروع

---

## تثبيت .NET 10 SDK

### الطريقة الموصى بها: استخدام Microsoft Repository

```bash
# 1. استيراد مفتاح التوقيع من Microsoft
wget https://packages.microsoft.com/keys/microsoft.asc -O microsoft.asc
sudo apt-key add microsoft.asc

# 2. إضافة Microsoft Repository
sudo apt-add-repository https://packages.microsoft.com/ubuntu/$(lsb_release -cs)/prod

# 3. تحديث قائمة الحزم
sudo apt update

# 4. تثبيت .NET 10 SDK
sudo apt install -y dotnet-sdk-10.0

# 5. التحقق من التثبيت
dotnet --version
# يجب أن تراها: 10.0.x
```

### الطريقة البديلة: استخدام dotnet-install.sh

إذا لم تنجح الطريقة الأولى:

```bash
# 1. تحميل سكريبت التثبيت
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh

# 2. تثبيت .NET 10
./dotnet-install.sh --channel 10.0 --install-dir $HOME/.dotnet

# 3. إضافة .NET إلى المسار
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc

# 4. تحديث البيئة الحالية
source ~/.bashrc

# 5. التحقق من التثبيت
dotnet --version
```

### تثبيت ASP.NET Core Runtime (اختياري):

```bash
# إذا كنت تريد تطوير تطبيقات ويب أيضاً
sudo apt install -y aspnetcore-runtime-10.0
```

---

## تثبيت VS Code

### الطريقة الموصى بها: من Microsoft Repository

```bash
# 1. استيراد مفتاح التوقيع
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > packages.microsoft.gpg
sudo install -o root -g root -m 644 packages.microsoft.gpg /etc/apt/trusted.gpg.d/

# 2. إضافة VS Code Repository
echo "deb [arch=amd64,arm64,armhf signed-by=/etc/apt/trusted.gpg.d/packages.microsoft.gpg] https://packages.microsoft.com/repos/code stable main" | sudo tee /etc/apt/sources.list.d/vscode.list > /dev/null

# 3. تحديث قائمة الحزم
sudo apt update

# 4. تثبيت VS Code
sudo apt install -y code

# 5. التحقق من التثبيت
code --version
```

### الطريقة البديلة: من Ubuntu Repository

```bash
# تثبيت VS Code الرسمي من Ubuntu
sudo apt install -y code

# أو من Snap
sudo snap install code --classic
```

### فتح VS Code من Terminal

```bash
# فتح VS Code في المجلد الحالي
code .

# فتح ملف معين
code filename.cs

# فتح بمجلد معين
code /path/to/folder
```

---

## تثبيت الإضافات المطلوبة

بعد تثبيت VS Code، تحتاج إلى تثبيت الإضافات التالية:

### الطريقة 1: من واجهة VS Code

1. افتح VS Code
2. اضغط `Ctrl + Shift + X` لفتح Extensions Marketplace
3. ابحث عن الإضافات التالية وثبتها:

#### الإضافات الأساسية (مطلوبة):
- **C# Dev Kit** - Microsoft (المصرح الرسمي)
- **.NET Install Tool** - Microsoft
- **C#** - Microsoft

#### الإضافات الموصى بها (اختيارية لكن مفيدة جداً):
- **C# Extensions** - jchannon
- **IntelliCode** - Microsoft
- **REST Client** - Huachao Mao
- **GitLens** - GitLens
- **Prettier** - Prettier
- **Markdown Preview Enhanced** - Yiyi Wang
- **Arabic Support** - bysabi (لدعم اللغة العربية)

### الطريقة 2: من Terminal

```bash
# تثبيت الإضافات من سطر الأوامر
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.dotnet-interactive-vscode
code --install-extension ms-dotnettools.vscode-dotnet-runtime
code --install-extension jchannon.csharpextensions
code --install-extension ms-vscode.IntelliCode
code --install-extension humao.rest-client
code --install-extension eamodio.gitlens
```

### التحقق من الإضافات المثبتة

```bash
# عرض قائمة الإضافات المثبتة
code --list-extensions
```

---

## تثبيت أدوات إضافية

### 1. Git (إذا لم يكن مثبتاً)

```bash
# التحقق من وجود Git
git --version

# التثبيت إذا لم يكن موجوداً
sudo apt install -y git

# تكوين Git
git config --global user.name "اسمك الكامل"
git config --global user.email "بريدك@example.com"
git config --global core.editor "nano"

# التحقق من التكوين
git config --global --list
```

### 2. Docker (اختياري - للنشر والإنتاج)

```bash
# تثبيت Docker
sudo apt install -y docker.io docker-compose

# إضافة المستخدم الحالي لمجموعة docker
sudo usermod -aG docker $USER

# تفعيل التغيير
newgrp docker

# التحقق من التثبيت
docker --version
docker-compose --version
```

### 3. أدوات مراقبة الأداء

```bash
# تثبيت htop (مراقب الموارد)
sudo apt install -y htop

# تثبيت top (أداة سطر الأوامر)
# تأتي مع معظم توزيعات Linux بشكل افتراضي

# استخدام htop:
htop
```

### 4. Node.js و npm (اختياري - للأدوات الإضافية)

```bash
# تثبيت Node.js و npm
sudo apt install -y nodejs npm

# التحقق
node --version
npm --version

# تحديث npm
sudo npm install -g npm@latest
```

### 5. JetBrains Rider (اختياري - محرر احترافي)

```bash
# تثبيت عبر snap (الطريقة الأسهل)
sudo snap install rider --classic

# أو تحميل من الموقع الرسمي
https://www.jetbrains.com/rider/
```

---

## استنساخ المشروع والبدء

### الخطوة 1: استنساخ المشروع

```bash
# الانتقال إلى المجلد الذي تريد العمل فيه
cd ~
mkdir -p Projects
cd Projects

# استنساخ المشروع
git clone https://github.com/habitakatrennada/analog-prayer-timer.git

# الدخول إلى مجلد المشروع
cd analog-prayer-timer

# عرض هيكل المشروع
ls -la
```

### الخطوة 2: فتح المشروع في VS Code

```bash
# فتح المشروع
code .
```

أو افتح VS Code يدوياً واختر `File > Open Folder` وحدد مجلد المشروع.

### الخطوة 3: استعادة المتطلبات

```bash
# استعادة جميع حزم NuGet المطلوبة
dotnet restore

# بناء المشروع
dotnet build
```

### الخطوة 4: تشغيل المشروع

```bash
# التشغيل الأساسي
dotnet run

# التشغيل مع مراقب التغييرات (Hot Reload)
dotnet watch run

# التشغيل بدون بناء (إذا تم البناء مسبقاً)
dotnet run --no-build
```

### الخطوة 5: إنشاء Release Build (اختياري)

```bash
# بناء Release
dotnet publish -c Release -o ./publish

# تشغيل Release Build
./publish/AnalogPrayerTimer
```

---

## التحقق من التثبيت

### تحقق من كل مكون:

```bash
# التحقق من Ubuntu
lsb_release -a

# التحقق من Git
git --version

# التحقق من .NET SDK
dotnet --version

# التحقق من VS Code
code --version

# التحقق من Node.js (اختياري)
node --version
npm --version

# التحقق من Docker (اختياري)
docker --version
```

### اختبر .NET بمشروع بسيط

```bash
# إنشاء مشروع اختبار
dotnet new console -n test-app
cd test-app

# تشغيل المشروع
dotnet run

# يجب أن ترى "Hello, World!"
```

---

## استكشاف الأخطاء والمشاكل الشائعة

### المشكلة 1: .NET SDK لم يتم العثور عليه

**الأعراض:** عند تشغيل `dotnet --version` تظهر رسالة "command not found"

**الحل:**

```bash
# تحقق من المسار
echo $PATH

# إضافة .NET إلى المسار (إذا كنت تستخدم dotnet-install.sh)
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc

# أو استخدم المسار الكامل
$HOME/.dotnet/dotnet --version
```

### المشكلة 2: VS Code لا يتعرف على C#

**الأعراض:** عدم ظهور IntelliSense أو اقتراحات الكود

**الحل:**

```bash
# أعد فتح VS Code
code .

# اضغط Ctrl + Shift + P وابحث عن:
# "Developer: Reload Window"

# أو ثبت C# Dev Kit مجدداً
code --install-extension ms-dotnettools.csharp
```

### المشكلة 3: الإذن مرفوض عند التثبيت

**الأعراض:** رسائل خطأ تتعلق بالإذن عند استخدام sudo

**الحل:**

```bash
# تأكد من استخدام sudo عند الحاجة
sudo apt install -y package-name

# أو استخدم sudo password
sudo -i
```

### المشكلة 4: مشاكل الاتصال بـ GitHub

**الأعراض:** فشل استنساخ المشروع

**الحل:**

```bash
# تحقق من الاتصال
ping github.com

# إعادة محاولة الاستنساخ مع HTTP بدل SSH
git clone https://github.com/habitakatrennada/analog-prayer-timer.git

# أو إذا استخدمت SSH سابقاً:
ssh-keygen -t ed25519 -C "بريدك@example.com"
cat ~/.ssh/id_ed25519.pub
# ثم أضف هذا المفتاح إلى GitHub Settings
```

### المشكلة 5: استهلاك موارد عالي

**الأعراض:** بطء شديد عند العمل على VS Code

**الحل:**

```bash
# تعطيل الإضافات غير الضرورية
# اضغط Ctrl + Shift + X في VS Code وعطّل الإضافات غير المستخدمة

# تقليل استهلاك الموارد
htop  # راقب الموارد

# استخدم Terminal للعمل بدل VS Code UI
dotnet run
dotnet watch run
```

### المشكلة 6: مشاكل حقوق الوصول للملفات

**الأعراض:** رسائل خطأ عند الكتابة على الملفات

**الحل:**

```bash
# تعديل صلاحيات المجلد
chmod -R 755 ~/Projects/analog-prayer-timer

# أو إصلاح مالك الملفات
chown -R $USER:$USER ~/Projects/analog-prayer-timer
```

---

## نصائح للعمل الفعال

### 1. استخدم Git بشكل صحيح

```bash
# أنشئ فرع جديد للعمل
git checkout -b feature/my-feature

# راقب التغييرات
git status

# أضف التغييرات
git add .

# أنشئ commit
git commit -m "الرسالة بالعربية: إضافة مميزة جديدة"

# أرسل التغييرات
git push origin feature/my-feature
```

### 2. استخدم .gitignore

```bash
# تحقق من ملف .gitignore
cat .gitignore

# تجاهل الملفات المهمة (مثل bin و obj)
echo "bin/" >> .gitignore
echo "obj/" >> .gitignore
echo ".vs/" >> .gitignore
```

### 3. استخدم اختصارات VS Code المفيدة

| الاختصار | الفائدة |
|---------|--------|
| `Ctrl + Shift + P` | فتح Command Palette |
| `Ctrl + K Ctrl + S` | عرض اختصارات لوحة المفاتيح |
| `F5` | تشغيل Debug |
| `Ctrl + Shift + B` | بناء المشروع |
| `Ctrl + Shift + D` | الانتقال إلى Debug View |
| `Ctrl + `` | فتح Terminal |
| `Ctrl + L` | تحديد السطر بالكامل |

### 4. استخدم Debugging

```csharp
// ضع breakpoint بالنقر على الرقم بجانب السطر
// أو استخدم F9

// ثم استخدم F5 للتصحيح
```

### 5. اقرأ السجلات والأخطاء

```bash
# عرض السجلات
dotnet build 2>&1 | tee build.log

# البحث عن الأخطاء
grep -i "error" build.log
```

---

## الخطوات التالية

بعد انتهاء التثبيت:

1. ✅ اقرأ ملف [README.md](./README.md) للمزيد من المعلومات
2. ✅ استكشف هيكل المشروع
3. ✅ شغّل المشروع: `dotnet run`
4. ✅ جرّب تعديل الكود وتشغيل المشروع مجدداً
5. ✅ اقرأ التعليقات في الكود لفهم كيفية العمل

---

## موارد مفيدة

### الموارد الرسمية:
- [Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [VS Code Documentation](https://code.visualstudio.com/docs)
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)

### مواقع تعليمية:
- [Microsoft Learn](https://learn.microsoft.com/)
- [tutorialspoint C#](https://www.tutorialspoint.com/csharp/index.htm)
- [w3schools C#](https://www.w3schools.com/cs/)

### مجتمعات:
- [GitHub Discussions](https://github.com/habitakatrennada/analog-prayer-timer/discussions)
- [GitHub Issues](https://github.com/habitakatrennada/analog-prayer-timer/issues)

---

## التعليقات والاقتراحات

إذا واجهت أي مشاكل أو لديك اقتراحات:

- 📝 افتح [Issue](https://github.com/habitakatrennada/analog-prayer-timer/issues)
- 💬 شارك في [Discussions](https://github.com/habitakatrennada/analog-prayer-timer/discussions)
- 🔀 أرسل [Pull Request](https://github.com/habitakatrennada/analog-prayer-timer/pulls)

---

**آخر تحديث:** يونيو 2026
**البيئة:** Ubuntu 22.04 LTS + .NET 10 + VS Code

🎉 مرحباً بك في عالم تطوير البرمجيات على Ubuntu!
