# ⏰ برنامج مواقيت الصلاة - Analog Prayer Timer

![License](https://img.shields.io/badge/License-MIT-green)
![Platform](https://img.shields.io/badge/Platform-Cross--Platform-blue)
![Language](https://img.shields.io/badge/Language-C%23-.NET-purple)

---

## 🌙 ما هو هذا البرنامج؟

برنامج تعليمي بسيط وجميل يساعدك على معرفة **مواقيت الصلوات الخمس** في يومك بكل دقة وسهولة! 

البرنامج يحسب أوقات:
- ✨ **الفجر** - يبدأ من طلوع الفجر
- ☀️ **الشروق** - عند شروق الشمس
- 🌤️ **الظهر** - عند زوال الشمس
- 🌅 **العصر** - في فترة العصر
- 🌆 **المغرب** - عند غروب الشمس
- 🌙 **العشاء** - بعد اختفاء الشفق

كل هذا **وفق آراء جمهور أهل السنة والجماعة** وفي توافق كامل مع المذاهب الأربعة! 🕌

---

## 💻 البيئة التقنية

| المكون | التفاصيل |
|--------|---------|
| **اللغة** | C# 🎯 |
| **البيئة** | Microsoft .NET 10+ |
| **الأطر** | MAUI |
| **قواعد البيانات** | SQLite / Azure |
| **المنصات المدعومة** | Linux 🐧 • Windows 🪟 • macOS 🍎 • iOS 📱 • Android 📱 |

> **لماذا C# و .NET 10 مع MAUI؟**
> - ✅ سهلة التعلم والفهم
> - ✅ آمنة وموثوقة
> - ✅ تعمل على كل الأجهزة المدعومة
> - ✅ أداء عالي جداً
> - ✅ مناسبة للتطبيقات التعليمية
> - ✅ .NET 10 يوفر أفضل دعم متعدد المنصات مع MAUI

---

## 🎯 المميزات الأساسية

### 🔷 واجهة بسيطة وجذابة
- تصميم ملون وسهل الاستخدام للأطفال
- ساعة تناظرية جميلة تعرض الأوقات
- رسومات ملهمة وموضيحة

### 🔷 دقة عالية جداً
- حسابات فلكية دقيقة جداً
- حسابات زاوية الارتفاع الشمسي
- أخذ الموقع الجغرافي في الاعتبار (العرض والطول)

### 🔷 سهل الاستخدام
```
✓ اختر المدينة أو أدخل موقعك
✓ شاهد أوقات الصلاة لليوم
✓ اضبط المنبهات للتنبيهات
✓ احفظ تفضيلاتك
```

### 🔷 تعليمي بنسبة 100%
- **شرح لكل وقت** - لماذا هذا الوقت؟
- **تاريخ الحسابات** - كيف نحسب أوقات الصلاة؟
- **تعلم البرمجة** - الكود سهل ومشروح

---

## 🚀 كيفية البدء على Ubuntu

### ⚠️ متطلبات النظام

| المكون | الحد الأدنى | الموصى به |
|--------|:----------:|:---------:|
| **RAM** | 4 GB | 8+ GB |
| **CPU** | 2 Cores | 4+ Cores |
| **Disk** | 10 GB | 20+ GB |
| **OS** | Ubuntu 20.04+ | Ubuntu 22.04 LTS أو أحدث |

### 🛠️ خيارات التثبيت على Ubuntu حسب إمكانيات جهازك

#### **خيار 1️⃣: VS Code + .NET SDK (الخيار الأفضل والموصى به) ⭐**

```bash
# خفيف جداً على موارد النظام
# RAM: 2-3 GB فقط
# Disk: 1 GB فقط

# 1. تحديث قوائم الحزم
sudo apt update && sudo apt upgrade -y

# 2. تثبيت المتطلبات الأساسية
sudo apt install -y git curl wget

# 3. تثبيت .NET 10 SDK
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 10.0

# إضافة .NET إلى المسار
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc

# التحقق من التثبيت
dotnet --version

# 4. تثبيت VS Code
sudo apt install -y code

# 5. تثبيت الإضافات المهمة في VS Code:
#    - C# Dev Kit
#    - .NET Install Tool
#    - C# Extensions

# 6. استنساخ المشروع
git clone https://github.com/habitakatrennada/analog-prayer-timer.git
cd analog-prayer-timer

# 7. فتح VS Code
code .

# 8. تشغيل المشروع (Ctrl + `) لفتح Terminal
dotnet run
```

#### **خيار 2️⃣: Visual Studio Code + Terminal (الخيار الخفيف جداً) 🚀**

```bash
# الأخف على موارد النظام!
# RAM: 1-2 GB فقط
# Disk: 500 MB

# 1. تثبيت .NET 10 SDK (انظر الخطوات أعلاه)

# 2. استنساخ المشروع
git clone https://github.com/habitakatrennada/analog-prayer-timer.git
cd analog-prayer-timer

# 3. تشغيل البرنامج مباشرة
dotnet run

# 4. لتشغيل بدون بناء
dotnet run --no-build

# 5. لإنشاء Release Build
dotnet publish -c Release -o ./publish
```

#### **خيار 3️⃣: سطر الأوامر (Terminal فقط) - الأخف بلا GUI**

```bash
# للأجهزة الضعيفة جداً
# RAM: 1 GB فقط
# Disk: 100 MB

# 1. تثبيت .NET 10 SDK

# 2. استنساخ المشروع
git clone https://github.com/habitakatrennada/analog-prayer-timer.git
cd analog-prayer-timer

# 3. تشغيل المشروع
dotnet run

# 4. لمراقب�� الأداء أثناء التطوير
dotnet watch run
```

#### **خيار 4️⃣: JetBrains Rider (للمحترفين)**

```bash
# محرر احترافي ومتقدم
# RAM: 4+ GB
# Disk: 2+ GB

# 1. تثبيت Rider (نسخة مدفوعة أو تجريبية)
https://www.jetbrains.com/rider/

# أو عبر snap:
sudo snap install rider --classic

# 2. فتح المشروع
rider analog-prayer-timer

# 3. تشغيل: Ctrl + F10
```

---

## 📊 مقارنة الأدوات على Ubuntu حسب موارد الجهاز

| الأداة | RAM المطلوب | CPU | Disk | الأداء | الموصى به |
|--------|:----------:|:---:|:----:|:------:|:---------:|
| **VS Code + .NET** | 2-3 GB | خفيف | 1 GB | ⚡⚡⚡ سريع جداً | ✅ موصى به |
| **Terminal/CLI** | 1 GB | خفيف | 100 MB | ⚡⚡⚡⚡ الأسرع | ✅ للأجهزة الضعيفة |
| **Visual Studio Code + Extensions** | 2 GB | خفيف | 800 MB | ⚡⚡⚡ سريع | ✅ ممتاز |
| **JetBrains Rider** | 4+ GB | متوسط | 2+ GB | ⚡⚡ متوسط | ⭐ للمحترفين |

---

## 🔧 الأدوات المفيدة على Ubuntu

### أدوات التطوير الأساسية

```bash
# تثبيت أدوات البناء والتطوير
sudo apt install -y build-essential git curl

# تثبيت Git (إن لم يكن مثبتاً)
sudo apt install -y git
git config --global user.name "اسمك"
git config --global user.email "بريدك@example.com"

# تثبيت Node.js (اختياري، للأدوات الإضافية)
sudo apt install -y nodejs npm

# تثبيت Docker (اختياري، للنشر)
sudo apt install -y docker.io docker-compose
```

### مراقبة الأداء أثناء التطوير

```bash
# تشغيل مراقب الموارد
# استخدم Ctrl+Shift+Esc في سطح المكتب، أو:
sudo apt install -y htop
htop

# أو استخدم top:
top
```

---

## 📁 هيكل المشروع

```
analog-prayer-timer/
├── 📂 PrayerCalculations/
│   ├── 📜 PrayerTimeCalculator.cs
│   ├── 📜 SolarPosition.cs
│   └── 📜 LocationData.cs
│
├── 📂 UI/
│   ├── 🖼️ MainWindow.xaml
│   ├── 📜 MainWindow.xaml.cs
│   └── 📂 Controls/
│       ├── 🎨 AnalogClock.xaml
│       └── 📊 PrayerTimesDisplay.xaml
│
├── 📂 Models/
│   ├── 📜 PrayerTime.cs
│   ├── 📜 Location.cs
│   └── 📜 DateData.cs
│
├── 📂 Services/
│   ├── 📜 LocationService.cs
│   ├── 📜 NotificationService.cs
│   └── 📜 StorageService.cs
│
└── 📜 Program.cs

```

---

## 💡 الدروس المستفادة من البرنامج

هذا المشروع يعلمك:

| الدرس | الوصف |
|------|-------|
| **الرياضيات** 🔢 | حسابات مثلثية وزوايا شمسية |
| **الجغرافيا** 🗺️ | استخدام خطوط الطول والعرض |
| **البرمجة** 💻 | تصميم التطبيقات واجهات المستخدم |
| **الدين** 🕌 | فهم أعمق لأوقات الصلاة الشرعية |
| **البيانات** 📊 | التعامل مع قواعد البيانات |

---

## 📊 مثال على الحسابات

```csharp
// كود بسيط لحساب وقت الظهر
public DateTime CalculateDhuhr(DateTime date, Location location)
{
    // حساب زاوية الشمس (التشريح)
    double julianDay = GetJulianDay(date);
    double solarDeclination = CalculateSolarDeclination(julianDay);
    
    // وقت الزوال (عندما تكون الشمس في أعلى نقطة)
    double noonTime = CalculateSolarNoon(location.Longitude, julianDay);
    
    return ConvertToDateTime(date, noonTime);
}
```

---

## 🎨 الواجهة المستخدم

### الشاشة الرئيسية
```
┌─────────────────────────────┐
│  🕌 مواقيت الصلاة اليوم    │
├─────────────────────────────┤
│                             │
│        🌙 الفجر 05:15      │
│        ☀️ الشروق 06:45      │
│        🌤️ الظهر 12:30      │
│        🌅 العصر 16:00      │
│        🌆 المغرب 18:45      │
│        🌙 العشاء 20:15      │
│                             │
│  [⏰ منبه]  [⚙️ إعدادات]   │
└─────────────────────────────┘
```

---

## 📱 المنصات المدعومة

يدعم البرنامج المنصات التالية باستخدام **.NET MAUI**:

| المنصة | النوع | الحالة | ملاحظات |
|--------|-------|--------|---------|
| **Linux** | سطح المكتب | ✅ مدعوم | Ubuntu 20.04+ و Fedora وغيره |
| **Windows** | سطح المكتب | ✅ مدعوم | Windows 10+ |
| **macOS** | سطح المكتب | ✅ مدعوم | macOS 12+ |
| **iOS** | الهاتف | ✅ مدعوم | iOS 14+ |
| **Android** | الهاتف | ✅ مدعوم | Android 8+ |

> **ملاحظة:** MAUI لا يدعم رسمياً Web حالياً. إذا كنت تحتاج لتطبيق ويب، راجع الخيارات البديلة في القسم التالي.

---

## 🔄 خيارات لدعم Web و Linux بشكل أوسع

إذا أردت توسيع دعم التطبيق ليشمل **Web** و **Linux** بشكل أوسع، يمكنك استخدام:

### 🔷 **Blazor** (للويب)
```csharp
// تطبيق ويب تفاعلي باستخدام C# و Blazor WebAssembly
```

### 🔷 **Avalonia UI** (بديل شامل)
- يدعم: Windows, macOS, Linux, iOS, Android, Web
- مشابه لـ MAUI لكن مع دعم أوسع

### 🔷 **Uno Platform** (بديل شامل)
- يدعم: Windows, macOS, Linux, iOS, Android, Web
- أكثر نضجاً وتطويراً

---

## 🙏 الالتزام الشرعي

البرنامج يتبع:
- ✅ مذهب **الحنفية**
- ✅ مذهب **المالكية**
- ✅ مذهب **الشافعية**
- ✅ مذهب **الحنابلة**

وفي توافق مع رأي جمهور أهل السنة والجماعة في العالم الإسلامي.

---

## 👨‍💻 ملاحظات للآباء المبرمجين

هذا المشروع مصمم ليكون:
- 📚 **بسيط** - لكن ليس بسيط جداً
- 🎯 **عملي** - يمكن تطبيقه فوراً
- 🧠 **تعليمي** - يعلم مفاهيم حقيقية
- 🎨 **جذاب** - يشجع الأطفال على التعلم

يمكنك تعديله وإضافة مميزات جديدة معهم!

---

## 🔧 الخطوات التالية

- [ ] تحديث نظام Ubuntu
- [ ] تثبيت .NET 10 SDK
- [ ] تثبيت VS Code والإضافات
- [ ] استنساخ المشروع وتشغيله
- [ ] إضافة مدينتك
- [ ] تخصيص المظهر
- [ ] إضافة منبهات

---

## 📝 الترخيص

هذا المشروع مرخص تحت **MIT License** - استخدمه بحرية! 📜

---

## 🤝 المساهمة

هل تريد إضافة مميزة جديدة؟ رائع! 🌟

1. عدّل الكود
2. جرب التغييرات
3. أرسل Pull Request
4. سنراجعه معاً!

---

## 📧 التواصل والدعم

- **GitHub Issues**: لأي مشكلة أو اقتراح
- **Discussions**: للنقاش والأسئلة التعليمية

---

## 🌟 شكراً لاستخدامك البرنامج!

**برمج الخير وشارك العلم!** 💻🕌

```
"العلم نور والجهل ظلام"
```

---

**آخر تحديث:** يونيو 2026
**الإصدار:** 1.0.0
**البيئة المفضلة:** Ubuntu 22.04 LTS مع VS Code و .NET 10

⭐ إذا أعجبك المشروع، لا تنسَ أن تعطيه ⭐!
