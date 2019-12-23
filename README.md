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
