﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NatashaFunctionUT.Domain.Plugin
{
    [Trait("基础功能测试", "插件")]
    public class DNSVTest: PluginPrepare
    {
        [Fact(DisplayName = "[不同插件][同名同版本依赖]测试")]
        public void Test()
        {
            var path1 = PathCombine1("DNSV1.dll");
            var path2 = PathCombine2("DNSV2.dll");

            var result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.None);
            Assert.Equal("InvalidCastException", result.r1);
            Assert.Equal("InvalidCastException", result.r2);

            result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.None, true);
            Assert.Equal("Json:13.0.0.0;Dapper:2.0.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r1);
            Assert.Equal("Json:13.0.0.0;Dapper:2.0.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r2);

            result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.UseHighVersion);
            Assert.Equal("Json:13.0.0.0;Dapper:2.0.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r1);
            Assert.Equal("Json:13.0.0.0;Dapper:2.0.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r2);

            result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.UseLowVersion);
            Assert.Equal("Json:9.0.0.0;Dapper:2.0.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r1);
            Assert.Equal("Json:9.0.0.0;Dapper:2.0.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r2);

            result = PluginAssertHelper.GetResult(path1, path2, LoadBehaviorEnum.UseBeforeIfExist);
            Assert.Equal("Json:9.0.0.0;Dapper:2.0.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r1);
            Assert.Equal("Json:9.0.0.0;Dapper:2.0.0.0;IPluginBase:1.0.0.0;Self:1.0.0.0", result.r2);
        }
    }
}
