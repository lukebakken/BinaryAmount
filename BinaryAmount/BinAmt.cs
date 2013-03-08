using System;
using System.Runtime.Serialization;

namespace BinaryAmount
{
    [Serializable, DataContract]
    public struct BinAmt : IEquatable<BinAmt>
    {
        private static readonly long KibiByte = (long)Math.Pow(2, 10);
        private static readonly long KiloByte = (long)Math.Pow(10, 3);

        private static readonly long MebiByte = (long)Math.Pow(2, 20);
        private static readonly long MegaByte = (long)Math.Pow(10, 6);

        private static readonly long GibiByte = (long)Math.Pow(2, 30);
        private static readonly long GigaByte = (long)Math.Pow(10, 9);

        private static readonly long TibiByte = (long)Math.Pow(2, 40);
        private static readonly long TeraByte = (long)Math.Pow(10, 12);

        private static readonly long PebiByte = (long)Math.Pow(2, 50);
        private static readonly long PetaByte = (long)Math.Pow(10, 15);

        private static readonly long ExbiByte = (long)Math.Pow(2, 60);
        private static readonly long ExaByte  = (long)Math.Pow(10, 18);

        private long bytes;

        public BinAmt(long bytes)
        {
            this.bytes = bytes;
        }

        public BinAmt(long value, BinQuantity quantity)
        {
            this.bytes = 0;

            switch (quantity)
            {
                case BinQuantity.KiB :
                    this.KiB = value;
                    break;
                case BinQuantity.KB :
                    this.KB = value;
                    break;
                case BinQuantity.MiB :
                    this.MiB = value;
                    break;
                case BinQuantity.MB :
                    this.MB = value;
                    break;
                case BinQuantity.GiB :
                    this.GiB = value;
                    break;
                case BinQuantity.GB :
                    this.GB = value;
                    break;
                case BinQuantity.TiB :
                    this.TiB = value;
                    break;
                case BinQuantity.TB :
                    this.TB = value;
                    break;
                case BinQuantity.PiB :
                    this.PiB = value;
                    break;
                case BinQuantity.PB :
                    this.PB = value;
                    break;
                case BinQuantity.EiB :
                    this.EiB = value;
                    break;
                case BinQuantity.EB :
                    this.EB = value;
                    break;
                default :
                    throw new ArgumentException("Invalid BinQuantity", "quantity");
            }
        }

        [DataMember(Name="bytes")]
        public long Bytes
        {
            get { return bytes; }
            private set { bytes = value; }
        }

        public long KiB
        {
            get { return bytes / KibiByte; }
            private set { this.bytes = value * KibiByte; }
        }

        public long KB
        {
            get { return bytes / KiloByte; }
            private set { this.bytes = value * KiloByte; }
        }

        public long MiB
        {
            get { return bytes / MebiByte; }
            private set { this.bytes = value * MebiByte; }
        }

        public long MB
        {
            get { return bytes / MegaByte; }
            private set { this.bytes = value * MegaByte; }
        }

        public long GiB
        {
            get { return bytes / GibiByte; }
            private set { this.bytes = value * GibiByte; }
        }

        public long GB
        {
            get { return bytes / GigaByte; }
            private set { this.bytes = value * GigaByte; }
        }

        public long TiB
        {
            get { return bytes / TibiByte; }
            private set { this.bytes = value * TibiByte; }
        }

        public long TB
        {
            get { return bytes / TeraByte; }
            private set { this.bytes = value * TeraByte; }
        }

        public long PiB
        {
            get { return bytes / PebiByte; }
            private set { this.bytes = value * PebiByte; }
        }

        public long PB
        {
            get { return bytes / PetaByte; }
            private set { this.bytes = value * PetaByte; }
        }

        public long EiB
        {
            get { return bytes / ExbiByte; }
            private set { this.bytes = value * ExbiByte; }
        }

        public long EB
        {
            get { return bytes / ExaByte; }
            private set { this.bytes = value * ExaByte; }
        }

        public static implicit operator BinAmt(int amt)
        {
            return new BinAmt(amt);
        }

        public static implicit operator long(BinAmt amt)
        {
            return amt.Bytes;
        }

        public static implicit operator decimal(BinAmt amt)
        {
            return amt.Bytes;
        }

        public static implicit operator float(BinAmt amt)
        {
            return amt.Bytes;
        }

        public static explicit operator int(BinAmt amt)
        {
            return (int)amt.Bytes;
        }

        public static explicit operator BinAmt(decimal amt)
        {
            return new BinAmt((long)amt);
        }

        public static explicit operator BinAmt(float amt)
        {
            return new BinAmt((long)amt);
        }

        public long GetAs(BinQuantity quantity)
        {
            long amt = 0;

            switch (quantity)
            {
                case BinQuantity.KiB :
                    amt = this.KiB;
                    break;
                case BinQuantity.KB :
                    amt = this.KB;
                    break;
                case BinQuantity.MiB :
                    amt = this.MiB;
                    break;
                case BinQuantity.MB :
                    amt = this.MB;
                    break;
                case BinQuantity.GiB :
                    amt = this.GiB;
                    break;
                case BinQuantity.GB :
                    amt = this.GB;
                    break;
                case BinQuantity.TiB :
                    amt = this.TiB;
                    break;
                case BinQuantity.TB :
                    amt = this.TB;
                    break;
                case BinQuantity.PiB :
                    amt = this.PiB;
                    break;
                case BinQuantity.PB :
                    amt = this.PB;
                    break;
                case BinQuantity.EiB :
                    amt = this.EiB;
                    break;
                case BinQuantity.EB :
                    amt = this.EB;
                    break;
                default :
                    throw new ArgumentException("Invalid BinQuantity", "quantity");
            }

            return amt;
        }

        public bool Equals(BinAmt other)
        {
            return this.bytes == other.bytes;
        }

        public override bool Equals(object obj)
        {
            if (obj is BinAmt)
            {
                return Equals((BinAmt)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return 23 * 37 + bytes.GetHashCode();
            }
        }
    }
}