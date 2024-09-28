# Adesso World League API

**Adesso World League API**, takımları rastgele gruplara atayan ve sonuçları veritabanına kaydeden bir Web API uygulamasıdır. Proje, belirli kurallara göre takımları gruplara yerleştirir ve her gruba belirli bir takım sayısı atar.

## Proje Mimarisi ve Kullanılan Prensipler

Bu proje, **N-Tier Architecture**, **SOLID Prensipleri**, ve **Repository Pattern** gibi yazılım mimarileri kullanılarak tasarlanmıştır. Aşağıda, kullanılan mimariler ve prensipler açıklanmıştır:

### 1. N-Tier Architecture (Katmanlı Mimari)
Proje, katmanlı mimariyi izler. Bu yapı sayesinde uygulama, her katmanda farklı sorumluluklar olacak şekilde bölünmüştür:
- **Presentation Layer (Sunum Katmanı)**: API endpoint'lerinin bulunduğu katman. Kullanıcı isteklerini alır ve iş mantığına yönlendirir.
- **Business Layer (İş Mantığı Katmanı)**: İş kurallarının ve süreçlerin yürütüldüğü katman.
- **Data Access Layer (Veri Erişim Katmanı)**: Veritabanına erişimi yöneten katman. **Repository Pattern** kullanarak veri işlemlerini soyutlar.
- **Domain Layer**: Uygulamanın temel veri modelleri ve iş kurallarını temsil eden sınıfları içerir.

### 2. SOLID Prensipleri
- **Single Responsibility Principle (SRP)**: Her sınıf yalnızca tek bir sorumluluğa sahiptir. Örneğin, `TeamRepository` sınıfı sadece takımlara ait veritabanı işlemlerini gerçekleştirir.
- **Open/Closed Principle (OCP)**: Proje yeni özellikler eklenmeye açık, ancak mevcut kodu değiştirmeden genişletilebilecek şekilde tasarlanmıştır.
- **Dependency Inversion Principle (DIP)**: Katmanlar arasındaki bağımlılıklar, soyutlamalar (interface'ler) aracılığıyla enjekte edilir. Böylece, bağımlılıklar kolayca değiştirilip test edilebilir.

### 3. Repository Pattern
Veritabanı işlemleri, **Repository Pattern** kullanılarak soyutlanmıştır. Her veri modeli için bir repository sınıfı bulunur (örneğin, `TeamRepository` takımlarla ilgili işlemleri yönetir). Bu pattern, veritabanı işlemlerini iş mantığından ayırır ve daha modüler bir yapı sağlar.

---

## API Uç Noktaları:

### CRUD İşlemleri:

#### 1. **Tüm Takımları Getir**
- **Endpoint**: `/api/teams/GetAllTeams`
- **Method**: `GET`
- **Açıklama**: Tüm takımları döndürür.

#### 2. **Takım Ekle**
- **Endpoint**: `/api/teams/AddTeam`
- **Method**: `POST`
- **Açıklama**: Yeni bir takım ekler.
- **İstek Gövdesi**:
    ```json
    {
        "name": "Adesso Antalya",
        "countryId": 1
    }
    ```

#### 3. **Takım Sil**
- **Endpoint**: `/api/teams/DeleteTeam/{id}`
- **Method**: `DELETE`
- **Açıklama**: Belirli bir takımı siler.

#### 4. **Belirli Bir Takımı Getir**
- **Endpoint**: `/api/teams/GetTeamById/{id}`
- **Method**: `GET`
- **Açıklama**: Belirli bir takımı getirir.

#### 5. **Tüm Ülkeleri Getir**
- **Endpoint**: `/api/country/GetAllCountries`
- **Method**: `GET`
- **Açıklama**: Tüm ülkeleri listeler.

#### 6. **Ülke Ekle**
- **Endpoint**: `/api/country/AddCountry`
- **Method**: `POST`
- **Açıklama**: Yeni bir ülke ekler.
- **İstek Gövdesi**:
    ```json
    {
        "CountryName": "Türkiye"
    }
    ```

#### 7. **Ülke Sil**
- **Endpoint**: `/api/country/DeleteCountry/{id}`
- **Method**: `DELETE`
- **Açıklama**: Belirli bir ülkeyi siler.

#### 8. **Grup Ekle**
- **Endpoint**: `/api/group/AddGroup`
- **Method**: `POST`
- **Açıklama**: Yeni bir grup ekler.
- **İstek Gövdesi**:
    ```json
    {
        "GroupName": "Group A"
    }
    ```

#### 9. **Grup Sil**
- **Endpoint**: `/api/group/DeleteGroup/{id}`
- **Method**: `DELETE`
- **Açıklama**: Belirli bir grubu siler.

#### 10. **Belirli Bir Ülkeyi Getir**
- **Endpoint**: `/api/country/GetById/{id}`
- **Method**: `GET`
- **Açıklama**: Belirli bir ülkeyi getirir.

#### 11. **Belirli Bir Grubu Getir**
- **Endpoint**: `/api/group/GetGroupById/{id}`
- **Method**: `GET`
- **Açıklama**: Belirli bir grubu getirir.

---

### 12. **Grup Çekilişi Oluştur**
- **Endpoint**: `/api/league/GenerateGroups`
- **Method**: `POST`
- **Açıklama**: Takımları gruplara atar ve sonuçları döndürür.
- **İstek Gövdesi**:
    ```json
    {
        "DrawerName": "John",
        "DrawerSurname": "Doe",
        "GroupCount": 4
    }
    ```
- **Kural**:
  - **4 grup** varsa, her grup **8 takım** içerir.
  - **8 grup** varsa, her grup **4 takım** içerir.

- **Yanıt** (4 grup için):
    ```json
    {
        "groups": [
            {
                "groupName": "A",
                "teams": ["Adesso İstanbul", "Adesso Berlin", "Adesso Marsilya", "Adesso Antwerp", "Adesso Lahey", "Adesso Sevilla", "Adesso Roma", "Adesso Lisbon"]
            },
            {
                "groupName": "B",
                "teams": ["Adesso İzmir", "Adesso Dortmund", "Adesso Barselona", "Adesso Venedik", "Adesso Rotterdam", "Adesso Granada", "Adesso Milano", "Adesso Porto"]
            }
        ]
    }
    ```

- **Yanıt** (8 grup için):
    ```json
    {
        "groups": [
            {
                "groupName": "A",
                "teams": ["Adesso İstanbul", "Adesso Berlin", "Adesso Marsilya", "Adesso Antwerp"]
            },
            {
                "groupName": "B",
                "teams": ["Adesso İzmir", "Adesso Dortmund", "Adesso Barselona", "Adesso Venedik"]
            },
            {
                "groupName": "C",
                "teams": ["Adesso Antalya", "Adesso Münih", "Adesso Paris", "Adesso Brüksel"]
            }
        ]
    }
