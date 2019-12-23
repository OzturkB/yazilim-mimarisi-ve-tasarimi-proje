# Yazılım Mimarisi ve Tasarımı
Yazılım Mimarisi ve Tasarımı Dersi Projesi

## Factory Method Tasarım Deseni
Fabrika yordam tasarım deseni, nesne yaratma sorumluluğunun bir yordama verilmesidir. Yaratılan nesne, bir sınıf hiyerarşisindeki alt sınıflardan biridir. Hangi alt sınıfın yaratılacağı kararı fabrika yordam içinde verilir. Bu yordam ile belirli bir sınıf hiyerarşisindeki alt nesnelerden birinin yaratma sorumluluğu belirli bir arayüzeverilerek sistemden soyutlanmış olur. Böylece nesneleri yaratma kodlarında, kod tekrarları önlenmiş olur. Sistem içinde sınıfların yaratılacağı yer tek olduğu için, ilgili mantıklar tek bir yerde toplanabilir.

![Image of Class](https://github.com/OzturkB/yazilim-mimarisi-ve-tasarimi-proje/blob/master/FactoryMethod.png)

```csharp
public interface IVehicle
{
    void DisplayInfo();
}
 
public class Car : IVehicle
{
    public void DisplayInfo()
    {
        Console.WriteLine("Car produced");
    }
}
 
public class Truck : IVehicle
{
    public void DisplayInfo()
    {
        Console.WriteLine("Truck produced");
    }
}
 
public class Motorcycle : IVehicle
{
    public void DisplayInfo()
    {
        Console.WriteLine("Motorcycle produced");
    }
}
```
Yukarıda nesneler ve arayüzleri oluşturuldu. Ardından VehicleFactory isimli, içerisinde geriye IVehicle döndüren ProduceVehicle adında bir sınıf tanımlanır. ProduceVehicle metodu VehicleType adında bir bir enum parametre olarak alır. Bu enum'ı kullanarak factory metoduna üretmesini istediğimiz tip bilgisini geçeceğiz.
```csharp
public enum VehicleType
{
    Car = 1,
    Truck = 2,
    Motorcycle = 3
}
 
public interface IVehicleFactory
{
    IVehicle ProduceVehicle(VehicleType type);
}
 
public class VehicleFactory : IVehicleFactory
{
    public IVehicle ProduceVehicle(VehicleType type)
    {
        IVehicle vehicle = null;
        switch (type)
        {
            case VehicleType.Car:
                vehicle = new Car();
                break;
            case VehicleType.Truck:
                vehicle = new Truck();
                break;
            case VehicleType.Motorcycle:
                vehicle = new Motorcycle();
                break;
        }
        return vehicle;
    }
}
```
Program.cs içerisinde aşağıdaki gibi üretmek istediğimiz türdeki aracı factory'e söyleyip üretebiliriz.
```csharp
class Program
{
    static void Main(string[] args)
    {
        var vehicleFactory = new VehicleFactory();
 
        IVehicle vehicleCar = vehicleFactory.ProduceVehicle(VehicleType.Car);
        vehicleCar.DisplayInfo();
 
        IVehicle vehicleMotorcycle= vehicleFactory.ProduceVehicle(VehicleType.Motorcycle);
        vehicleMotorcycle.DisplayInfo();
    }
}
```
Factory method tasarım deseni ile client etkilenmeden değişiklik yapılabilir.

## Facade Tasarım Deseni
Bu tasarım deseni, sistemin detaylarını saklayarak, istemcinin dışarıdan sisteme ulaşabilmesi için tek bir ön yüz sunar. Sistemdeki alt sınıflara, bu ön yüz sınıfı ile ulaşılır. İstemci yalnızca sistemdeki bu ön yüz sınıfını bilir. Yani kısaca ön yüz sınıfı, sistemin dışarıya açılmış bir kapısı gibidir.

![Image of Class](https://github.com/OzturkB/yazilim-mimarisi-ve-tasarimi-proje/blob/master/Facade.png)

```csharp
public class Sistem1Kontrol
{
    public bool KaraListeKontrol(string Tc)
    {
        //kontrol edildiğini varsayalım
        return false;
    }
}

public class Sistem2Operations
{
    public void UyeEkle(string Tc)
    {
        Console.WriteLine("{0} Üye Eklendi",Tc);
    }
}
public class TcKimlikSistem
{
    public bool Kontrol(string Tc)
    {
        //kontrol edildiğini varsayalım
        return true;
    }
}
```
Yukarıdaki kodda alt katmandaki sınıflar tanımlanır. Ardından aşağıdaki gibi ön yüz sınıf tanımlanır. Bu sınıf içerisinde parametre olarak verilen TC kimlik numarasının kara listede olup olmadığını ve doğru olup olmadığını kontrol eden 'Sistem2UyeEkle' fonksiyonu vardır.

```csharp
public class Facade
{
    //constructor da oluşturulabilir
    //singleton olarak tasarlanabilir
    TcKimlikSistem TcSistem = new TcKimlikSistem();
    Sistem1Kontrol Sistem1 = new Sistem1Kontrol();
    Sistem2Operations Sistem2 = new Sistem2Operations();
    public void Sistem2UyeEkle(string Tc)
    {
        if (TcSistem.Kontrol(Tc) && !Sistem1.KaraListeKontrol(Tc))
        {
            Sistem2.UyeEkle(Tc);
        }
    }
}
```
Main fonksiyonu içerisinde 'Facade' sınıfından nesne üretilir ve nesnenin 'Sistem2UyeEkle' fonksiyonu çağırılır.
```csharp
class Program
{
    static void Main(string[] args)
    {
        Facade f = new Facade();
        f.Sistem2UyeEkle("123123");
        Console.ReadKey();
    }
}
```
Sistem1Kontrol, Sistem2Operations ve TcKimlikSistem sınıfları alt sistemlerdir. Program yani client bu sınıfları direkt olarak kullanmayıp oluşturulan Facade sınıfı üzerinden kullanır.
