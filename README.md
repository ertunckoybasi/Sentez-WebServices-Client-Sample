<img src="https://www.sentez.com/wp-content/uploads/kurumsal_logo.png" alt="Sentez" align="right">

# Sentez Yazılım Web Servisleri  &middot; [![Build Status](https://img.shields.io/travis/npm/npm/latest.svg?style=flat-square)](https://travis-ci.org/npm/npm) [![npm](https://img.shields.io/npm/v/npm.svg?style=flat-square)](https://www.npmjs.com/package/npm) [![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com) [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://github.com/your/your-project/blob/master/LICENSE)
> Örnek Uygulama

Sentez Rest Api Web Servislerini kullanan .Net 5.0 C# ile oluşturulmuş örnek uygulama.

## Web Servislerinin kurulumu
Rest api web servislerine erişim sağlanabilmesi için LiveServer uygulamasının çalışır durumda olması gerekmektedir. Kurulum için Sentez Yazılım destek ekipleri tarafından yapılmaktadır.
Kurulum yapıldıktan sonra kurulum yapılan sunucuda http://localhost:{port_no}/swagger adresinden web servislerin swagger dökümanına ulaşılabilir.
```shell
LiveServer.Exe
```
## Rest Api Endpointleri 

En sık kullanılan Endpointler aşağıda listelenmiştir.

Authentication
/api/Authentication/Login

Crud İşlemleri
GET /api/BO/Get
GET /api/BO/GetById
GET /api/BO/DeleteRecord
POST /api/BO/PostBO
PUT /api/BO/UpdateBO


### Business Objects 
Web Servislerinden kullanılacak olan BO (Business Object) isimleri fatura modülü için InvoiceBO, sipariş modülü için OrderReceiptBO kullanılmaktadır. Tüm BO isimlerine Liv Erp
yazılımı içinden Ayarlar-->Sentez İş Nesnelerine tıklanarak ulaşılabilmektedir.

### Veritabanı Tablo Ve Alan Adaları
Servislerde kullanılacak modüllere bağlı olarak kullanılacak tablo ve veri alanlarına Live Erp yazılımı içinden Ayarlar==>Veritabanı Bilgileri sekmesinden ulaşılabilir.


### Örnek Uygulama Hakkında

Net 5.0 framework C# ile geliştirilmiştir. Apilere bağlantı için HttpClient komponenti kullanılmıştır. Uygulama içindeki Api Endpointler kurulan sunucu ve LiveServer port ayarlarına göre
modifiye edilmelidir.


### Database

Microsoft Sql Server kullanılmıştır.

### Lisans

Web Servis kullanımları lisansları için Sentez Yazılım satış temsilcileri ile iletişime geçilmelidir.

### İletişim

Genel Müdürlük İstanbul
+90 (212) 452 15 15

Hürriyet Caddesi No:5 Şirinevler
Bahçelievler, İstanbul
info@sentez.com

