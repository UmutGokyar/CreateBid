# CreateBid
## Fiyat Teklifi Oluşturma Projesi

- Bu proje fiyat teklifi oluşturmak için üretilmiştir.
- Oluşturmuş olduğunuz fiyat tekliflerinden PDF formatında döküman elde edebilirsiniz.

## Details
![image](https://user-images.githubusercontent.com/97020787/209664998-9807dc58-0a3c-4d0d-9952-05a2a1877186.png)

- Ürün listenize "Products" sekmesinden ulaşabilirsiniz.Bu sayfada silme ve güncelleme işlemlerinizi gerçekleştirebilirsiniz.
- Oluşturduğumuz ürünlerin statüsü default olarak "OnSale"(Satışta) olarak ayarlanmıştır.
- Herhangi bir fiyat teklifinde yer alan bir ürünü silmek istediğinizde ürün silinmeyecektir.Ürünün statüsü "Not On Sale"(Satış Dışı)'e çekilecektir.Ürün herhangi bir fiyat listesinde yoksa silmek istediğiniz ürün silinecektir.
- Fiyat Teklifi oluşturma aşamasında statüsüsü "Not On Sale" olan ürünler ürün ekleme noktasında karşınıza çıkmayacaktır.Haliyle yalnıza statüsü "On Sale"(Satışta) olan ürünleri seçebilirsiniz.
- Ürünü düzenle sayfasına "Edit" butonu ile devam edebilirsiniz.Burada ürünün isim fiyat açıklama ve statüsü ile ilgili değişiklikleri gerçekleştirebilirsiniz.
- Fiyat teklifimizin dökümünü örnekteki gibi PDF formatında elde edebilirsiniz.
![image](https://user-images.githubusercontent.com/97020787/209667679-055e0e5d-62a2-4269-9ba9-98768f1afb3d.png)
- Teklif oluşturma sayfasında "Add Offer" sekmesinden ulaşabilirsiniz.
- OfferNumber otomatik olarak oluşturulur.(Yıl+Ay+OluşturulduğundaSahipOlacağıId)
- Ürünlerimizi seçtiğimiz anda ürünün fiyat bilgisi dinamik olarak veritabanından gelecektir.Teklif kalemiyle ilgili yaptığımz değişiklikler anlık olarak hesaplanır ve ekrana yansır.
- AddRow ile fiyat teklifimize istediğimiz kadar kalem ekleyebiliriz.
- Create ile fiyat teklifimizi oluşturmuş oluruz.
![image](https://user-images.githubusercontent.com/97020787/209666388-54e12420-bea9-434d-817f-df1405c0a15c.png)
- Oluşturmuş olduğunuz fiyat tekliflerinin listesine "Offers" sekmesinden ulaşabilirsiniz.Bu sayfada tekliflerinizle ilgili özet bir bilgi sunulmaktadır.Fiyat teklifindeki detayları görmek için "Details" butonu ile ilerleyiniz.
![image](https://user-images.githubusercontent.com/97020787/209666654-68cc71ee-6cbb-494d-adef-9181096f4a6d.png)
- Fiyat teklifi detaylarına gittiğinizde teklif içeriği kalem kalem yazmaktadır.
- Teklifin etay sayfasında, teklifinizde değişiklikler yapabilirsiniz ürün ekleyip ürün çıkarabilirsiniz veya teklifi silebilirsiniz.
- Teklifin detay sayfasında, teklifi PDF formatında bir döküman olarak almak isterseniz sayfada bulunan PDF butonuna tıklamanız yeterli olacaktır.
- ![image](https://user-images.githubusercontent.com/97020787/209668767-60675600-7514-4804-aea7-0b3b5913cf93.png)

## Yükleme

Öncelikle projeyi klonlayın.

```https://github.com/UmutGokyar/CreateBid.git
```

## Kullanım

Projeyi klonladıktan sonra Visual Studio'da açın.

Linux İçin:

```
cd createbid
code .
```

## Katkı

Pull requestler kabul edilir. Büyük değişiklikler için, lütfen önce neyi değiştirmek istediğinizi tartışmak için bir konu açın.
## Lisans

[MIT](https://snyk.io/learn/what-is-mit-license/)

## Yazar

- Umut GÖKYAR
