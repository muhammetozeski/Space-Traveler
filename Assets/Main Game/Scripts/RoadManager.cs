//UNFINISHED SCRIPT
//TODO: finish this

using UnityEngine;

public class RoadManager : MonoBehaviour
{
    /* (tr)
     * playerin bulunduðu kýsýmdaki objeler
     *      bu objelerin en sonundaki objenin konumu bir vector3e alýnýr.
     *      player bu vector3ü extraDestination kadar geçtiðinde bu objeler kaldýr fonksiyonuna tek tek girilir
     * Yolun max uzunluðu
     * yolun sonu
     * Teleport Point
     *      
     *      playerin bulunduðu kýsým ve arkasýndaki objelerin indexleri bir listeye alýnýr.
     *      silmekonumu = arkasýndakiObjeler listesinin en sondaki elementinin (konum olarak en sondaki obje) konumu 
           +boyutu + extra mesafe.
     *      player silme konumuna geldiyse;
           arkadaki objeler silinip arkadaki objeler tekrar listeye alýnýr
            ve yeni silme konumu hesaplanýr
           yolun sonu - playerin konumu = mesafe olsun,
           eklenecekObjeler eklenecekObjelerin boyutu + mesafe "yolun max uzunluðu"nu geçene kadar rastgele seçilir .

     * Teleport System:
     * Bütün  Eklenecek objeleri AllObjects listesine al
     * eðer player "Teleport Point"e gelirse;
     *      player'ý "Telepor Point" kadar geri getir
     *      AllObjects listesindekileri "Telepor Point" kadar geri getir
     *      yolun sonu -= "Telepor Point"
     */

    /*
    * OBJECT POOLÝNG
    * 
    * Ne Ýstiyoruz?
    * Belirli aralýklarla belirli þeyler konulsun yola. bu aralýklarýn bir "range"i olabilir yani 2 sayý arasýndan rastgele seçilebilir.
    * 
    * tamamen rastgele seçilecekler ayrý bir þekilde ihtimallere göre seçilir
    * 
    * Sýnýf: Belirli Aralýklarla Seçilecek Objeler (baso)
    * deðiþkenler:
           obje
           son konumu
           eklenme aralýðý
    * belirli aralýklarla seçilecek objeler bir dizide tutulur
    * silinirken ve eklenirken "belirli aralýklarla seçilecek objeler"in son konumu kendi sýnýfýndaki son konumu deðiþkenine not alýnýr
    * teleport kýsmýna gelindiðinde bu not alýnan uzaklýklar'dan "teleport point" çýkartýlýr
    * yeni objeler ekleneceðinde eklenme aralýðýndan rastgele sayý seçilir. bu seçilen sayýya "eklenecek konum" diyelim;
       "eklenecek konum" > (yolun sonu - son konum) ise the obje eklenecek objeler listesine alýnýr.
    * 
    * tema deðiþtiðinde direkt eklenecek objeler object pooling'te tutulmasýna gerek yok.
    * tema deðiþikliði için ayrý bir fonksiyon yaparsýn o fonksiyonda tema deðiþikliði için eklenecek olan herþey vs ayarlanýr.
    * 
    * Object Pooling Nasýl Olacak?
    * deðiþkenler:
    *      rastgele seçilecekler(dizi)
    *      (float)eklenecek objeler listesindeki objelerin toplam uzunluðu("uzunluk" diyeceðim)
    *      YüzdelikTolerans(float) // örneðin: 120. yani %100 objeleri havuza koymak yerine %120 koy ki havuzdaki objeler bitmesin
    *          tolerans nasýl hesaplanýr; bütün ihtimaller toplam 60 olsun 60/100*tolerans. (ihtimaller 100e tamamlanmak zorunda deðil. theme manager'a bakarsan orada istersen 10 yaz istersen bir diðer objenin oluþma ihtimaline 30 yaz bir diðerine 40 yaz, toplam 80 olur. ihtimal seçilirken de 10/80 gibi seçilecek)
    * 
    * rastgele seçilecekler'i tema manager'dan ihtimalleriyle birlikte bakýlýr, örneðin;
    * tolerans: 120 olsun.
    * ihtimal oranlarý toplamý 80 olsun.
    * %20lik bir objeden kaç tane havuza ekleneceði þöyle hesaplanýr: 
    * (int)("yolun max uzunluðu"/80 *20)/(100*20)   [ikinci parantez toleransýn hesaplanmasý]
    * 
    * havuzdan ihtimal oranlarýna göre rastgele bir obje çekilir ve eklenecek objeler listesine eklenir.
    * eklenecek objeler listesindeki objelerin toplam uzunluðu += eklenen objenin ilk child objesinin boyutunun z ekseni (eklenecek objelerin 2.)
    * ya da child object yapmak yerine bunlarý bir sýnýfa alalým
    * 
    * 
    * havuzdaki objeler biterse? havuza çok obje koymamýz ne kadar verimli?
    * 
    * 
    */

}
