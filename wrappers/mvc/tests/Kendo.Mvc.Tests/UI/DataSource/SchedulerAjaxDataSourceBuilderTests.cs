﻿namespace Kendo.Mvc.UI.Fluent.Tests
{
    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Tests;
    using System;
    using Xunit;

    public class SchedulerAjaxDataSourceBuilderTests
    {
        private readonly DataSource dataSource;
        private readonly SchedulerAjaxDataSourceBuilder<Customer> builder;

        public SchedulerAjaxDataSourceBuilderTests()
        {
            dataSource = new DataSource();
            builder = new SchedulerAjaxDataSourceBuilder<Customer>(dataSource, TestHelper.CreateViewContext(), new UrlGenerator());
        }

#if !MVC3
        [Fact]
        public void Webapi_should_return_webapi_datasource_builder()
        {
            builder.WebApi().ShouldBeType(typeof(FilterableWebApiDataSourceBuilder<Customer>));
        }

        [Fact]
        public void Webapi_should_set_datasource_type()
        {
            builder.WebApi();
            dataSource.Type.ShouldEqual(DataSourceType.WebApi);
        }
#endif

        [Fact]
        public void Filter_should_return_webapi_datasource_builder()
        {
            builder.Filter(f => f.Add(m => m.Name).Contains("SomeVal")).ShouldBeType(typeof(SchedulerAjaxDataSourceBuilder<Customer>));
        }

        [Fact]
        public void ServerOperations_should_return_correct_datasource_builder()
        {
            builder.ServerOperation(true).ShouldBeType(typeof(SchedulerAjaxDataSourceBuilder<Customer>));
        }

        [Fact]
        public void Sort_should_throw_error()
        {
            Exception ex = Record.Exception(new Assert.ThrowsDelegate(() => { builder.Sort(s => s.Add(m => m.Name)); }));

            Assert.IsType(typeof(MethodAccessException), ex);
        }

        [Fact]
        public void Group_should_throw_error()
        {
            Exception ex = Record.Exception(new Assert.ThrowsDelegate(() => { builder.Group(s => s.Add(m => m.Name)); }));

            Assert.IsType(typeof(MethodAccessException), ex);
        }

        [Fact]
        public void Aggregates_should_throw_error()
        {
            Exception ex = Record.Exception(new Assert.ThrowsDelegate(() => { builder.Aggregates(s => s.Add(m => m.Name)); }));

            Assert.IsType(typeof(MethodAccessException), ex);
        }
    }
}