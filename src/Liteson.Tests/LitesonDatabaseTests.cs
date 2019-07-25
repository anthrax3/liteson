using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Liteson.Tests
{
    [TestClass]
    public class LitesonDatabaseTests
    {
        private static readonly  CultureInfo Culture = new CultureInfo("tr-tr");
        private static readonly List<SomeClass> SomeClassList = new List<SomeClass>(short.MaxValue);
        private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LitesonDb");
        public const string TableName = nameof(SomeClass);
        private static ITextDatabase _database;

        [ClassInitialize]
        public static void FixtureSetup(TestContext testContext)
        {
            if (Directory.Exists(DbPath))
            {
                Directory.Delete(DbPath, true);
            }
            _database = new LitesonDatabase(Culture, DbPath);
            SomeClassList.Clear();
            var rnd = new Random(1);
            for (int i = 0; i < 1000; i++)
            {
                var someClass = new SomeClass(rnd.Next(1, 30));
                if (i % 2 == 0)
                {
                    someClass.SomeEnum = SomeEnum.Five;
                    someClass.SomeEnumN = SomeEnum.Zero;
                    someClass.TimeSpan = new TimeSpan(long.MaxValue);
                    someClass.TimeSpanN = new TimeSpan(long.MinValue);
                    someClass.BigInteger = i * int.MaxValue;
                    someClass.BigIntegerN = i * int.MinValue;
                    someClass.Bool = true;
                    someClass.BoolN = false;
                    someClass.Byte = Byte.MaxValue;
                    someClass.ByteN = Byte.MinValue;
                    someClass.Char = 'C';
                    someClass.CharN = 'c';
                    someClass.Bytes = Encoding.UTF8.GetBytes("Liteson");
                    someClass.DateTime = DateTime.MaxValue;
                    someClass.DateTimeN = DateTime.MinValue;
                    someClass.DateTimeOffset = DateTimeOffset.MaxValue;
                    someClass.DateTimeOffsetN = DateTimeOffset.MinValue;
                    someClass.Decimal = decimal.MaxValue;
                    someClass.DecimalN = decimal.MinValue;
                    someClass.Double = double.MaxValue;
                    someClass.DoubleN = double.MinValue;
                    someClass.Float = float.MaxValue;
                    someClass.FloatN = float.MinValue;
                    someClass.Guid = Guid.NewGuid();
                    someClass.GuidN = Guid.Empty;
                    someClass.Int = int.MaxValue;
                    someClass.IntN = int.MinValue;
                    someClass.Uint = uint.MaxValue;
                    someClass.UintN = uint.MinValue;
                    someClass.Long = long.MaxValue;
                    someClass.LongN = long.MinValue;
                    someClass.Ulong = ulong.MaxValue;
                    someClass.UlongN = ulong.MinValue;
                    someClass.Sbyte = sbyte.MaxValue;
                    someClass.SbyteN = sbyte.MinValue;
                    someClass.Short = short.MaxValue;
                    someClass.ShortN = short.MinValue;
                    someClass.Ushort = ushort.MaxValue;
                    someClass.UshortN = ushort.MinValue;

                    someClass.Strinig = $"SomeClass({i})";
                    someClass.Uri = new Uri(new Uri("http://www.titaniumsoft.com/"), someClass.Strinig);
                }
                else if (i % 3 == 0)
                {
                    someClass.SomeEnum = SomeEnum.Zero;
                    someClass.SomeEnumN = null;
                    someClass.TimeSpan = TimeSpan.Zero;
                    someClass.TimeSpanN = null;
                    someClass.BigInteger = i * long.MaxValue;
                    someClass.BigIntegerN = null;
                    someClass.Bool = true;
                    someClass.BoolN = false;
                    someClass.Byte = Byte.MaxValue;
                    someClass.ByteN = null;
                    someClass.Char = 'C';
                    someClass.CharN = null;
                    someClass.Bytes = Encoding.UTF8.GetBytes("Liteson");
                    someClass.DateTime = DateTime.Today;
                    someClass.DateTimeN = null;
                    someClass.DateTimeOffset = DateTimeOffset.UnixEpoch;
                    someClass.DateTimeOffsetN = null;
                    someClass.Decimal = decimal.One;
                    someClass.DecimalN = null;
                    someClass.Double = double.Epsilon;
                    someClass.DoubleN = null;
                    someClass.Float = float.Epsilon;
                    someClass.FloatN = null;
                    someClass.Guid = Guid.NewGuid();
                    someClass.GuidN = null;
                    someClass.Int = int.MaxValue;
                    someClass.IntN = null;
                    someClass.Uint = uint.MaxValue;
                    someClass.UintN = null;
                    someClass.Long = long.MaxValue;
                    someClass.LongN = null;
                    someClass.Ulong = ulong.MaxValue;
                    someClass.UlongN = null;
                    someClass.Sbyte = sbyte.MaxValue;
                    someClass.SbyteN = null;
                    someClass.Short = short.MaxValue;
                    someClass.ShortN = null;
                    someClass.Ushort = ushort.MaxValue;
                    someClass.UshortN = null;

                    someClass.Strinig = $"SomeClass({i})";
                    someClass.Uri = new Uri(new Uri("http://www.titaniumsoft.com/"), someClass.Strinig);
                }
                else
                {
                    someClass.SomeEnum = SomeEnum.One;
                    someClass.SomeEnumN = SomeEnum.Zero;
                    someClass.TimeSpan = TimeSpan.Zero;
                    someClass.TimeSpanN = new TimeSpan(long.MinValue);
                    someClass.BigInteger = i * long.MaxValue;
                    someClass.BigIntegerN = i * long.MinValue;
                    someClass.Bool = true;
                    someClass.BoolN = false;
                    someClass.Byte = Byte.MaxValue;
                    someClass.ByteN = Byte.MinValue;
                    someClass.Char = 'C';
                    someClass.CharN = 'c';
                    someClass.Bytes = Encoding.UTF8.GetBytes("Liteson");
                    someClass.DateTime = DateTime.Today;
                    someClass.DateTimeN = DateTime.Today;
                    someClass.DateTimeOffset = DateTimeOffset.UnixEpoch;
                    someClass.DateTimeOffsetN = DateTimeOffset.UnixEpoch;
                    someClass.Decimal = decimal.One;
                    someClass.DecimalN = decimal.Zero;
                    someClass.Double = double.Epsilon;
                    someClass.DoubleN = double.NaN;
                    someClass.Float = float.Epsilon;
                    someClass.FloatN = float.NaN;
                    someClass.Guid = Guid.NewGuid();
                    someClass.GuidN = Guid.Empty;
                    someClass.Int = int.MaxValue;
                    someClass.IntN = int.MinValue;
                    someClass.Uint = uint.MaxValue;
                    someClass.UintN = uint.MinValue;
                    someClass.Long = long.MaxValue;
                    someClass.LongN = long.MinValue;
                    someClass.Ulong = ulong.MaxValue;
                    someClass.UlongN = ulong.MinValue;
                    someClass.Sbyte = sbyte.MaxValue;
                    someClass.SbyteN = sbyte.MinValue;
                    someClass.Short = short.MaxValue;
                    someClass.ShortN = short.MinValue;
                    someClass.Ushort = ushort.MaxValue;
                    someClass.UshortN = ushort.MinValue;

                    someClass.Strinig = $"SomeClass({i})";
                    someClass.Uri = new Uri(new Uri("http://www.titaniumsoft.com/"), someClass.Strinig);
                }
                SomeClassList.Add(someClass);
            }
        }

        [TestMethod]
        public void TestAppendNRead()
        {
            _database.DropTable(TableName);
            _database.AppendTable(TableName, SomeClassList);
            var table = _database.ReadTable<SomeClass>(TableName);
            for (int i = 0; i < table.Count; i++)
            {
                var row = table[i];
                var someClass = SomeClassList[i];

                Assert.AreEqual(someClass.Guid, row.Guid);
                Assert.AreEqual(someClass.GuidN, row.GuidN);

                Assert.AreEqual(someClass.SomeEnum, row.SomeEnum);
                Assert.AreEqual(someClass.SomeEnumN, row.SomeEnumN);
                Assert.AreEqual(someClass.TimeSpan, row.TimeSpan);
                Assert.AreEqual(someClass.TimeSpanN, row.TimeSpanN);
                Assert.AreEqual(someClass.BigInteger, row.BigInteger);
                Assert.AreEqual(someClass.BigIntegerN, row.BigIntegerN);
                Assert.AreEqual(someClass.Bool, row.Bool);
                Assert.AreEqual(someClass.BoolN, row.BoolN);
                Assert.AreEqual(someClass.Byte, row.Byte);
                Assert.AreEqual(someClass.ByteN, row.ByteN);
                Assert.AreEqual(someClass.Char, row.Char);
                Assert.AreEqual(someClass.CharN, row.CharN);
                CollectionAssert.AreEqual(someClass.Bytes, row.Bytes);
                Assert.AreEqual(someClass.DateTime, row.DateTime);
                Assert.AreEqual(someClass.DateTimeN, row.DateTimeN);
                Assert.AreEqual(someClass.DateTimeOffset, row.DateTimeOffset);
                Assert.AreEqual(someClass.DateTimeOffsetN, row.DateTimeOffsetN);
                Assert.AreEqual(someClass.Decimal, row.Decimal);
                Assert.AreEqual(someClass.DecimalN, row.DecimalN);
                Assert.AreEqual(someClass.Double, row.Double);
                Assert.AreEqual(someClass.DoubleN, row.DoubleN);
                Assert.AreEqual(someClass.Float, row.Float);
                Assert.AreEqual(someClass.FloatN, row.FloatN);
                Assert.AreEqual(someClass.Int, row.Int);
                Assert.AreEqual(someClass.IntN, row.IntN);
                Assert.AreEqual(someClass.Uint, row.Uint);
                Assert.AreEqual(someClass.UintN, row.UintN);
                Assert.AreEqual(someClass.Long, row.Long);
                Assert.AreEqual(someClass.LongN, row.LongN);
                Assert.AreEqual(someClass.Ulong, row.Ulong);
                Assert.AreEqual(someClass.UlongN, row.UlongN);
                Assert.AreEqual(someClass.Sbyte, row.Sbyte);
                Assert.AreEqual(someClass.SbyteN, row.SbyteN);
                Assert.AreEqual(someClass.Short, row.Short);
                Assert.AreEqual(someClass.ShortN, row.ShortN);
                Assert.AreEqual(someClass.Ushort, row.Ushort);
                Assert.AreEqual(someClass.UshortN, row.UshortN);
                Assert.AreEqual(someClass.Strinig, row.Strinig);
                Assert.AreEqual(someClass.Uri, row.Uri);
                // Check Column Fields
                for (int j = 0; j < someClass.SubClasses.Count; j++)
                {
                    Assert.AreEqual(someClass.SubClasses[i].Key, row.SubClasses[i].Key);
                    Assert.AreEqual(someClass.SubClasses[i].Value, row.SubClasses[i].Value);
                }
                // Check Column Fields
                CollectionAssert.AreEqual(someClass.StringList, row.StringList);
            }
        }


    }

    public class SomeClass
    {
        public SomeClass()
        {
        }

        public SomeClass(int maxItems)
        {
            SubClasses = new List<SubClass>(maxItems);
            StringList = new List<string>(maxItems);
            for (int i = 0; i <= maxItems; i++)
            {
                var sc = new SubClass {Key = i, Value = $"Value{i}"};
                SubClasses.Add(sc);
                StringList.Add(sc.Value);
            }
        }

        public SomeEnum SomeEnum { get; set; }
        public SomeEnum? SomeEnumN { get; set; }

        public char Char { get; set; }
        public char? CharN { get; set; }
        public bool Bool { get; set; }
        public bool? BoolN { get; set; }
        public byte Byte { get; set; }
        public byte? ByteN { get; set; }
        public sbyte Sbyte { get; set; }
        public sbyte? SbyteN { get; set; }
        public short Short { get; set; }
        public short? ShortN { get; set; }
        public ushort Ushort { get; set; }
        public ushort? UshortN { get; set; }
        public int Int { get; set; }
        public int? IntN { get; set; }
        public uint Uint { get; set; }
        public uint? UintN { get; set; }
        public long Long { get; set; }
        public long? LongN { get; set; }
        public ulong Ulong { get; set; }
        public ulong? UlongN { get; set; }
        public BigInteger BigInteger { get; set; }
        public BigInteger? BigIntegerN { get; set; }
        public float Float { get; set; }
        public float? FloatN { get; set; }
        public double Double { get; set; }
        public double? DoubleN { get; set; }
        public decimal Decimal { get; set; }
        public decimal? DecimalN { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? DateTimeN { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
        public DateTimeOffset? DateTimeOffsetN { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public TimeSpan? TimeSpanN { get; set; }
        public Guid Guid { get; set; }
        public Guid? GuidN { get; set; }
        public byte[] Bytes { get; set; }
        public string Strinig { get; set; }
        public Uri Uri { get; set; }

        public List<SubClass> SubClasses { get; set; }
        public List<string> StringList { get; set; }
    }

    public class SubClass
    {
        public int Key { get; set; }

        public string Value { get; set; }
    }

    public enum SomeEnum
    {
        Zero=0,
        One=1,
        Two=2,
        Three=3,
        Four=4,
        Five=5
    }
}
