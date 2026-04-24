# youtubewebAPI
# YoutubeAPI - Task Management System

Bu layihə, C# və ASP.NET Core texnologiyaları istifadə edilərək hazırlanmış, tapşırıqların idarə edilməsi üçün nəzərdə tutulmuş müasir bir RESTful API sistemidir. Layihənin əsas məqsədi, təmiz kod prinsipləri və genişlənə bilən bir memarlıq nümayiş etdirməkdir.

## 🚀 Texnoloji Stack

* **Framework:** .NET 8 / ASP.NET Core
* **Database:** MSSQL Server (Entity Framework Core)
* **Architecture:** N-Tier Architecture (Core, Business, DataAccess, API)
* **Design Patterns:** Generic Repository Pattern, DTO Pattern
* **Tools:** AutoMapper, Swagger UI, LINQ

## ✨ Əsas Özəlliklər

* **N-Tier Architecture:** Layihə məntiqi qatlara (Layers) bölünərək asan idarəolunan və test edilə bilən hala gətirilib.
* **Generic Repository:** Verilənlər bazası əməliyyatları vahid bir mərkəzdən idarə olunur.
* **DTO (Data Transfer Object):** Təhlükəsizlik üçün həssas məlumatlar (şifrə və s.) API cavablarından gizlədilib.
* **Automated Mapping:** AutoMapper istifadə edilərək obyektlər arası çevrilmələr avtomatlaşdırılıb.
* **API Documentation:** Swagger UI vasitəsilə API-nin bütün endpointləri sənədləşdirilib.

## 📂 Layihə Strukturu

- **YoutubeAPI.Core:** Entity-lər, DTO-lar və əsas interfeyslər.
- **YoutubeAPI.Business:** İş məntiqi (Services) və Mapping konfiqurasiyaları.
- **YoutubeAPI.DataAccess:** Verilənlər bazası bağlantısı, Repository implementasiyaları və Miqrasiyalar.
- **YoutubeAPI.WebAPI:** Controller-lər və xarici dünya ilə ünsiyyət qatı.

## 🛠️ Quraşdırma (Installation)

1. Layihəni klonlayın:
   ```bash
   git clone [https://github.com/istifadeci-adiniz/layihe-adi.git](https://github.com/istifadeci-adiniz/layihe-adi.git)
