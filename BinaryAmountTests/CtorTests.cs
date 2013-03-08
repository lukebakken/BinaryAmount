namespace BinAmtTests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using BinaryAmount;
    using Xunit;
    using Xunit.Extensions;

    public class CtorTests
    {
        [Theory]
        [InlineData(1024, BinQuantity.KiB)]
        [InlineData(1000, BinQuantity.KB)]
        [InlineData(1024 * 1024, BinQuantity.MiB)]
        [InlineData(1000 * 1000, BinQuantity.MB)]
        [InlineData(1024 * 1024 * 1024, BinQuantity.GiB)]
        [InlineData(1000 * 1000 * 1000, BinQuantity.GB)]
        [InlineData(1024 * 1024 * 1024 * 1024L, BinQuantity.TiB)]
        [InlineData(1000 * 1000 * 1000 * 1000L, BinQuantity.TB)]
        [InlineData(1024L * 1024L * 1024L * 1024L * 1024L, BinQuantity.PiB)]
        [InlineData(1000L * 1000L * 1000L * 1000L * 1000L, BinQuantity.PB)]
        [InlineData(1024L * 1024L * 1024L * 1024L * 1024L * 1024L, BinQuantity.EiB)]
        [InlineData(1000L * 1000L * 1000L * 1000L * 1000L * 1000L, BinQuantity.EB)]
        public void ConstructsExpectedBinAmt_WhenGivenIntegerAndBinQuantity(long amount, BinQuantity quantity)
        {
            var amt = new BinAmt(amount);
            Assert.Equal(1, amt.GetAs(quantity));
            Assert.Equal(amount, amt.Bytes);
        }

        [Theory]
        [PropertyData("AllEnumValues")]
        public void CanConstruct_FromAllBinQuantityEnumValues(BinQuantity quantity)
        {
            var amt = new BinAmt(1, quantity);
            Assert.Equal(1, amt.GetAs(quantity));
        }

        public static IEnumerable<object[]> AllEnumValues
        {
            get
            {
                return Enum.GetValues(typeof(BinQuantity)).Cast<BinQuantity>().Select(e => new object[] { e });
            }
        }
    }
}