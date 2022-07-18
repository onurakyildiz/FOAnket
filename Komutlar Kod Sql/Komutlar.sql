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