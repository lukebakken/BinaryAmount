namespace BinaryAmountTests
{
    using BinaryAmount;
    using Xunit;
    using Xunit.Extensions;

    public class EqualityTests
    {
        [Theory]
        // KiB, KB
        [InlineData(1024, 1, BinQuantity.KiB)]
        [InlineData(65536, 64, BinQuantity.KiB)]
        [InlineData(1000, 1, BinQuantity.KB)]
        [InlineData(10000, 10, BinQuantity.KB)]
        // MiB, MB
        [InlineData(1048576, 1, BinQuantity.MiB)]
        [InlineData(104857600, 100, BinQuantity.MiB)]
        [InlineData(1000000, 1, BinQuantity.MB)]
        [InlineData(100000000, 100, BinQuantity.MB)]
        public void EqualsOperators(long bytes, long amt, BinQuantity binQuantity)
        {
            var amt1 = new BinAmt(bytes);
            var amt2 = new BinAmt(amt, binQuantity);
            Assert.True(amt1 == amt2);
            Assert.True(amt1.Equals(amt2));

            Assert.True(amt2 == amt1);
            Assert.True(amt2.Equals(amt1));
        }
    }
}