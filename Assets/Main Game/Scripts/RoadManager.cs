//UNFINISHED SCRIPT
//TODO: finish this

using UnityEngine;

public class RoadManager : MonoBehaviour
{
    /* (tr)
     * playerin bulundu�u k�s�mdaki objeler
     *      bu objelerin en sonundaki objenin konumu bir vector3e al�n�r.
     *      player bu vector3� extraDestination kadar ge�ti�inde bu objeler kald�r fonksiyonuna tek tek girilir
     * Yolun max uzunlu�u
     * yolun sonu
     * Teleport Point
     *      
     *      playerin bulundu�u k�s�m ve arkas�ndaki objelerin indexleri bir listeye al�n�r.
     *      silmekonumu = arkas�ndakiObjeler listesinin en sondaki elementinin (konum olarak en sondaki obje) konumu 
           +boyutu + extra mesafe.
     *      player silme konumuna geldiyse;
           arkadaki objeler silinip arkadaki objeler tekrar listeye al�n�r
            ve yeni silme konumu hesaplan�r
           yolun sonu - playerin konumu = mesafe olsun,
           eklenecekObjeler eklenecekObjelerin boyutu + mesafe "yolun max uzunlu�u"nu ge�ene kadar rastgele se�ilir .

     * Teleport System:
     * B�t�n  Eklenecek objeleri AllObjects listesine al
     * e�er player "Teleport Point"e gelirse;
     *      player'� "Telepor Point" kadar geri getir
     *      AllObjects listesindekileri "Telepor Point" kadar geri getir
     *      yolun sonu -= "Telepor Point"
     */

    /*
    * OBJECT POOL�NG
    * 
    * Ne �stiyoruz?
    * Belirli aral�klarla belirli �eyler konulsun yola. bu aral�klar�n bir "range"i olabilir yani 2 say� aras�ndan rastgele se�ilebilir.
    * 
    * tamamen rastgele se�ilecekler ayr� bir �ekilde ihtimallere g�re se�ilir
    * 
    * S�n�f: Belirli Aral�klarla Se�ilecek Objeler (baso)
    * de�i�kenler:
           obje
           son konumu
           eklenme aral���
    * belirli aral�klarla se�ilecek objeler bir dizide tutulur
    * silinirken ve eklenirken "belirli aral�klarla se�ilecek objeler"in son konumu kendi s�n�f�ndaki son konumu de�i�kenine not al�n�r
    * teleport k�sm�na gelindi�inde bu not al�nan uzakl�klar'dan "teleport point" ��kart�l�r
    * yeni objeler eklenece�inde eklenme aral���ndan rastgele say� se�ilir. bu se�ilen say�ya "eklenecek konum" diyelim;
       "eklenecek konum" > (yolun sonu - son konum) ise the obje eklenecek objeler listesine al�n�r.
    * 
    * tema de�i�ti�inde direkt eklenecek objeler object pooling'te tutulmas�na gerek yok.
    * tema de�i�ikli�i i�in ayr� bir fonksiyon yapars�n o fonksiyonda tema de�i�ikli�i i�in eklenecek olan her�ey vs ayarlan�r.
    * 
    * Object Pooling Nas�l Olacak?
    * de�i�kenler:
    *      rastgele se�ilecekler(dizi)
    *      (float)eklenecek objeler listesindeki objelerin toplam uzunlu�u("uzunluk" diyece�im)
    *      Y�zdelikTolerans(float) // �rne�in: 120. yani %100 objeleri havuza koymak yerine %120 koy ki havuzdaki objeler bitmesin
    *          tolerans nas�l hesaplan�r; b�t�n ihtimaller toplam 60 olsun 60/100*tolerans. (ihtimaller 100e tamamlanmak zorunda de�il. theme manager'a bakarsan orada istersen 10 yaz istersen bir di�er objenin olu�ma ihtimaline 30 yaz bir di�erine 40 yaz, toplam 80 olur. ihtimal se�ilirken de 10/80 gibi se�ilecek)
    * 
    * rastgele se�ilecekler'i tema manager'dan ihtimalleriyle birlikte bak�l�r, �rne�in;
    * tolerans: 120 olsun.
    * ihtimal oranlar� toplam� 80 olsun.
    * %20lik bir objeden ka� tane havuza eklenece�i ��yle hesaplan�r: 
    * (int)("yolun max uzunlu�u"/80 *20)/(100*20)   [ikinci parantez tolerans�n hesaplanmas�]
    * 
    * havuzdan ihtimal oranlar�na g�re rastgele bir obje �ekilir ve eklenecek objeler listesine eklenir.
    * eklenecek objeler listesindeki objelerin toplam uzunlu�u += eklenen objenin ilk child objesinin boyutunun z ekseni (eklenecek objelerin 2.)
    * ya da child object yapmak yerine bunlar� bir s�n�fa alal�m
    * 
    * 
    * havuzdaki objeler biterse? havuza �ok obje koymam�z ne kadar verimli?
    * 
    * 
    */

}
