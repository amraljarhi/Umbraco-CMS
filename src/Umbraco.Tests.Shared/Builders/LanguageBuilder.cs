using System.Globalization;
using Moq;
using Umbraco.Core.Configuration;
using Umbraco.Core.Models;

namespace Umbraco.Tests.Shared.Builders
{
    public class LanguageBuilder<TParent> : ChildBuilderBase<TParent, ILanguage>
    {
        private int? _id = null;
        private string _isoCode = null;

        public LanguageBuilder(TParent parentBuilder) : base(parentBuilder)
        {
        }

        public override ILanguage Build()
        {
            var culture = CultureInfo.GetCultureInfo("en-US");
            var isoCode = _isoCode ?? culture.Name;
            return new Language(Mock.Of<IGlobalSettings>(), isoCode)
            {
                Id = _id ?? 1,
                CultureName = culture.TwoLetterISOLanguageName,
                IsoCode =  new RegionInfo(culture.LCID).Name,
            };
        }

        public LanguageBuilder<TParent> WithId(int id)
        {
            _id = id;
            return this;
        }
    }
}
