namespace BinAmtTests
{
    using BinaryAmount;
    using Xunit;

    public class ConversionTests
    {
        [Fact]
        public void From_Int32()
        {
            BinAmt amt = 1024;
            Assert.Equal(1, amt.KiB);
        }

        [Fact]
        public void To_Int32()
        {
            var amt = new BinAmt(8192);
            Assert.Equal(8192, (int)amt);
        }

        [Fact]
        public void From_UInt32()
        {
            BinAmt amt = 1024;
            Assert.Equal<uint>(1, (uint)amt.KiB);
        }

        [Fact]
        public void To_UInt32()
        {
            var amt = new BinAmt(8192);
            Assert.Equal<uint>(8192, (uint)amt);
        }

        [Fact]
        public void From_Int64()
        {
            BinAmt amt = 1024;
            Assert.Equal<long>(1L, amt.KiB);
        }

        [Fact]
        public void To_Int64()
        {
            var amt = new BinAmt(8192);
            Assert.Equal<long>(8192L, (long)amt);
        }

        [Fact]
        public void From_Decimal()
        {
            BinAmt amt = (BinAmt)2048.1M;
            Assert.Equal(2, amt.KiB);
        }

        [Fact]
        public void To_Decimal()
        {
            var amt = new BinAmt(8192);
            Assert.Equal<decimal>(8192M, amt);
        }

        [Fact]
        public void From_Float()
        {
            BinAmt amt = (BinAmt)4096.1320487F;
            Assert.Equal(4, amt.KiB);
        }

        [Fact]
        public void To_Float()
        {
            var amt = new BinAmt(8192);
            Assert.Equal<float>(8192F, amt);
        }
    }
}