use ANKET_DB;

Select * From ANK_ANKETLER;

Select * From ANK_SORULAR;

Select * From ANK_CALISANLAR;

Select * From ANK_CEVAPLAR;

Select * From ANK_REFERANSLAR;

Select * From ANK_SECENEKLER;

Select * From ANK_NESNELER;


Select SQ_ANKET_ID,SQ_SORU_ID From ANK_ANKETLER inner join ANK_SORULAR on ANK_ANKETLER.SQ_ANKET_ID =  ANK_SORULAR.SQ_SORU_ID;
--Bu Yaptýðýmýz inner join sorgusuna örnektir,ilk olarak ANK_ANKETLER tablosundaki SQ_ANKET_ID kolonunu sonrasýnda ANK_SORULAR tablosundaki SQ_SORU_ID kolonunundaki benzer verileri
--birbirlerini inner join yaparak baðlýyoruz.Yani Kýsacasý inner join kolonlar arasýndaki benzer verileri gösterir.


Select SQ_ANKET_ID,SQ_SORU_ID From ANK_ANKETLER right outer join ANK_SORULAR on ANK_ANKETLER.SQ_ANKET_ID =  ANK_SORULAR.SQ_SORU_ID;
--Bu Yaptýðýmýz ise right outer join sorgusuna örnektir,bu sorgu inner join ile benzerlik gösterir yani iki tablo arasýndaki belirtiðimiz kolonlar arasýndaki benzer verileri getirir
 --ama tek farký sað tablodaki belirtilen kolondaki tüm veriler de gösterilir yani sað tabloda olupta sol tablodaki olmayan veriler
--Kýsacasý right outer join  inner join gibi belirtilen kolonlar arasýndaki benzer verileri getirir tek farký sað tablonun belirtilen kolundaki
--tüm veriler gelir,solda ise sað tablo ile uyuþan yani benzer veriler gelir inner join mantýðý gibi



Select SQ_ANKET_ID,SQ_SORU_ID From ANK_ANKETLER left outer join ANK_SORULAR on ANK_ANKETLER.SQ_ANKET_ID =  ANK_SORULAR.SQ_SORU_ID;
--Bu Yaptýðýmýz ise left outer join sorgusuna örnektir,bu sorgu inner join ile benzerlik gösterir yani iki tablo arasýndaki belirtiðimiz kolonlar arasýndaki benzer verileri getirir 
--ama tek farký sol tablodaki belirtilen kolondaki tüm veriler de gösterilir yani sol tabloda olupta sað tablodaki olmayan veriler
--Kýsacasý left outer join  inner join gibi belirtilen kolonlar arasýndaki benzer verileri getirir tek farký sol tablonun belirtilen kolundaki tüm veriler gelir saðda ise sol tablo 
--ile uyuþan yani benzer veriler gelir inner join mantýðý gibi




Select CH_REF_ANAHTAR, count(CH_REF_ANAHTAR) As 'Kaç Tane var' From ANK_REFERANSLAR Group by CH_REF_ANAHTAR;--Burada Group by kullanarak tabloyu daha düzenli görünmesini saðladýk.
--Buradaki örnekte belirtiðimiz tabloda benzer veriler alt alta gelmiþ bir þekilde karþýmýza çýkýyor.Group by ile belirtiðimiz tablo kullanýlarak bu durum ortadan kalkmýþ oluyor.
--Buradaki Countun amacý group by ile düzenlenen verilerin kaç tane olduðunu göstersin bir nevi countun amacý saymadýr.


Select CH_REF_ANAHTAR, count(CH_REF_ANAHTAR) As 'Kaç Tane var' From ANK_REFERANSLAR Group by CH_REF_ANAHTAR having COUNT(CH_REF_ANAHTAR)<3 ;
--Buradaki örnekte having count kullandýk.Örnekteki amacý ise group by ile düzenlenmiþ veriler arasýnda belirtilen kolon içindeki veriler arasýnda 3 den küçük olanlarý bize göstermesini 
--saðladýk.Having Count where komutu ile ayný görevdedir tek farký where komutunda group by a ihtiyaç duymazken having count da ise group by olmadan kullanýlamaz

Select Sum(CD_ANKET_ID) AS 'Toplam Anket idsi' From ANK_SORULAR;
--Buradaki sum komutunun amacý belirtiðimiz tablonun içindeki(ANK_Sorular) belirtilen kolonun içindeki(CD_ANKET_ID) verilerin toplamýný gösterir. 

Select CH_AD ,LEN(CH_AD) AS 'Kaç Karakterli' From ANK_CALISANLAR;--Burada Len komutunu kullanarak yaptýðýmýz örnekte bellirtiðimiz kolonun içindeki verilerin kaç karakterli olduðuna baktýk
--Kýsacasý len komutu Kolondaki verilerin karakter sayýsýný gösterir (sayýlar içinde geçerlidir)

Select AVG(SQ_SORU_ID) AS 'Soru ID sinin ortalamasý' From ANK_SORULAR; --Burada AVG Komutunu kullanarak bellirtiðimiz kolonun içindeki verlilerin ortalamasýný aldýk
--Kýsacasý AVG metodu belirtilen kolonun içindeki verilerin ortalamasýný alýr


Select MAX(CD_ANKET_ID)'En yüksek deðer' FROM ANK_SORULAR;--Buradaki Max Komutunun amacý Belirttiðimiz kolonun içindeki veriler arasýndan en yüksek deðeri bize gösterdi.
--Kýsacasý Max komutu Belirtilen Kolonun içindeki veriler arasýndan en yüksek deðeri gösterir


Select MIN(CD_ANKET_ID)'En düþük deðer' From ANK_SORULAR;--Buradaki Min Komutunun amacý Belirttiðimiz kolonun içindeki veriler arasýndan en düþük deðeri bize gösterdi.
--Kýsacasý Min komutu Belirtilen Kolonun içindeki veriler arasýndan en düþük deðeri gösterir


Select TOP 1(CH_AD) From ANK_CALISANLAR ;--Buradaki Top 1 komutunun amacý Belirttiðimiz Kolonun içindeki ilk veriyi gösterdi
--Kýsacasý Top 1 belirtilen kolondaki veriler arasýndan ilk veriyi gösterir normalde top komutu yerine first komutu da kullanýlýr ama SQL Server Veritabanlarýnda bu komut kullanýlmaz.


Select TOP 4(CH_AD) From ANK_CALISANLAR ;--Buradaki Top 4 komutunun amacý Belirttiðimiz Kolonun içindeki 1. veriden 4. veriye olan verileri gösterdi
--Kýsacasý Top 4 belirtilen kolondaki veriler arasýndan 1.veriden 4.veriye kadar olan verileri gösterir


Select GETDATE() As 'Günün Tarihi';
--GetDate komutu Günün tarih ve saatini verir
