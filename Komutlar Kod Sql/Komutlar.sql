use ANKET_DB;

Select * From ANK_ANKETLER;

Select * From ANK_SORULAR;

Select * From ANK_CALISANLAR;

Select * From ANK_CEVAPLAR;

Select * From ANK_REFERANSLAR;

Select * From ANK_SECENEKLER;

Select * From ANK_NESNELER;


Select SQ_ANKET_ID,SQ_SORU_ID From ANK_ANKETLER inner join ANK_SORULAR on ANK_ANKETLER.SQ_ANKET_ID =  ANK_SORULAR.SQ_SORU_ID;
--Bu Yapt���m�z inner join sorgusuna �rnektir,ilk olarak ANK_ANKETLER tablosundaki SQ_ANKET_ID kolonunu sonras�nda ANK_SORULAR tablosundaki SQ_SORU_ID kolonunundaki benzer verileri
--birbirlerini inner join yaparak ba�l�yoruz.Yani K�sacas� inner join kolonlar aras�ndaki benzer verileri g�sterir.


Select SQ_ANKET_ID,SQ_SORU_ID From ANK_ANKETLER right outer join ANK_SORULAR on ANK_ANKETLER.SQ_ANKET_ID =  ANK_SORULAR.SQ_SORU_ID;
--Bu Yapt���m�z ise right outer join sorgusuna �rnektir,bu sorgu inner join ile benzerlik g�sterir yani iki tablo aras�ndaki belirti�imiz kolonlar aras�ndaki benzer verileri getirir
 --ama tek fark� sa� tablodaki belirtilen kolondaki t�m veriler de g�sterilir yani sa� tabloda olupta sol tablodaki olmayan veriler
--K�sacas� right outer join  inner join gibi belirtilen kolonlar aras�ndaki benzer verileri getirir tek fark� sa� tablonun belirtilen kolundaki
--t�m veriler gelir,solda ise sa� tablo ile uyu�an yani benzer veriler gelir inner join mant��� gibi



Select SQ_ANKET_ID,SQ_SORU_ID From ANK_ANKETLER left outer join ANK_SORULAR on ANK_ANKETLER.SQ_ANKET_ID =  ANK_SORULAR.SQ_SORU_ID;
--Bu Yapt���m�z ise left outer join sorgusuna �rnektir,bu sorgu inner join ile benzerlik g�sterir yani iki tablo aras�ndaki belirti�imiz kolonlar aras�ndaki benzer verileri getirir 
--ama tek fark� sol tablodaki belirtilen kolondaki t�m veriler de g�sterilir yani sol tabloda olupta sa� tablodaki olmayan veriler
--K�sacas� left outer join  inner join gibi belirtilen kolonlar aras�ndaki benzer verileri getirir tek fark� sol tablonun belirtilen kolundaki t�m veriler gelir sa�da ise sol tablo 
--ile uyu�an yani benzer veriler gelir inner join mant��� gibi




Select CH_REF_ANAHTAR, count(CH_REF_ANAHTAR) As 'Ka� Tane var' From ANK_REFERANSLAR Group by CH_REF_ANAHTAR;--Burada Group by kullanarak tabloyu daha d�zenli g�r�nmesini sa�lad�k.
--Buradaki �rnekte belirti�imiz tabloda benzer veriler alt alta gelmi� bir �ekilde kar��m�za ��k�yor.Group by ile belirti�imiz tablo kullan�larak bu durum ortadan kalkm�� oluyor.
--Buradaki Countun amac� group by ile d�zenlenen verilerin ka� tane oldu�unu g�stersin bir nevi countun amac� saymad�r.


Select CH_REF_ANAHTAR, count(CH_REF_ANAHTAR) As 'Ka� Tane var' From ANK_REFERANSLAR Group by CH_REF_ANAHTAR having COUNT(CH_REF_ANAHTAR)<3 ;
--Buradaki �rnekte having count kulland�k.�rnekteki amac� ise group by ile d�zenlenmi� veriler aras�nda belirtilen kolon i�indeki veriler aras�nda 3 den k���k olanlar� bize g�stermesini 
--sa�lad�k.Having Count where komutu ile ayn� g�revdedir tek fark� where komutunda group by a ihtiya� duymazken having count da ise group by olmadan kullan�lamaz

Select Sum(CD_ANKET_ID) AS 'Toplam Anket idsi' From ANK_SORULAR;
--Buradaki sum komutunun amac� belirti�imiz tablonun i�indeki(ANK_Sorular) belirtilen kolonun i�indeki(CD_ANKET_ID) verilerin toplam�n� g�sterir. 

Select CH_AD ,LEN(CH_AD) AS 'Ka� Karakterli' From ANK_CALISANLAR;--Burada Len komutunu kullanarak yapt���m�z �rnekte bellirti�imiz kolonun i�indeki verilerin ka� karakterli oldu�una bakt�k
--K�sacas� len komutu Kolondaki verilerin karakter say�s�n� g�sterir (say�lar i�inde ge�erlidir)

Select AVG(SQ_SORU_ID) AS 'Soru ID sinin ortalamas�' From ANK_SORULAR; --Burada AVG Komutunu kullanarak bellirti�imiz kolonun i�indeki verlilerin ortalamas�n� ald�k
--K�sacas� AVG metodu belirtilen kolonun i�indeki verilerin ortalamas�n� al�r


Select MAX(CD_ANKET_ID)'En y�ksek de�er' FROM ANK_SORULAR;--Buradaki Max Komutunun amac� Belirtti�imiz kolonun i�indeki veriler aras�ndan en y�ksek de�eri bize g�sterdi.
--K�sacas� Max komutu Belirtilen Kolonun i�indeki veriler aras�ndan en y�ksek de�eri g�sterir


Select MIN(CD_ANKET_ID)'En d���k de�er' From ANK_SORULAR;--Buradaki Min Komutunun amac� Belirtti�imiz kolonun i�indeki veriler aras�ndan en d���k de�eri bize g�sterdi.
--K�sacas� Min komutu Belirtilen Kolonun i�indeki veriler aras�ndan en d���k de�eri g�sterir


Select TOP 1(CH_AD) From ANK_CALISANLAR ;--Buradaki Top 1 komutunun amac� Belirtti�imiz Kolonun i�indeki ilk veriyi g�sterdi
--K�sacas� Top 1 belirtilen kolondaki veriler aras�ndan ilk veriyi g�sterir normalde top komutu yerine first komutu da kullan�l�r ama SQL Server Veritabanlar�nda bu komut kullan�lmaz.


Select TOP 4(CH_AD) From ANK_CALISANLAR ;--Buradaki Top 4 komutunun amac� Belirtti�imiz Kolonun i�indeki 1. veriden 4. veriye olan verileri g�sterdi
--K�sacas� Top 4 belirtilen kolondaki veriler aras�ndan 1.veriden 4.veriye kadar olan verileri g�sterir


Select GETDATE() As 'G�n�n Tarihi';
--GetDate komutu G�n�n tarih ve saatini verir
