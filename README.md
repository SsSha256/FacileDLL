# FacileDLL
**Пример использования**

### Удобная работа с ws
**Класс Connect**
#### Важно!!! При каждом запросе на сервер использовать новый экземпляр! Желательная конструкция: await ((IConnect)new Connect("IP")).Connection("Port"). ...

**Подключение:**
```C#
  using FacileDLL;
  using FacileDLL.Prototypes;
  
  namespace Example
  {
      public class Example 
      {
          public Example()
          {
              IConnect con = new Connect("ip адрес сервера");
              _ = con.Connection("port");
          }
      }
  }
```
**Отправка и получение данных:**
```C#
  using FacileDLL;
  using FacileDLL.Prototypes;
  
  namespace Example
  {
      public class Example
      {
          private string Req;
          
          public Example() =>
            Req = One();
          
          private async string One() =>
            await ((IConnect)new Connect("IP")).Connection("Port").SendAsync(string message); // or byte[] message
      }
  }
```
**Получение двоичных данных:**
```C#
  using FacileDLL;
  
  namespace Example
  {
      public class Example
      {
          private byte[] data;
          
          public Example() =>
            data = GetData();
            
          private async byte[] GetData() =>
            await ((IConnect)new Connect("IP")).Connection("Port").GetBytes(string message) // or byte[] message
      }
  }
```
---
### Объединение байтовых данных в один массив
**Класс WorkBytes**
```C#
  using FacileDLL;
  
  namespace Example
  {
      public class Example
      {
          private byte[] data;
          
          public Example() =>
            data = WorkBytes.Concat(byte[] oneArray, byte[] twoArray);
      }
  }
```
---
### Хэширование строки
**Класс Crypto**
```C#
  using FacileDLL;
  
  namespace Example
  {
      public class Example
      {
          private string Hash;
          
          public Example()
          {
              Hash = Crypto.HashMD5(string data);
              Hash = Crypto.HashSHA256(string data);
          }
      }
  }
```
---
### Прямые зависимости:
* [WebSocketSharp-netstandard](https://github.com/PingmanTools/websocket-sharp/)

**Все лицензии лежат в папке Licenses**

### P.S. Библиотека .netstandard версии 2.0. Делал для себя
