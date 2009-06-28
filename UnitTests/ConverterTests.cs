﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using QuickFIX.NET;
using QuickFIX.NET.Fields.Converters;

namespace UnitTests
{
    [TestFixture]
    public class ConverterTests
    {
        [Test]
        public void BoolConverterTest()
        {
            Assert.That(BoolConverter.Convert("Y"), Is.EqualTo(true));
            Assert.That(BoolConverter.Convert("N"), Is.EqualTo(false));
            Assert.That(BoolConverter.Convert(true), Is.EqualTo("Y"));
            Assert.That(BoolConverter.Convert(false), Is.EqualTo("N"));
            Assert.Throws(typeof(BadConversionException),
                delegate { BoolConverter.Convert("Z"); });
        }

        [Test]
        public void CharConverterTest()
        {
            Assert.That(CharConverter.Convert('A'), Is.EqualTo("A"));
            Assert.That(CharConverter.Convert("B"), Is.EqualTo('B'));
            Assert.Throws(typeof(BadConversionException),
                delegate { CharConverter.Convert("AB"); });
        }

        [Test]
        public void IntConverterTest()
        {
            Assert.That(IntConverter.Convert(233), Is.EqualTo("233"));
            Assert.That(IntConverter.Convert("444556"), Is.EqualTo(444556));
            Assert.Throws(typeof(BadConversionException),
                delegate { IntConverter.Convert("AB"); });
            Assert.Throws(typeof(BadConversionException),
                delegate { IntConverter.Convert("2.3234"); });
            Assert.Throws(typeof(BadConversionException),
                delegate { IntConverter.Convert(""); });

        }

        [Test]
        public void DecimalConverterTest()
        {
            Assert.That(DecimalConverter.Convert(new Decimal(4.23322)), Is.EqualTo("4.23322"));
            Assert.That(DecimalConverter.Convert("4332.33"), Is.EqualTo(new Decimal(4332.33)));
            Assert.Throws(typeof(BadConversionException),
                delegate { DecimalConverter.Convert("2.32a34"); });
            Assert.Throws(typeof(BadConversionException),
                delegate { DecimalConverter.Convert(""); });
        }

        public void DateTimeConverterTest()
        {
            Assert.That(DateTimeConverter.Convert("20100912-04:22:01"),
                Is.EqualTo(new DateTime(2010, 9, 12, 4, 22, 01)));
            Assert.That(DateTimeConverter.Convert(new DateTime(2002,12,01,11,03,05)),
                Is.EqualTo("20021201-11:01:05"));
            Assert.Throws(typeof(BadConversionException),
                delegate { DateTimeConverter.Convert(""); });
        }
    }
}