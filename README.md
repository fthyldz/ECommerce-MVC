# ECommerce-MVC

Bu proje, .NET Core tabanlı bir web uygulamasıdır. Clean Architecture, CQRS, Fluent Validation, AutoMapper, .NET Core Identity, Generic Repository ve Unit of Work gibi modern yazılım geliştirme tekniklerini içermektedir.

## İçindekiler

- [Özellikler](#özellikler)
- [Kullanılan Teknolojiler](#kullanılan-teknolojiler)
- [Kullanıcı Rolleri ve Hesaplar](#kullanıcı-rolleri-ve-hesaplar)
- [Ödeme Sistemi Entegrasyonu](#ödeme-sistemi-entegrasyonu)

## Özellikler

- Clean Architecture ile yapılandırılmıştır.
- CQRS yapısı kullanılarak komut ve sorgu sorumlulukları ayrılmıştır.
- Fluent Validation ile veri doğrulama sağlanmıştır.
- AutoMapper kullanılarak nesne dönüşümleri yapılmaktadır.
- .NET Core Identity ile kullanıcı kimlik doğrulama ve yetkilendirme işlemleri yapılmaktadır.
- Generic Repository ve Unit of Work desenleri kullanılarak veritabanı işlemleri yönetilmektedir.
- Kullanıcılar kayıt olduktan sonra otomatik olarak "User" rolü atanır.
- Proje ayağa kalkarken Database Update işlemi gerçekleşerek Database otomatik olarak oluşmaktadır.
- Uygulama başlangıcında arka planda otomatik olarak Admin ve VIP kullanıcı hesapları oluşturulur.

## Kullanılan Teknolojiler

- **.NET Core**
- **Clean Architecture**
- **CQRS (Command Query Responsibility Segregation)**
- **Fluent Validation**
- **AutoMapper**
- **.NET Core Identity**
- **Generic Repository Pattern**
- **Unit of Work Pattern**

## Kullanıcı Rolleri ve Hesaplar

Sisteme yeni kayıt olan her kullanıcıya otomatik olarak "User" rolü atanır. Ayrıca uygulama başlangıcında arka planda iki özel kullanıcı hesabı oluşturulur:

### Mevcut Hesaplar

**Admin Hesabı:**
- E-posta: `fth.yldz.admin@outlook.com.tr`
- Şifre: `X.1x.1x.1`

**VipUser Hesabı:**
- E-posta: `fth.yldz.vip@outlook.com.tr`
- Şifre: `X.1x.1x.1`

**User Hesabı:**
- E-posta: `fth.yldz.user@outlook.com.tr`
- Şifre: `X.1x.1x.1`

## Ödeme Sistemi Entegrasyonu

Projede ilerleyen aşamalarda ödeme sistemi entegre edilebilir. Bu entegrasyon ile kullanıcılar ödeme yaparak VIP üyeliğe yönetilebilir.
