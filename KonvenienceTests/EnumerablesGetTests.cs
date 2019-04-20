﻿using FluentAssertions;
using NUnit.Framework;
using System;

namespace Konvenience
{
    class EnumerablesGetTests
    {
        private static char[] NonEmptyArray()
            => new char[] { 'a', 'b', 'c', 'd' };

        #region Get with array tests
        [Test]
        public void Test_Get_A_Valid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();
            int index = 0;

            array.Get(index)
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_Get_An_Invalid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();

            array
                .Invoking(a => a.Get(-1))
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .Where(e => e.Message.Contains("index"));
        }

        [Test]
        public void Test_Get_In_A_Null_Array() => Null
            .As<char[]>()
            .Invoking(n => n.Get(0))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("array"));

        [Test]
        public void Test_GetOrElse_A_Valid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();
            int index = 0;

            array.GetOrElse(index, 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_An_Invalid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();

            array.GetOrElse(-1, 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_In_A_Null_Array() => Null
            .As<char[]>()
            .GetOrElse(0, 'z')
            .Should()
            .Be('z');

        [Test]
        public void Test_GetOrElse_With_A_Function_A_Valid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();
            int index = 0;

            array.GetOrElse(index, () => 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_An_Invalid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();

            array.GetOrElse(-1, () => 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_In_A_Null_Array() => Null
            .As<char[]>()
            .GetOrElse(0, () => 'z')
            .Should()
            .Be('z');
        #endregion
    }
}
