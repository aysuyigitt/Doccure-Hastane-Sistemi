# 🏥 Doccure – Hastane Yönetim Sistemi

ASP.NET Core ve Mikroservis mimarisi kullanılarak geliştirilen, hastane süreçlerinin dijital ortamda yönetilmesini sağlayan web tabanlı bir hastane yönetim sistemidir.

## 📌 Proje Tanımı

Doccure; hasta, doktor, branş, randevu, reçete, ilaç ve kullanıcı işlemlerinin yönetilmesini sağlayan bir mikroservis projesidir.

Uygulamada servisler bağımsız olarak tasarlanmış ve aralarındaki iletişim API Gateway ve servisler arası iletişim mekanizmaları üzerinden sağlanmıştır. Kullanıcı güvenliği JWT tabanlı authentication ve authorization ile gerçekleştirilmiştir.

## 🚀 Proje Özellikleri

- 👤 Kullanıcı kayıt ve giriş işlemleri
- 🔐 JWT Authentication & Authorization
- 👨‍⚕️ Doktor yönetimi
- 🏥 Branş yönetimi
- 🧑‍⚕️ Hasta yönetimi
- 📅 Randevu yönetimi
- 💊 İlaç ve reçete yönetimi
- 🔔 Bildirim işlemleri
- 🌐 API Gateway ile mikroservis yönlendirmesi
- 🔄 Mikroservisler arası iletişim
- ⚡ Redis ile cache yönetimi
- 🐳 Docker ile container yönetimi
- 📖 Swagger ile API dokümantasyonu

## 🛠️ Kullanılan Teknolojiler

### Backend
- C#
- ASP.NET Core Web API
- Entity Framework Core
- RESTful API
- AutoMapper
- Dependency Injection

### Mimari
- Microservices Architecture
- Repository Pattern
- CQRS
- MediatR
- API Gateway
- Ocelot

### Veritabanı
- Microsoft SQL Server
- MariaDB
- MongoDB
- Redis

### Mesajlaşma & Gerçek Zamanlı İletişim
- RabbitMQ
- Apache Kafka
- SignalR

### DevOps & Araçlar
- Docker
- Docker Compose
- Portainer
- Swagger
- Postman
- Git / GitHub
