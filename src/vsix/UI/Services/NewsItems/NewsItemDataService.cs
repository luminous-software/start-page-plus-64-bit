namespace StartPagePlus.UI.Services.NewsItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using StartPagePlus.UI.Interfaces.NewsItems;
    using StartPagePlus.UI.ViewModels.NewsItems;

    internal class NewsItemDataService : ServiceBase, INewsItemDataService
    {
        private const string ITEM_ELEMENT_NAME = "item";
        private const string NO_ANGLE_BRACKETS_AND_NO_EXTENSION = "<.*?>|&.*?;";

        private const string TITLE_ELEMENT_NAME = "title";
        private const string DESCRIPTION_ELEMENT_NAME = "description";
        private const string LINK_ELEMENT_NAME = "link";
        private const string PUB_DATE_ELEMENT_NAME = "pubDate";

        public NewsItemDataService() : base()
        { }

        public async Task<List<NewsItemViewModel>> GetItemsAsync(string feedUrl, int itemsToDisplay)
        {
            //https://wp.qmatteoq.com/?p=6486
            //https://blog.qmatteoq.com/the-mvvm-pattern-dependency-injection/

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(feedUrl);
                var document = XDocument.Parse(response);
                var viewModels = (
                    from item in document
                        .Descendants(ITEM_ELEMENT_NAME)
                        .Take(itemsToDisplay)
                    select new NewsItemViewModel
                    {
                        Title = ExtractTitle(item),
                        Description = ExtractDescription(item),
                        Link = ExtractLink(item),
                        Date = ExtractPublishDate(item)
                        //PeriodType = CalculatePeriodType(pinned, today, date);
                    }
                ).ToList();

                return new List<NewsItemViewModel>(viewModels);
            }
        }

        private string ExtractTitle(XElement item)
            => (string)item.Element(TITLE_ELEMENT_NAME);

        private string ExtractDescription(XElement item)
            => Regex.Replace((string)item.Element(DESCRIPTION_ELEMENT_NAME),
                NO_ANGLE_BRACKETS_AND_NO_EXTENSION,
                string.Empty);

        private string ExtractLink(XElement item)
            => (string)item.Element(LINK_ELEMENT_NAME);

        private DateTime ExtractPublishDate(XElement item)
        {
            var elementValue = (string)item.Element(PUB_DATE_ELEMENT_NAME);

            DateTime.TryParse(elementValue, out var result);

            return result;
        }
    }
}