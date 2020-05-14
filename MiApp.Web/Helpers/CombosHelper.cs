using Microsoft.AspNetCore.Mvc.Rendering;
using MiApp.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace MiApp.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboTeams()
        {
            List<SelectListItem> list = _context.Items.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Elija un Item...]",
                Value = "0"
            });

            return list;
        }
    }
}