# 💰 مدير المصاريف الذكي | Smart Budget

تطبيق مالي شخصي متعدد المنصات (Cross-Platform) مبني بأحدث إصدارات تقنيات مايكروسوفت **.NET 10** و **Avalonia UI**، يدعم العمل بكفاءة عالية على **سطح المكتب (Desktop)**، و**المتصفح عبر الويب أسيمبلي (WebAssembly - WASM)**، والسحابة عبر **GitHub Codespaces**، مع دعم كامل وأصيل للغة العربية واتجاه اليمين إلى اليسار (RTL).

---

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Avalonia UI](https://img.shields.io/badge/Avalonia%20UI-12.1.4-8E44AD?logo=avalonia&logoColor=white)](https://avaloniaui.net/)
[![EF Core](https://img.shields.io/badge/EF%20Core-9.0.22-blue)](https://learn.microsoft.com/ef/core/)
[![SQLite](https://img.shields.io/badge/SQLite-Database-003B57?logo=sqlite&logoColor=white)](https://sqlite.org/)
[![WebAssembly](https://img.shields.io/badge/WebAssembly-WASM-654FF0?logo=webassembly&logoColor=white)](https://webassembly.org/)
[![RTL Supported](https://img.shields.io/badge/Language-Arabic%20RTL-2ECC71)](#)

---

## 📑 فهرس المحتويات
1. [المميزات الرئيسية](#-المميزات-الرئيسية)
2. [التقنيات المستخدمة](#-التقنيات-المستخدمة)
3. [هيكل المشروع البرمجي](#-هيكل-المشروع-البرمجي)
4. [المتطلبات الأساسية](#-المتطلبات-الأساسية)
5. [طريقة التثبيت والتشغيل المحلي](#-طريقة-التثبيت-والتشغيل-المحلي)
6. [دليل التشغيل في GitHub Codespaces](#-دليل-التشغيل-في-github-codespaces)
7. [الحلول الهندسية لأبرز التحديات](#-الحلول-الهندسية-لأبرز-التحديات)
8. [خارطة الطريق والتطوير القادم (Roadmap)](#-خارطة-الطريق-والتطوير-القادم)

---

## 🌟 المميزات الرئيسية

### 1. إدارة العمليات المالية المتكاملة (CRUD)
- **تسجيل فوري:** إضافة العمليات المالية كـ "مصروف" أو "دخل" مع تسجيل العنوان، المبلغ، تاريخ المعاملة، التصنيف، وملاحظات إضافية.
- **تعديل سلس:** إمكانية تعديل أي معاملة سابقة بمجرد الضغط على زر التعديل وتعبئة النموذج تلقائياً.
- **حذف آمن:** نظام تأكيد الحذف عبر شريط تنبيه ملون يمنع الحذف بالخطأ ويطلب تأكيد المستخدم قبل المسح النهائي.

### 2. لوحة الإحصائيات الفورية (Live Analytics)
- بطاقات تفاعلية تعرض في الوقت الحقيقي:
  - **الرصيد الكلي المتبقي** (مجموع الدخل - مجموع المصاريف).
  - **إجمالي مصاريف الشهر الحالي** (مميز باللون الأحمر).
  - **إجمالي دخل الشهر الحالي** (مميز باللون الأخضر).
- تحديث تلقائي ولحظي للأرقام مع كل إضافة، تعديل، أو حذف لمعاملة.

### 3. بحث وفلترة فائقة السرعة بدون تأخير (Instant Live Search)
- **بحث فوري أثناء الكتابة:** تصفية القائمة فوراً بمجرد كتابة أول حرف في شريط البحث (في العنوان أو في الملاحظات).
- **فلترة سريعة بالتصنيف:** اختيار أي تصنيف لعرض معاملاته فقط، مع خيار "جميع التصنيفات".
- **زر إعادة الضبط:** مسح البحث والتصنيفات بضغطة زر واحدة واستعادة القائمة كاملة.

### 4. أيقونات متجهة نقية (Vector SVG Icons)
- الاعتماد بنسبة 100% على مسارات SVG متجهة مدمجة عبر عنصر `PathIcon` في Avalonia UI.
- استبدال رموز الإيموجي التقليدية لضمان ظهور أيقونات ناصعة وعالية الدقة في كافة البيئات بدون أي مربعات فارغة (`□`).

### 5. تصميم متجاوب وذكي (Adaptive Responsive UI)
- **على الشاشات الكبيرة (Desktop):** توزيع ذكي بعمودين (نموذج الإدخال على اليمين وسجل المعاملات على اليسار).
- **على الشاشات الصغيرة والمتوسطة (Mobile / Split Screen):** تحول تلقائي لنظام العمود الواحد المكدس مع بطاقات معاملات من سطرين تفصل العنوان والمبلغ عن التفاصيل والأزرار لمنع تداخل العناصر إطلاقاً.

### 6. دعم كامل وأصيل للغة العربية (Native RTL)
- تطبيق اتجاه الكتابة من اليمين إلى اليسار (`FlowDirection="RightToLeft"`).
- تضمين حزم خطوط `Segoe UI` كاملة كـ `AvaloniaResource` لضمان قراءة نصوص عربية واضحة في بيئة المتصفح وWebAssembly.

---

## 🛠 التقنيات المستخدمة

| التقنية / المكتبة | الإصدار | الاستخدام |
| :--- | :---: | :--- |
| **.NET SDK** | `10.0` | منصة التطوير الأساسية وبيئة التشغيل الحديثة |
| **Avalonia UI** | `12.1.4` | إطار بناء واجهات المستخدم الموحدة متعددة المنصات عبر XAML |
| **CommunityToolkit.Mvvm** | `8.4.2` | نمط التصميم الموحد MVVM مع مولدات الأكواد Source Generators |
| **Entity Framework Core** | `9.0.22` | طبقة الوصول للبيانات (ORM) والتعامل مع SQLite |
| **SQLite (e_sqlite3)** | `9.0.22` | محرك قاعدة البيانات الخفيف والمدمج للتخزين المحلي |
| **WebAssembly (WASM)** | `net10.0-browser` | تحويل التطبيق ليعمل داخل المتصفح بمحرك SkiaSharp |

---

## 📂 هيكل المشروع البرمجي

```text
MyFirstNetApp/
│
├── Directory.Packages.props          # الإدارة المركزية لحزم NuGet (Central Package Management)
├── .gitignore                        # استبعاد ملفات البناء والمخلفات المؤقتة
├── README.md                         # دليل وتوثيق المشروع
│
└── MyFirstApp/
    └── MyCrossApp/                   # مجلد حلول التطبيق متعدد المنصات
        │
        ├── MyCrossApp/               # 📦 المشروع المشترك الرئيسي (Core Library)
        │   ├── Assets/
        │   │   └── Fonts/            # الخطوط العربية المضمنة (segoeui.ttf, segoeuib.ttf)
        │   ├── Data/
        │   │   └── AppDbContext.cs   # سياق قاعدة البيانات EF Core وبذر التصنيفات
        │   ├── Helpers/
        │   │   └── AppIcons.cs       # مسارات SVG المتجهة لكافة الأيقونات
        │   ├── Models/
        │   │   ├── Category.cs       # كائن التصنيف (طعام، تسوق، مواصلات...)
        │   │   └── Transaction.cs    # كائن المعاملة المالية (العنوان، المبلغ، التاريخ...)
        │   ├── Services/
        │   │   ├── IBudgetService.cs # واجهة خدمة إدارة الميزانية
        │   │   └── BudgetService.cs  # تنفيذ استعلامات EF Core وقاعدة البيانات
        │   ├── ViewModels/
        │   │   ├── ViewModelBase.cs  # الأساس لكافة نماذج العرض
        │   │   └── MainViewModel.cs  # النموذج الرئيسي (إدارة الحالة والعمليات)
        │   └── Views/
        │       ├── MainView.axaml    # واجهة التطبيق الرئيسية (XAML المتجاوب)
        │       └── MainView.axaml.cs # منطق التكيف مع حجم الشاشة (SizeChanged)
        │
        ├── MyCrossApp.Desktop/       # 🖥️ مشروع التشغيل لسطح المكتب (Windows, macOS, Linux)
        │   ├── Program.cs            # نقطة بدء تشغيل سطح المكتب
        │   └── Views/MainWindow.axaml # نافذة سطح المكتب
        │
        └── MyCrossApp.Browser/       # 🌐 مشروع التشغيل للمتصفح عبر WebAssembly
            ├── Program.cs            # نقطة انطلاق WASM مع المتصفح
            └── wwwroot/              # أصول الويب (index.html, app.css, favicon.ico)
```

---

## ⚙️ المتطلبات الأساسية

لتطوير أو تشغيل المشروع محلياً، يجب توفر:
1. **.NET 10 SDK** (الإصدار 10.0.100 أو أحدث).
   - للتحقق من الإصدار المثبت:
     ```bash
     dotnet --version
     ```
2. **حزمة أدوات WebAssembly (لتشغيل نسخة المتصفح):**
   ```bash
   dotnet workload install wasm-tools
   ```

---

## 🚀 طريقة التثبيت والتشغيل المحلي

### 1. استنساخ المستودع (Clone Repository)
```bash
git clone https://github.com/your-username/MyFirstNetApp.git
cd MyFirstNetApp
```

### 2. استعادة الحزم (Restore Packages)
```bash
dotnet restore
```

### 3. التشغيل كـ تطبيق سطح مكتب (Desktop)
يدعم أنظمة Windows و macOS و Linux:
```bash
dotnet run --project MyFirstApp/MyCrossApp/MyCrossApp.Desktop
```

### 4. التشغيل كـ تطبيق ويب في المتصفح (WebAssembly)
```bash
dotnet run --project MyFirstApp/MyCrossApp/MyCrossApp.Browser
```
بعد اكتمال التحميل، افتح الرابط في المتصفح:
👉 **[http://localhost:5235](http://localhost:5235)**

---

## ☁️ دليل التشغيل في GitHub Codespaces

تم إعداد المشروع وهيكلته ليعمل في السحابة عبر **GitHub Codespaces** بدون أي تعديلات إضافية:

1. افتح المستودع في GitHub واضغط على **Code** > **Codespaces** > **Create codespace on main**.
2. بعد فتح بيئة التطوير في المتصفح، افتح الطرفية (Terminal) وتأكد من تثبيت أدوات المتصفح:
   ```bash
   dotnet workload install wasm-tools
   ```
3. شغّل مشروع المتصفح:
   ```bash
   dotnet run --project MyFirstApp/MyCrossApp/MyCrossApp.Browser
   ```
4. سيتعرف GitHub Codespaces تلقائياً على المنفذ `5235` (Port Forwarding)، وستظهر رسالة منبثقة:
   > *"Your application running on port 5235 is available"*
5. اضغط على زر **Open in Browser** ليفتح التطبيق فوراً في لسان جديد في متصفحك!

> [!NOTE]
> لا ينصح بتشغيل مشروع `MyCrossApp.Desktop` داخل Codespaces لأن بيئات السحابة هي سيرفرات Linux افتراضية خالية من واجهات العرض الرسومية (Headless)، بينما مشروع `MyCrossApp.Browser` يعمل بنسبة 100%.

---

## 💡 الحلول الهندسية لأبرز التحديات

خلال رحلة تطوير هذا المشروع، تم حل عدة تحديات تقنية متقدمة تهم مطوري .NET و Avalonia UI:

### 1. حل مشكلة مربعات الخطوط العربية في المتصفح (WASM Tofu Boxes)
- **المشكلة:** محرك Skia في WebAssembly يعمل داخل بيئة معزولة ولا يملك صلاحية الوصول لخطوط نظام التشغيل كـ Windows.
- **الحل:** تم تضمين ملفي الخط `segoeui.ttf` و `segoeuib.ttf` داخل مجلد `Assets/Fonts/` كمصادر مدمجة (`AvaloniaResource`)، وتطبيقها مركزياً عبر `App.axaml` باستخدام صيغة URI الموحدة:
  ```xml
  FontFamily="avares://MyCrossApp/Assets/Fonts#Segoe UI, Segoe UI, Tahoma, Arial, sans-serif"
  ```

### 2. حل مشكلة مربعات الإيموجيات المفقودة في المتصفح
- **المشكلة:** خطوط النصوص القياسية لا تحتوي على رسوم الإيموجي الملونة (مثل 🍔, 🛍️, 🚗, 💰, ✏️, 🗑️)، مما كان يظهرها كمربعات مكسورة (`□`).
- **الحل:** الاستغناء الكامل عن الإيموجي واستبداله بمسارات متجهة قياسية (SVG Paths) مجمعة في كلاس [`AppIcons.cs`](file:///c:/Users/lenovo/MyApps/MyFirstNetApp/MyFirstApp/MyCrossApp/MyCrossApp/Helpers/AppIcons.cs)، وعرضها باستخدام عنصر `<PathIcon />` عالي الدقة دون الاعتماد على أي خط خارجي.

### 3. حل توافق SQLite عبر الأنظمة
- **المشكلة:** في نظام سطح المكتب يجب تخزين قاعدة البيانات في مجلد `AppData/Local/SmartBudget`، بينما في المتصفح لا يتوفر هذا المسار الفيزيائي ويجب استخدام التخزين الافتراضي المدمج.
- **الحل:** وضع شرط ذكي في [`AppDbContext.cs`](file:///c:/Users/lenovo/MyApps/MyFirstNetApp/MyFirstApp/MyCrossApp/MyCrossApp/Data/AppDbContext.cs):
  ```csharp
  if (OperatingSystem.IsBrowser())
  {
      dbPath = "smartbudget.db";
  }
  else
  {
      var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      dbPath = Path.Combine(folder, "SmartBudget", "smartbudget.db");
  }
  ```

### 4. حل تداخل العناصر عند تصغير الشاشة (Responsive Layout)
- **المشكلة:** كان عرض القائمة يتشوه وتتداخل النصوص والمبالغ مع أزرار الإجراءات عند تصغير نافذة المتصفح.
- **الحل:**
  1. إعادة تصميم بطاقة المعاملة بنظام **شبكة من سطرين (2-Row Grid)** بحيث يستقل المبلغ في السطر العلوي، وتستقل الأزرار في السطر السفلي مع تفعيل خاصية القص الذكي `TextTrimming="CharacterEllipsis"`.
  2. إضافة مراقب تغير الحجم `SizeChanged` في [`MainView.axaml.cs`](file:///c:/Users/lenovo/MyApps/MyFirstNetApp/MyFirstApp/MyCrossApp/MyCrossApp/Views/MainView.axaml.cs) للتحول التلقائي بين وضعية العمودين (للشاشات العريضة) ووضعية العمود المكدس (للشاشات الصغيرة < 820 بكسل).

---

## 🗺️ خارطة الطريق والتطوير القادم (Roadmap)

- [x] إنشاء البنية الأساسية وإدارة المعاملات المالية (CRUD).
- [x] دعم اللغة العربية الأصيلة (RTL) وتضمين الخطوط في المتصفح.
- [x] أيقونات متجهة SVG عالية الدقة.
- [x] بحث وفلترة لحظية بدون تأخير.
- [x] واجهة متجاوبة بالكامل لجميع مقاسات الشاشات.
- [ ] **رسوم بيانية تفاعلية:** عرض مخططات دائرية (Pie Charts) وأعمدة (Bar Charts) لتوزيع المصاريف.
- [ ] **تصدير واستيراد البيانات:** دعم تصدير واستيراد التقارير المالية بصيغ Excel (XLSX) و CSV و PDF.
- [ ] **الميزانية المحددة:** إمكانية وضع سقف ميزانية شهري لكل تصنيف وتنبيه المستخدم عند الاقتراب من تجاوزه.
- [ ] **النسخ الاحتياطي السحابي:** مزامنة المعاملات عبر التخزين السحابي أو تصدير نسخة احتياطية من SQLite.

---

## 📄 الترخيص (License)
هذا المشروع مفتوح المصدر ومتاح للاستخدام والتعلم والتطوير الحر.
