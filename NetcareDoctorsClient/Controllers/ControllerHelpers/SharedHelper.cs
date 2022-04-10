using Microsoft.AspNetCore.Mvc.Rendering;
using NetcareDoctorsClient.BLL.DataContract;
using NetcareDoctorsClient.Models.Shared;

namespace NetcareDoctorsClient.Controllers.ControllerHelpers
{
    public class SharedHelper
    {

        public YesNoModel FillYesNoModel(string actionController, string actionMethod, string actionValue, string yesNoMessage)
        {
            return new YesNoModel()
            {
                ActionController = actionController,
                ActionMethod = actionMethod,
                ActionValue = actionValue,
                YesNoMessage = yesNoMessage
            };
        }

        public OkModel FillOkModel(string message, string messageSymbol)
        {
            return new OkModel() { OkMessage = message, MessageSymbol = messageSymbol };
        }

        public List<SelectListItem> FillTitles(List<TitleResp> titleResps,string selectedText)
        {
            List<SelectListItem> _selectListItems = new();

            _selectListItems.Add(new SelectListItem()
            {
                Value = "",
                Text = selectedText,
                Selected = true
            });

            foreach (var item in titleResps.OrderBy(title => title.TitleName))
            {
                _selectListItems.Add(new SelectListItem
                {
                    Value = item.TitleName,
                    Text = item.TitleName
                });
            }

            return _selectListItems;
        }

        public List<SelectListItem> FillDisciplines(List<DisciplineResp> disciplineResps, string selectedText)
        {
            List<SelectListItem> _selectListItems = new();

            _selectListItems.Add(new SelectListItem()
            {
                Value = "",
                Text = selectedText,
                Selected = true
            });

            foreach (var item in disciplineResps.OrderBy(discipline => discipline.DisciplineName))
            {
                _selectListItems.Add(new SelectListItem
                {
                    Value = item.DisciplineName,
                    Text = item.DisciplineName
                });
            }

            return _selectListItems;
        }

        public List<SelectListItem> FillProvinces(List<ProvinceResp> provinceResps, string selectedText)
        {
            List<SelectListItem> _selectListItems = new();

            _selectListItems.Add(new SelectListItem()
            {
                Value = "",
                Text = selectedText,
                Selected = true
            });

            foreach (var item in provinceResps.OrderBy(province => province.ProvinceName))
            {
                _selectListItems.Add(new SelectListItem
                {
                    Value = item.ProvinceName,
                    Text = item.ProvinceName
                });
            }

            return _selectListItems;
        }
    }
}
