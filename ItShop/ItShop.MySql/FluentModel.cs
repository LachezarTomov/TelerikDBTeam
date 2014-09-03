#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;

namespace ItShop.MySql	
{
	public partial class ItShopMySql : OpenAccessContext, IItShopMySqlUnitOfWork
	{
        private static string connectionStringName = @"ItShopMySql";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = new ItShopMySqlMetadataSource();
		
		public ItShopMySql()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public ItShopMySql(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public ItShopMySql(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public ItShopMySql(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public ItShopMySql(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MySql";
			backend.ProviderName = "MySql.Data.MySqlClient";
		
			CustomizeBackendConfiguration(ref backend);
		
			return backend;
		}

        public IQueryable<ProductReport> Products
        {
            get
            {
                return this.GetAll<ProductReport>();
            }
        }

		/// <summary>
		/// Allows you to customize the BackendConfiguration of ItShopMySql.
		/// </summary>
		/// <param name="config">The BackendConfiguration of ItShopMySql.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}


	
	public interface IItShopMySqlUnitOfWork : IUnitOfWork
	{
	}
}
#pragma warning restore 1591
