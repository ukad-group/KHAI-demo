using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Khai_demo.ContactForm
{
    public class ContactFormController : SurfaceController
    {
        private readonly IContentService _contentService;

        public ContactFormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, IContentService contentService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _contentService = contentService;
        }

        [HttpPost]
        public IActionResult Submit(ContactFormRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var content = _contentService.Create(requestModel.Name, new Guid("69874060-97d7-4cc0-b3c6-1820e5a82d2d"), "formItem");

            content.SetValue("userName", requestModel.Name);
            content.SetValue("telegram", requestModel.Telegram);
            content.SetValue("question", requestModel.Question);

            _contentService.SaveAndPublish(content);

            return RedirectToUmbracoPage(new Guid("3ad5ab0b-6190-4188-af17-8c8adec48c8f"));
        }
    }
}
