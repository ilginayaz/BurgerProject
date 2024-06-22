# ASP.NET Core MVC BurgerGurme Projesi

Kullanılan Teknolojiler
Geliştirme Ortamı: Ms Visual Studio 2022
Kod Altyapısı: C# - .NET CORE 8.0 , HTML-CSS-JavaScript

Veri Tabanı: Ms SQL Server
Veri Erişim Teknolojisi: Entity Framework CORE (CodeFirst)

Veri Tabanı Sorguları: LINQ
File Upload: IFormFile

Kullanıcı kimlik doğrulama - Authentication & Authorization: ASP.NET Core Identity

Tema Giydirme İşlemleri: Hazır template ve Bootstrap5 kütüphanesi

Projeyi Başlatma
appsettings.json dosyasındaki server bağlantısını düzenleyin. 
PM Console'da add-migration [Migration Adı] komutunu yazıp çalıştırın.
PM Console'da update-database diyerek veritabanını oluşturun.

Program verdiğimiz rotalarla başlangıç olarak ön yüz ile çalışır.
Url'e /admin yazarak admin login sayfasına girebilirsiniz.

Admin için seeddata ile göndermiş olduğumuz,
admin@admin.com - 12345*Abcde şifresiyle admin paneline ulaşabilirsiniz.
Admin seeddata ile Admin rolündedir.
Admin panelinde menüleri ve ekstraları ekleyerek, ön yüzü kullanıma hazır hale getirebilirsiniz.
Ardından dilerseniz admin tarafında siparişler ve müşteriler ile ilgili de bazı crud işlemlerine erişebilirsiniz.

Ön yüzde kullanıcılar için register ve login işlemleri mevcuttur.
Kullanıcı kayıtlarında otomatik olarak Customer rolü atanır.
Ön yüzden kayıt yapıp, giriş yaparak
Menüler sayfasında sipariş/siparişler oluşturabilirsiniz.
Ayrıca layoutta bulunan Hoşgeldin"kullanıcı" nın üzerine dokunarak kullanıcı profil menüsü ve siparişlerim bölümüne ulaşabilirsiniz.

Keyifli incelemeler.



Ön yüz için video;
[![Watch the video](https://i.sstatic.net/Vp2cE.png)](https://youtu.be/fCi3T1hsiZk)

Admin  için video;
[![Watch the video](https://i.sstatic.net/Vp2cE.png)](https://youtu.be/hkp9JSoQ3_0)



## Contributors

- [@BurakGonca](https://github.com/BurakGonca)
- [@benguurgen](https://github.com/benguurgen)
- [@ilginayaz](https://github.com/ilginayaz)





