# ⏰ مشروع Analog Prayer Timer

هذا الملف هو دليل العمل الرئيسي باللغة العربية للمشروع على نظام **Ubuntu**.

## لماذا هذا المشروع؟
- الهدف هو تعليم أولادك البرمجة بطريقة مباشرة وبسيطة.
- نركز على **لغة C#** و**بيئة .NET** و**بيئة التطوير على Ubuntu**.
- نبتعد عن التفاصيل المعقدة مثل Docker أو تحسينات الأداء المتقدمة.
- نرسم خطة عمل ووثائق يمكن للطالب أن يتابعها خطوة خطوة.

## ما الذي سنفعله هنا؟
1. إعداد بيئة التطوير على Ubuntu.
2. تثبيت الأدوات الأساسية: Git، VS Code، .NET 10.
3. فتح المشروع والتعرف على الملفات الرئيسية.
4. تشغيل التطبيق ومشاهدة النتائج.
5. فهم منطق حساب أوقات الصلاة والبرمجة الخاصة به.

## بيئة العمل المطلوبة
- نظام **Ubuntu 20.04** أو أحدث
- **Visual Studio Code**
- **.NET 10 SDK**
- **Terminal**
- **Git**

## خطوات إعداد البيئة (Ubuntu)

### 1. تحديث النظام
```bash
sudo apt update
sudo apt upgrade -y
```

### 2. تثبيت الأدوات الأساسية
```bash
sudo apt install -y git curl wget code
```

### 3. تثبيت .NET 10 SDK
```bash
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 10.0
```

### 4. إضافة .NET إلى مسار النظام
```bash
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc
```

### 5. التحقق من التثبيت
```bash
dotnet --version
```

## تثبيت إضافات VS Code المهمة
- **C# Dev Kit**
- **.NET Install Tool**
- **C#**
- **C# Extensions**
- **IntelliCode**

يمكنك تثبيتها من داخل VS Code أو من الطرفية:
```bash
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.dotnet-interactive-vscode
code --install-extension ms-dotnettools.vscode-dotnet-runtime
code --install-extension jchannon.csharpextensions
code --install-extension ms-vscode.IntelliCode
```

## فتح المشروع وتشغيله
```bash
git clone https://github.com/habitakatrennada/analog-prayer-timer.git
cd analog-prayer-timer
code .
```

ثم من داخل VS Code، افتح الطرفية وشغّل:
```bash
dotnet run
```

## الملفات الرئيسية التي ندرسها
- `Program.cs`
- `PrayerCalculations/PrayerTimeCalculator.cs`
- `Models/PrayerTime.cs`
- `Models/Location.cs`

## ماذا نتعلم من هذا المشروع؟
- كيف نكتب دوال في C#.
- كيف نقرأ بيانات ونطبعها على الشاشة.
- كيف نستخدم التواريخ والأوقات.
- كيف نحسب أوقات الصلاة بطريقة مبسطة وتعلمية.

## خطة العمل وسجل التقدم
نستطيع متابعة خطة العمل في ملف `PLAN.md`.

### نقاط مهمة في README
- هذا الملف هو الدليل الأساسي للعائلة.
- الهدف هو التعلم البسيط والمباشر.
- نتجنب التفاصيل التي لا تحتاجها المرحلة الأولى.

## ملاحظة
إذا كان هناك أي تغيير في الخطوات أو أي إضافة جديدة، فسنسجلها في `PLAN.md` ونعرضها هنا لاحقاً.

## العمل المباشر الآن
لقد بدأنا الآن العمل المباشر في المشروع.

- تم إنشاء مشروع C# بسيط في المسار الحالي.
- افتح `Program.cs` لبدء القراءة.
- سيعرض التطبيق أوقات صلاة نموذجية بناءً على وقت الظهر.
- يمكن تعديل القيم في `Program.cs` لتعلم كيفية تغيير النتائج.
