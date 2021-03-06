﻿using System.Globalization;
using Microsoft.Recognizers.Text.Number;
using Microsoft.Recognizers.Text.Number.Turkish;

namespace Microsoft.Recognizers.Text.NumberWithUnit.Turkish
{
    public class TurkishNumberWithUnitParserConfiguration : BaseNumberWithUnitParserConfiguration
    {
        public TurkishNumberWithUnitParserConfiguration(CultureInfo ci)
               : base(ci)
        {
            this.InternalNumberExtractor = NumberExtractor.GetInstance();
            this.InternalNumberParser = AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Number, new TurkishNumberParserConfiguration(
                                                                                  new BaseNumberOptionsConfiguration(ci.Name)));
            this.ConnectorToken = string.Empty;
        }

        public override IParser InternalNumberParser { get; }

        public override IExtractor InternalNumberExtractor { get; }

        public override string ConnectorToken { get; }
    }
}
