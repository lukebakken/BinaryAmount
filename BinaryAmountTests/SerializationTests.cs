namespace BinaryAmountTests
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using BinaryAmount;
    using Newtonsoft.Json;
    using Xunit;

    public class SerializationTests
    {
        [Fact]
        public void Serialize_ToJson_AndBack()
        {
            var amt = new BinAmt(8192, BinQuantity.MiB);

            string json = JsonConvert.SerializeObject(amt);
            Assert.Equal("{\"bytes\":8589934592}", json);

            amt = JsonConvert.DeserializeObject<BinAmt>(json);
            Assert.Equal(8192, amt.MiB);
        }

        [Fact]
        public void Serialize_ViaBinaryFormatter_AndBack()
        {
            string file = Path.GetTempFileName();

            var amt1 = new BinAmt(8192, BinQuantity.MiB);
            using (var fs = new FileStream(file, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, amt1);
            }

            BinAmt amt2;
            using (var fs = new FileStream(file, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                amt2 = (BinAmt)formatter.Deserialize(fs);
            }

            Assert.Equal(amt1, amt2);
            Assert.Equal(8589934592, amt2.Bytes);
        }
    }
}