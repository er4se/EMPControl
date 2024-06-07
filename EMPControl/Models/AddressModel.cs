using System;
using System.Text;

namespace EMPControl.Models
{

    //Модель адреса - используется для записи данных адресата

    class AddressModel
    {
        public string Country       { get; set; } = string.Empty;   //Страна адресата
        public string Region        { get; set; } = string.Empty;   //Регион адресата
        public string Settlement    { get; set; } = string.Empty;   //Населенный пункт адресата
        public string Street        { get; set; } = string.Empty;   //Улица адресата
        public string Building      { get; set; } = string.Empty;   //Дом адресата
        public string Office        { get; set; } = string.Empty;   //Офис адресата

        //Удаление лишних пробелов из строк, если такие имеются

        public void NormalizeAddress()
        {
            Country     = Country.Trim();
            Region      = Region.Trim();
            Settlement  = Settlement.Trim();
            Street      = Street.Trim();
            Building    = Building.Trim();
            Office      = Office.Trim();
        }

        //Получение полного адреса в формате строки с разделителем '$'

        public string GetFullAddressString()
        {
            NormalizeAddress();

            var fullAddress = new StringBuilder();

            fullAddress
                .Append(Country).Append('$')
                .Append(Region).Append('$')
                .Append(Settlement).Append('$')
                .Append(Street).Append('$')
                .Append(Building).Append('$')
                .Append(Office);

            return fullAddress.ToString();
        }

        //Конвертация строки в формат AddressModel (строка должна быть отформатирована разделителем '$')

        public void ConvertStringToAddress(string fullAddress)
        {
            string[] addressEntites = fullAddress.Split(new char[] { '$' });

            Country     = addressEntites[0];
            Region      = addressEntites[1];
            Settlement  = addressEntites[2];
            Street      = addressEntites[3];
            Building    = addressEntites[4];
            Office      = addressEntites[5];
        }

        //Сброс данных адреса

        public void ResetAddress()
        {
            Country     = string.Empty;
            Region      = string.Empty;
            Settlement  = string.Empty;
            Street      = string.Empty;
            Building    = string.Empty;
            Office      = string.Empty;
        }
    }
}
