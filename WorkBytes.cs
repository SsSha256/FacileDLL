using System.Collections.Generic;

namespace FacileDLL
{
    /// <summary>
    /// Объединение байтовых данных в один массив
    /// </summary>
    public static class WorkBytes
    {
        /// <summary>
        /// Объединение байтовых данных в один массив
        /// </summary>
        /// <param name="bson">Первый массив байтов</param>
        /// <param name="data">Второй массив байтов</param>
        /// <returns>Массив объединенных входных данных</returns>
        public static byte[] Concat(byte[] bson, byte[] data)
        {
            List<byte> listBytes = new List<byte>();
            listBytes.AddRange(bson);
            listBytes.AddRange(data);
            return listBytes.ToArray();
        }
    }
}
