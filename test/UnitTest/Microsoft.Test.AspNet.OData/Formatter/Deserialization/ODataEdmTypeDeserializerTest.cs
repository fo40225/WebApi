﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.OData.Formatter.Deserialization;
using Microsoft.OData;
using Microsoft.Test.AspNet.OData.Common;
using Moq;
using Xunit;

namespace Microsoft.Test.AspNet.OData.Formatter.Deserialization
{
    public class ODataEdmTypeDeserializerTest
    {
        [Fact]
        public void Ctor_SetsProperty_ODataPayloadKind()
        {
            var deserializer = new Mock<ODataEdmTypeDeserializer>(ODataPayloadKind.Unsupported);

            Assert.Equal(ODataPayloadKind.Unsupported, deserializer.Object.ODataPayloadKind);
        }

        [Fact]
        public void Ctor_SetsProperty_DeserializerProvider()
        {
            Mock<ODataDeserializerProvider> deserializerProvider = new Mock<ODataDeserializerProvider>();
            var deserializer = new Mock<ODataEdmTypeDeserializer>(ODataPayloadKind.Unsupported, deserializerProvider.Object);

            Assert.Same(deserializerProvider.Object, deserializer.Object.DeserializerProvider);
        }

        [Fact]
        public void ReadInline_Throws_NotSupported()
        {
            var deserializer = new Mock<ODataEdmTypeDeserializer>(ODataPayloadKind.Unsupported) { CallBase = true };

            ExceptionAssert.Throws<NotSupportedException>(
                () => deserializer.Object.ReadInline(item: null, edmType: null, readContext: null),
                "Type 'ODataEdmTypeDeserializerProxy' does not support ReadInline.");
        }
    }
}
