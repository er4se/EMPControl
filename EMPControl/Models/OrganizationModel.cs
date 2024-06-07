using System;

namespace EMPControl.Models
{

    //Модель организации для компонентов управления организациями и управления данными

    class OrganizationModel
    {
        public string Id    { get; set; } = string.Empty;               //ID организации
        public string Name  { get; set; } = string.Empty;               //Наименование организации
        public string TIN   { get; set; } = string.Empty;               //ИНН организации
        public string LegalAddress    { get; set; } = string.Empty;     //Юр. адрес организации
        public string PhysicalAddress { get; set; } = string.Empty;     //Физ. адрес организации

        //Конструктор, обнуляет модель при инициализации

        public OrganizationModel()
        {
            ResetToDefault();
        }

        //Операция приравнивания моделей для ссылочного типа

        public void EquateModels(OrganizationModel incomingModel)
        {
            if (incomingModel != null)
            {
                this.Id                 = incomingModel.Id;
                this.Name               = incomingModel.Name;
                this.TIN                = incomingModel.TIN;
                this.LegalAddress       = incomingModel.LegalAddress;
                this.PhysicalAddress    = incomingModel.PhysicalAddress;
            }
        }

        //Операция сброса данных модели с заданием нового идентификатора

        public void ResetToDefault()
        {
            Id = Guid.NewGuid().ToString();

            Name                = string.Empty;
            TIN                 = string.Empty;
            LegalAddress        = string.Empty;
            PhysicalAddress     = string.Empty;
        }
    }
}
