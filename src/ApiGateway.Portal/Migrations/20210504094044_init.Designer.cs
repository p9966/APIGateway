﻿// <auto-generated />
using System;
using APIGateway.Core.DbRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGateway.Portal.Migrations
{
    [DbContext(typeof(GatewayDbContext))]
    [Migration("20210504094044_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APIGateway.Core.Entities.Aggregates", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Aggregator")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enable")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("ReRouteIsCaseSensitive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ReRouteKeys")
                        .HasColumnType("text");

                    b.Property<string>("ReRouteKeysConfig")
                        .HasColumnType("text");

                    b.Property<string>("UpstreamHost")
                        .HasColumnType("text");

                    b.Property<string>("UpstreamPathTemplate")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Aggregates");
                });

            modelBuilder.Entity("APIGateway.Core.Entities.GlobalConfiguration", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("BaseUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime");

                    b.Property<string>("DownstreamHttpVersion")
                        .HasColumnType("text");

                    b.Property<string>("DownstreamScheme")
                        .HasColumnType("text");

                    b.Property<bool>("Enable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HttpHandlerOptions")
                        .HasColumnType("text");

                    b.Property<string>("LoadBalancerOptions")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("QoSOptions")
                        .HasColumnType("text");

                    b.Property<string>("RateLimitOptions")
                        .HasColumnType("text");

                    b.Property<string>("RequestIdKey")
                        .HasColumnType("text");

                    b.Property<string>("ServiceDiscoveryProvider")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GlobalConfiguration");
                });

            modelBuilder.Entity("APIGateway.Core.Entities.ReRoute", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("AddClaimsToRequest")
                        .HasColumnType("text");

                    b.Property<string>("AddHeadersToRequest")
                        .HasColumnType("text");

                    b.Property<string>("AddQueriesToRequest")
                        .HasColumnType("text");

                    b.Property<string>("AuthenticationOptions")
                        .HasColumnType("text");

                    b.Property<string>("ChangeDownstreamPathTemplate")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("DangerousAcceptAnyServerCertificateValidator")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DelegatingHandlers")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime");

                    b.Property<string>("DownstreamHeaderTransform")
                        .HasColumnType("text");

                    b.Property<string>("DownstreamHostAndPorts")
                        .HasColumnType("text");

                    b.Property<string>("DownstreamHttpMethod")
                        .HasColumnType("text");

                    b.Property<string>("DownstreamHttpVersion")
                        .HasColumnType("text");

                    b.Property<string>("DownstreamPathTemplate")
                        .HasColumnType("text");

                    b.Property<string>("DownstreamScheme")
                        .HasColumnType("text");

                    b.Property<bool>("Enable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FileCacheOptions")
                        .HasColumnType("text");

                    b.Property<string>("GlobalConfigurationId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("HttpHandlerOptions")
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("LoadBalancerOptions")
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("QoSOptions")
                        .HasColumnType("text");

                    b.Property<string>("RateLimitOptions")
                        .HasColumnType("text");

                    b.Property<bool>("ReRouteIsCaseSensitive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RequestIdKey")
                        .HasColumnType("text");

                    b.Property<string>("RouteClaimsRequirement")
                        .HasColumnType("text");

                    b.Property<string>("SecurityOptions")
                        .HasColumnType("text");

                    b.Property<string>("ServiceName")
                        .HasColumnType("text");

                    b.Property<string>("ServiceNamespace")
                        .HasColumnType("text");

                    b.Property<int>("Timeout")
                        .HasColumnType("int");

                    b.Property<string>("UpstreamHeaderTransform")
                        .HasColumnType("text");

                    b.Property<string>("UpstreamHost")
                        .HasColumnType("text");

                    b.Property<string>("UpstreamHttpMethod")
                        .HasColumnType("text");

                    b.Property<string>("UpstreamPathTemplate")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GlobalConfigurationId");

                    b.ToTable("ReRoute");
                });

            modelBuilder.Entity("APIGateway.Core.Entities.ReRoute", b =>
                {
                    b.HasOne("APIGateway.Core.Entities.GlobalConfiguration", "GlobalConfiguration")
                        .WithMany("ReRoutes")
                        .HasForeignKey("GlobalConfigurationId");
                });
#pragma warning restore 612, 618
        }
    }
}
