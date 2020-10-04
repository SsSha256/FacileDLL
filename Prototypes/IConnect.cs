using System.Threading.Tasks;

namespace FacileDLL.Prototypes
{
    public interface IConnect
    {
        /// <summary>
        /// Установка соединения. Этот метод используется перед каждой отправкой сообщения на сервер
        /// </summary>
        /// <param name="Port">Порт по которому надо установить подключение</param>
        void Connection(string Port);

        /// <summary>
        /// Отправляет сообщение на сервер
        /// </summary>
        /// <param name="message">Текстовое сообщение</param>
        /// <returns>Ответ от сервера</returns>
        Task<string> SendAsync(string message);

        /// <summary>
        /// Отправляет сообщение на сервер
        /// </summary>
        /// <param name="message">Бинарное сообщение</param>
        /// <returns>Ответ от сервера</returns>
        Task<string> SendAsync(byte[] message);

        /// <summary>
        /// Отправляет сообщение на сервер с последующим получением файла в виде байтов
        /// </summary>
        /// <param name="message">Текстовое сообщение</param>
        /// <returns>Файл</returns>
        Task<byte[]> GetBytes(string message);

        /// <summary>
        /// Отправляет сообщение на сервер с последующим получением файла в виде байтов
        /// </summary>
        /// <param name="message">Бинарное сообщение</param>
        /// <returns>Файл</returns>
        Task<byte[]> GetBytes(byte[] message);

        /// <summary>
        /// Ожидание ответа
        /// </summary>
        /// <returns>Ответ</returns>
        Task<bool> WaitAsync();
    }
}
