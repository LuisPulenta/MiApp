using MiApp.Web.Data.Entities;
using MiApp.Web.Models;

namespace MiApp.Web.Helpers
{
    public interface IConverterHelper
    {
        ItemEntity ToItemEntity(ItemViewModel model, string path, bool isNew);

        ItemViewModel ToItemViewModel(ItemEntity ItemEntity);
    }
}