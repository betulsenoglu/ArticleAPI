**INSTALLATION of Local Mongo :**

## usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)" ##

brew tap mongodb/brew

brew install mongodb-community
mongod --dbpath=/Users/user/data/db

brew services start mongodb-community


**CREATE MONGO Database :**

Use BlogDB


**PROJECT API DOCUMENTATION : https://documenter.getpostman.com/view/7420314/SzzrYE1M?version=latest**


***Sorular:***
**- Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?**

  Projede database context oluşumu operasyonunda singleton pattern kullanılmıştır. Böylece uygulama lifecycle boyunca tek bir nesne üzerinden sorgulama yapmıştır.
  
**- Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek
yazabilir misiniz?**

  Proje .NET CORE API uygulamasıdır. Bu alanda profesyonel olarak 1 yıllık tecrübem bulunmaktadır. Aynı şekilde NoSQL-MongoDB teknolojisinde de profesyonel 1 yıl tecrübem bulunaktadır.
  
**- Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?**

  Projede sunulan dataların cache mekanizması üzerindne sağlanması için geliştirme yapardım. Şimdilik REDIS Entegrasyonu bulunmakta fakat uygulanabilmesi için vakit kısıtlı kaldığından uygulanmadı. Bunun dışında dökümantasyon için devamlılığı sağlamak adına projeye entegre olabilecek tool kullanılabilir, swagger vs. gibi. Aynı zamanda API uçlarından Article modelinin tümünü sunmak yerine istek doğrultusunda gerekli alanları endpointler ve mapping katmanı ile birlikte sunabilirdim.
