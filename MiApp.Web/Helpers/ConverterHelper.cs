using MiApp.Web.Data.Entities;
using MiApp.Web.Models;

namespace MiApp.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public ItemEntity ToItemEntity(ItemViewModel model, string path, bool isNew)
        {
            return new ItemEntity
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name,
                Active=model.Active,
                Date=model.Date,
                Price = model.Price,
                Quantity = model.Quantity
            };
        }

        public ItemViewModel ToItemViewModel(ItemEntity ItemEntity)
        {
            return new ItemViewModel
            {
                Id = ItemEntity.Id,
                LogoPath = ItemEntity.LogoPath,
                Name = ItemEntity.Name,
                Active = ItemEntity.Active,
                Date = ItemEntity.Date,
                Price = ItemEntity.Price,
                Quantity = ItemEntity.Quantity
            };
        }
    }
}