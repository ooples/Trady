﻿using System;
using System.Collections.Generic;

using Trady.Analysis.Infrastructure;
using Trady.Core.Infrastructure;

namespace Trady.Analysis.Candlestick
{
    /// <summary>
    /// Reference: http://stockcharts.com/school/doku.php?id=chart_school:chart_analysis:candlestick_pattern_dictionary
    /// </summary>
    public class Stars<TInput, TOutput> : AnalyzableBase<TInput, (decimal Open, decimal High, decimal Low, decimal Close), bool?, TOutput>
    {
        public Stars(IEnumerable<TInput> inputs, Func<TInput, (decimal Open, decimal High, decimal Low, decimal Close)> inputMapper) : base(inputs, inputMapper)
        {
        }

        protected override bool? ComputeByIndexImpl(IReadOnlyList<(decimal Open, decimal High, decimal Low, decimal Close)> mappedInputs, int index)
        {
            throw new NotImplementedException();
        }
    }

    public class StarsByTuple : Stars<(decimal Open, decimal High, decimal Low, decimal Close), bool?>
    {
        public StarsByTuple(IEnumerable<(decimal Open, decimal High, decimal Low, decimal Close)> inputs)
            : base(inputs, i => i)
        {
        }
    }

    public class Stars : Stars<IOhlcvData, AnalyzableTick<bool?>>
    {
        public Stars(IEnumerable<IOhlcvData> inputs)
            : base(inputs, i => (i.Open, i.High, i.Low, i.Close))
        {
        }
    }
}